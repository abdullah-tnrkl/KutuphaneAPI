using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneAPI.Domain.Entities
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Yazar { get; set; } = string.Empty;
        public string YayinEvi { get; set; } = string.Empty;
        public int SayfaSayisi { get; set; }
        public int StokAdedi { get; set; }
        public byte[]? GorselVerisi { get; set; }

        public string? Ozet { get; set; }

        // Ödünç alındıysa bilgileri tutulacak
        public ICollection<KitapOdunc> OduncBilgileri { get; set; }
    }
}
