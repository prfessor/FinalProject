using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success) //bu kod iki veri de istendiğinde bu constun yanında aşağıdakinin de çalışmasını sağlar.
                                                                  //sadec bunu isterse zaten sadece bu çalışır.
        {
            Message = message;   //Success de set yazmasa bile constructorlarda set edilebiliyor. ***ÖNEMLİ***
            //Success = success;

        }
        public Result(bool success) //BU OPSİYON DA KULLANILABİLİR, YANİ STRİNG OLMASI ŞART DEĞİL. AYRICA HEM SUCCESS HEM DE MESSAGE
                                    //İSTENDİĞİNDE İKİ CONSTRUCTOR DA ÇALIŞACAK. 
        {
              //Success de set yazmasa bile constructorlarda set edilebiliyor. ***ÖNEMLİ***
            Success = success;

        }

        public bool Success { get; }
     
        public string Message { get; }
    }
}
