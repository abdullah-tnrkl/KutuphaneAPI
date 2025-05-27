using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneAPI.Domain.Entities
{
    public class LogKaydi
    {
        public int Id { get; set; }
        public string IslemTipi { get; set; }  // Ekleme, Güncelleme, Silme
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public string Kullanici { get; set; } = "admin"; // Default kullanıcı
    }

}
