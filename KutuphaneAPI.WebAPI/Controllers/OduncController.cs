using KutuphaneAPI.Application.DTOs;
using KutuphaneAPI.Application.Services;
using KutuphaneAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OduncController : ControllerBase
    {
        private readonly IOduncService _oduncService;

        public OduncController(IOduncService oduncService)
        {
            _oduncService = oduncService;
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> TumOduncIslemleri()
        {
            var liste = await _oduncService.TumOduncIslemleriAsync();
            return Ok(liste);
        }

        [HttpPost]
        public async Task<IActionResult> KitapOduncAl([FromBody] KitapOduncAlDto dto)
        {
            var kitap = await _oduncService.GetKitapByIdAsync(dto.KitapId);
            if (kitap == null || kitap.StokAdedi <= 0)
                return BadRequest("Kitap bulunamadı veya stok yok.");

            var odunc = new KitapOdunc
            {
                KitapId = dto.KitapId,
                AlanKisiAd = dto.AlanKisiAd,
                AlanKisiSoyad = dto.AlanKisiSoyad,
                IadeTarihi = dto.IadeTarihi,
                AlisTarihi = DateTime.Now
            };

            var sonuc = await _oduncService.KitapOduncAlAsync(odunc);
            return Ok(sonuc);
        }


        [HttpPost("iade/{oduncId}")]
        public async Task<IActionResult> KitapIadeEt(int oduncId)
        {
            var sonuc = await _oduncService.KitapIadeEtAsync(oduncId);
            if (!sonuc)
                return NotFound("İade edilebilecek bir ödünç işlemi bulunamadı.");
            return Ok("İade işlemi başarıyla tamamlandı.");
        }
    }
}
