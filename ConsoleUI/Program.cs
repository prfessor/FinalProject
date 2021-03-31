using System;
using Business.CCS;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

            


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal(), new FileLogger(), new CategoryManager());
            
            //var getProductDetails = productManager.GetProductDetails();

            /*if (getProductDetails.Success==true)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                            {
                                Console.WriteLine(product.ProductName + "/" + product.CategoryName);                              
                            }
                Console.WriteLine("*****************" + getProductDetails.Message + "*****************");
            }
            else
            {
                Console.WriteLine(getProductDetails.Message);
            }*/

            //var getAll = productManager.GetAll();

            //if (getAll.Success == true)
            //{
            //    foreach (var product in getAll.Data)
            //    {
            //        Console.WriteLine(product.ProductName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(getAll.Message);
            //}

            
        }
    }
}

/*foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var item in collection)
            {

            }*/