using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> //hem sonuç verileri hem de diğer verileri içermesi için oluşturuldu.
                                                        //: Result ile sonuç verileri geldi. IDataResult ile de ana veriler.
    {
        public DataResult(T data, bool success, string message):base(success, message) /*base e yazınca ProductManager da bir daha yazmamıza    
            " 'base' burada Result sınıfını kastediyor, DataResult ın base'i Result dır yani."   gerek kalmıyor, default oluyor.*/
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success) //sadece bool verisi ve ana veriyi istersek bu çalışır.
        {
            Data = data;
        }
        public T Data { get; }
    }
}
