﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string ImagesAdded="Görüntü başarıyla eklendi.";
        public static string ImageUploadLimitOver="Görüntü yükleme sınırı aşıldı";
        public static string UserRegistered = "Kayıt oluştu";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Hatalı parola.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
    }
}
