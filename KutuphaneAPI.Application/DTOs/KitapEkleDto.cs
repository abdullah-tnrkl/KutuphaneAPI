using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace KutuphaneAPI.Application.DTOs
{
    public class KitapEkleDto
    {
        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [MaxLength(100)]
        public string ad { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        [MaxLength(100)]
        public string yazar { get; set; }

        [MaxLength(100)]
        public string? yayinEvi { get; set; }

        [Range(1, 5000, ErrorMessage = "Sayfa sayısı 1 ile 5000 arasında olmalı.")]
        public int sayfaSayisi { get; set; }

        [Range(0, int.MaxValue)]
        public int stokAdedi { get; set; }

        public IFormFile? gorselVerisi { get; set; }


    }
}
