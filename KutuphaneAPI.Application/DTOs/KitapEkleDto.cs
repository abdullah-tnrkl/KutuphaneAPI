using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace KutuphaneAPI.Application.DTOs
{
    public class KitapEkleDto
    {
        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [MaxLength(100)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        [MaxLength(100)]
        public string Yazar { get; set; }

        [MaxLength(100)]
        public string? YayinEvi { get; set; }

        [Range(1, 5000, ErrorMessage = "Sayfa sayısı 1 ile 5000 arasında olmalı.")]
        public int SayfaSayisi { get; set; }

        [Range(0, int.MaxValue)]
        public int StokAdedi { get; set; }

        public IFormFile? Gorsel { get; set; }


    }
}
