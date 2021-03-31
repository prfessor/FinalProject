using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result

    {
        public SuccessResult(string message) : base(true, message) //true verisini ve mesajını döndürür(iki veri döndüren result ile çalışır.)
        {

        }
        public SuccessResult() :base(true) // sadece true döndürür(tek veri döndüren Result ile çalışır.)
        {

        }
    }
}
