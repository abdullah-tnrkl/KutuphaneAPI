using KutuphaneAPI.Domain.Entities;

namespace KutuphaneAPI.Application.Services
{
    public interface IKitapService
    {
        Task<List<Kitap>> TumKitaplariGetirAsync();
        Task<Kitap> KitapEkleAsync(Kitap kitap);

        Task<Kitap?> KitapGetirAsync(int id);
        Task<Kitap?> KitapGuncelleAsync(Kitap kitap);
        Task<bool> KitapSilAsync(int id);
    }
}
