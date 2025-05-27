using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneAPI.DataAccess.Context;
using KutuphaneAPI.Domain.Entities;

namespace KutuphaneAPI.Application.Services
{
    public interface ILogService
    {
        Task LogEkleAsync(string kullaniciAdi, string islemTuru, string entityAdi, string entityId, string detaylar);
    }

    public class LogService : ILogService
    {
        private readonly KutuphaneDbContext _context;

        public LogService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public async Task LogEkleAsync(string kullaniciAdi, string islemTuru, string entityAdi, string entityId, string detaylar)
        {
            var log = new IslemLogu
            {
                KullaniciAdi = kullaniciAdi,
                IslemTuru = islemTuru,
                EntityAdi = entityAdi,
                EntityId = entityId,
                Detaylar = detaylar,
                Tarih = DateTime.Now
            };

            _context.IslemLoglari.Add(log);
            await _context.SaveChangesAsync();
        }
    }

}
