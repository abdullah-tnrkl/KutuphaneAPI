using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneAPI.Application.DTOs
{
    public class KitapOduncAlDto
    {
        public int KitapId { get; set; }
        public string AlanKisiAd { get; set; }
        public string AlanKisiSoyad { get; set; }
        public DateTime IadeTarihi { get; set; }
    }
}
