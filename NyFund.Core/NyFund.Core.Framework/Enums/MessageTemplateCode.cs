using System.ComponentModel.DataAnnotations;

namespace NyFund.Core.Framework.Enums
{
    public enum MessageTemplateCode
    {
        [Display(Name = "Müşteri Kayıt")]
        CustomerRegister = 0,

        [Display(Name = "Müşeri Giriş")]
        CustomerLogin = 1,

        [Display(Name = "Müşteri Şifre Yenileme")]
        CustomerRenewPassword = 2,

        [Display(Name = "Müşteri Şifremi Unuttum")]
        CustomerForgotPassword = 3,

        [Display(Name = "Müşteri Yeniden Kod Gönder")]
        CustomerResendOtp = 4,

        [Display(Name = "Müşter Telefon Değişikliği Kod Gönder")]
        CustomerSetPhoneNumber = 5,

        [Display(Name = "Müşter Email Değişikliği Kod Gönder")]
        CustomerSetEmail = 6
    }
}
