using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneAPI.Domain.Entities
{
    public class IslemLogu
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string IslemTuru { get; set; }
        public string EntityAdi { get; set; }
        public string EntityId { get; set; }
        public DateTime Tarih { get; set; }
        public string Detaylar { get; set; }
    }

}
