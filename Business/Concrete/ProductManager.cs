using Business.Abstract;
using Business.Aspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ILogger logger, ICategoryService categoryService) //bu kullanım yanlış. bir EntityManager, kendisi hariç başka bir 
                                                                                                //Dal ı enjekte edemez. ama Service i enjekte edilebilir. 
                                                                                                //kategoriye ait kurallar onun servisine yazılmalı.
        {
            _productDal = productDal;
            _logger = logger;
            _categoryService = categoryService;
        }      
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice <= max && p.UnitPrice >= min));
        }

        

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); //ErrorDataResult ın default datası null'dır o yüzden data döndürmez.
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
            
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),Messages.ProductsListed);
        }
        
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))] //Add metodunu ValidationAspect attribute'u ile ProductValidator u kullanarak doğrula.
        public IResult Add(Product product) //burada Result dönebilmesinin sebebi IResult ın, Result referansını da tutabiliyor olması.
                                            
        {
            _logger.Log();
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                                               CheckProductNameExists(product.ProductName),
                                               CheckCountOfCategories());
            if (result != null) // 3 ünden en az 1 i null hariç bişey döndürürse 
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult();
            
            //validation
            //doğrulama contexti oluştur.
            //bir sürü if yerine FluentValidation kullanıyoruz.
            //ValidationTool.Validate(new ProductValidator(), product);
             //çalışmaya başlamadan önce loglama işlemi
        }
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult("Kategori başına ürün max. 10 olmalıdır.");
            }
            return new SuccessResult();
        }
    
        private IResult CheckProductNameExists(string productName)
        {

            var result = _productDal.GetAll(p => p.ProductName == productName).Any();  //bu özelliği sağlayan eleman
                                                                                       //var mı yok mu bunu kontrol eder.
            if (result)
            {
                return new ErrorResult("O adda zaten bir ürün var.");
            }
            return new SuccessResult();      
        }
        private IResult CheckCountOfCategories()
        {
            var result = _categoryService.GetAll();

            if (result.Data.Count>15)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    
    
    
    
    } 
}
