using KutuphaneAPI.Application.DTOs;
using KutuphaneAPI.DataAccess.Context;
using KutuphaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Application.Services
{
    public class OduncService : IOduncService
    {
        private readonly KutuphaneDbContext _context;

        public OduncService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public async Task<KitapOdunc?> KitapOduncAlAsync(KitapOdunc odunc)
        {
            var kitap = await _context.Kitaplar.FindAsync(odunc.KitapId);
            if (kitap == null || kitap.StokAdedi <= 0)
                return null;

            kitap.StokAdedi -= 1;
            odunc.AlisTarihi = DateTime.Now;
            _context.KitapOduncIslemleri.Add(odunc);
            await _context.SaveChangesAsync();
            return odunc;
        }

        public async Task<bool> KitapIadeEtAsync(int oduncId)
        {
            var odunc = await _context.KitapOduncIslemleri
                .Include(o => o.Kitap)
                .FirstOrDefaultAsync(o => o.Id == oduncId);

            if (odunc == null || odunc.IadeTarihi != null)
                return false;

            odunc.IadeTarihi = DateTime.Now;
            odunc.Kitap.StokAdedi += 1;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Kitap?> GetKitapByIdAsync(int id)
        {
            return await _context.Kitaplar.FindAsync(id);
        }

        public async Task<List<KitapOduncDto>> TumOduncIslemleriAsync()
        {
            return await _context.KitapOduncIslemleri
                .Include(x => x.Kitap)
                .Select(x => new KitapOduncDto
                {
                    Id = x.Id,
                    AlanKisiAd = x.AlanKisiAd,
                    AlanKisiSoyad = x.AlanKisiSoyad,
                    AlisTarihi = x.AlisTarihi,
                    IadeTarihi = x.IadeTarihi,
                    Kitap = new KitapDto
                    {
                        Id = x.Kitap.Id,
                        Ad = x.Kitap.Ad,
                        Yazar = x.Kitap.Yazar,
                        YayinEvi = x.Kitap.YayinEvi,
                        SayfaSayisi = x.Kitap.SayfaSayisi
                    }
                })
                .ToListAsync();
        }

    }
}
