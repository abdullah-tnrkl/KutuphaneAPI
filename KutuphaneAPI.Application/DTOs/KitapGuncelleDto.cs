using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KutuphaneAPI.Application.DTOs
{
    public class KitapGuncelleDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string? YayinEvi { get; set; }
        public int SayfaSayisi { get; set; }
        public int StokAdedi { get; set; }
        public IFormFile? GorselVerisi { get; set; }

        public string? Ozet { get; set; }  // 
    }
}
