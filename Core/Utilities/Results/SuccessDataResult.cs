using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) //kullanıcıdan tüm veriler istenir.
        {

        }
        public SuccessDataResult(T data) : base(data, true) //kullanıcıdan sadece data istenir, bool default verilir, message verilmez.
        {

        }
        public SuccessDataResult(string message) : base(default, true, message) //burada data ve bool default olarak döndürülür. message istenir.
        {

        }
        public SuccessDataResult():base(default,true) //data ve bool default, message yok.
        {

        }
    
        
    }
}
