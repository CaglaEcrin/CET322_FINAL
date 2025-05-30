using System.ComponentModel.DataAnnotations;

namespace TailMeal.Models
{
    public class Siparis
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Adres zorunludur.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Telefon zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Ödeme türü seçilmelidir.")]
        public string OdemeTuru { get; set; }

        // Sadece kredi kartı seçilirse zorunlu olabilir ama şimdilik Required koymuyoruz
        public string? KartNumarasi { get; set; }
    }
}