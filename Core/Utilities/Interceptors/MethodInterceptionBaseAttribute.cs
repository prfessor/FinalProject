using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //üstteki kodun anlamı: istenilen attribute class veya metodlara eklenebilir, 
    //birden fazla eklenebilir ve inherit işlemi yapılmış class ve metodlarda da kullanılabilir.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }


}
