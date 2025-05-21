using KutuphaneAPI.DataAccess.Context;
using KutuphaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.Application.Services
{
    public class KitapService : IKitapService
    {
        private readonly KutuphaneDbContext _context;

        public KitapService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kitap>> TumKitaplariGetirAsync()
        {
            return await _context.Kitaplar
                .Include(k => k.OduncBilgileri)
                .ToListAsync();
        }


        public async Task<Kitap> KitapEkleAsync(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();
            return kitap;
        }


        public async Task<Kitap?> KitapGetirAsync(int id)
        {
            return await _context.Kitaplar
                .Include(k => k.OduncBilgileri)
                .FirstOrDefaultAsync(k => k.Id == id);
        }


        public async Task<Kitap?> KitapGuncelleAsync(Kitap kitap)
        {
            var mevcutKitap = await _context.Kitaplar.FindAsync(kitap.Id);
            if (mevcutKitap == null) return null;

            mevcutKitap.Ad = kitap.Ad;
            mevcutKitap.Yazar = kitap.Yazar;
            mevcutKitap.YayinEvi = kitap.YayinEvi;
            mevcutKitap.SayfaSayisi = kitap.SayfaSayisi;
            mevcutKitap.StokAdedi = kitap.StokAdedi;

            await _context.SaveChangesAsync();
            return mevcutKitap;
        }

        public async Task<bool> KitapSilAsync(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null) return false;

            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
