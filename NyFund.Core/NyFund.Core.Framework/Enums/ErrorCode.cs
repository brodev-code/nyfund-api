
namespace NyFund.Core.Framework.Enums
{
    public enum ErrorCode
    {
        /// <summary>
        /// Başarılı
        /// </summary>
        Success = 0,

        /// <summary>
        /// Başarısız
        /// </summary>
        Failed = 1,

        /// <summary>
        /// Model Uyumsuz Hatası
        /// </summary>
        InputModelValidationError = 101,

        /// <summary>
        /// Veri Tutarsızlığı
        /// </summary>
        DataInconsistencyError = 102,

        /// <summary>
        /// Zaten Var
        /// </summary>
        AlreadyExist = 103,

        /// <summary>
        /// Kullanılıyor
        /// </summary>
        Used = 104,

        /// <summary>
        /// Kullanılmıyor
        /// </summary>
        NotUsed = 105,

        /// <summary>
        /// Olmalı
        /// </summary>
        ShouldBe = 106,

        /// <summary>
        /// Olamaz
        /// </summary>
        CanNot = 107,

        /// <summary>
        /// Bulunamadı
        /// </summary>
        NotFound = 108,

        /// <summary>
        /// Null Olamaz
        /// </summary>
        NotNull = 109,

        // <summary>
        /// Aktif Değil
        /// </summary>
        NotActive = 110,

        // <summary>
        /// Entegrasyon Hatası
        /// </summary>
        HttpClientProviderFailed = 111,

		AccessDenied = 112,


        PermissionOperationType = 300,
        InternalServerError = 500,


        /// <summary>
        /// Bilinmiyor
        /// </summary>
        Unknown = 999,
    }
}
