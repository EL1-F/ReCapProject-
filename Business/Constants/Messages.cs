using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi.";
        public static string DailyPriceInvalid = "Sıfırdan büyük bir değer giriniz.";
        public static string MaintenanceTime = "Bakım yapılmaktadır.";
        public static string Listed="Listeleme yapılmıştır";
        public static string Deleted = "Silindi.";
        public static string Updated = "Güncellendi.";
        public static string BrandNameInvalid = "En az iki karakter olmalıdır.";
        public static string Returned="Araç teslim edildi.";
        public static string NotReturned = "Araç henüz teslim ediledi.";
        public static string PasswordInvalid = "Geçersiz parola.";
    }
}
