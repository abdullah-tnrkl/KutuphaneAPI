using KutuphaneAPI.Application.DTOs;
using KutuphaneAPI.Domain.Entities;

namespace KutuphaneAPI.Application.Services
{
    public interface IOduncService
    {
        Task<KitapOdunc?> KitapOduncAlAsync(KitapOdunc odunc);
        Task<bool> KitapIadeEtAsync(int oduncId);
        Task<List<KitapOduncDto>> TumOduncIslemleriAsync();


        Task<Kitap?> GetKitapByIdAsync(int id);

    }
}
