using KutuphaneAPI.DataAccess.Context;
using KutuphaneAPI.Domain.Entities;

public interface ILoglamaService
{
    Task LogEkleAsync(string islemTipi, string aciklama);
}

public class LoglamaService : ILoglamaService
{
    private readonly KutuphaneDbContext _context;

    public LoglamaService(KutuphaneDbContext context)
    {
        _context = context;
    }

    public async Task LogEkleAsync(string islemTipi, string aciklama)
    {
        var log = new LogKaydi
        {
            IslemTipi = islemTipi,
            Aciklama = aciklama,
            Tarih = DateTime.Now
        };

        _context.LogKayitlari.Add(log);
        await _context.SaveChangesAsync();
    }
}
