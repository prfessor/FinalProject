using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //ValidationAspect bir attribute dur.
    {
        private Type _validatorType; 
        public ValidationAspect(Type validatorType) //attributelarda ctor oluştururken Type kullanılır.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen validatortype bir IValidator değilse exception fırlat.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType; //eğer IValidator ise de ikisini eşitle.
        }
        protected override void OnBefore(IInvocation invocation) //invocation burada add, delete gibi metodları temsil ediyor.
                                                                 //metodlardan önce validation yapacak olan kod bloğu.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //çalışma anında çalışması = reflection Burada ProductValidator a instance oluşturur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //ProductValidator un önce çalıştığı base sınıfını (AbstractValidator), sonra da onun  çalışma tipini bul. (Product, customer vs.)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //metodun parametrelerini bul. sonra da onu base sınıfın çalıştığı class adı ile karşılaştır.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //validationTool burada gün yüzüne çıkıyor. validation şartlarının uygulandığı kod satırı.
            }
        }
    }
}
