using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get;  } //get = okuma işlemi, set = yazma işlemi. Burada sadece okuma yapıyoruz.
        string Message { get; }
        
    }
}
