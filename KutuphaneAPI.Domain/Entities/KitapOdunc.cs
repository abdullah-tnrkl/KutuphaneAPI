using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneAPI.Domain.Entities
{
    public class KitapOdunc
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public string AlanKisiAd { get; set; } = string.Empty;
        public string AlanKisiSoyad { get; set; } = string.Empty;
        public DateTime AlisTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }

        public Kitap Kitap { get; set; }

        public bool IadeEdildi { get; set; } = false; // Yeni alan
    }
}
