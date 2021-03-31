using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages //tüm uygulama boyunca tek instance kullanmak için "static yazarız.
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime =  "Bakım Çalışması Yapılıyor.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola yanlış.";
        public static string SuccessfulLogin = "Giriş başarılı." ;
        public static string UserAlreadyExists = "Kullanıcı zaten bulunuyor";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string CategoryAdded = "Kategori Eklendi";
    }
}
