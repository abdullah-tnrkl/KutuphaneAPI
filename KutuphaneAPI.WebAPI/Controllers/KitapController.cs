using KutuphaneAPI.Application.DTOs;
using KutuphaneAPI.Application.Services;
using KutuphaneAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using KutuphaneAPI.Application.DTOs;
namespace KutuphaneAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitapController : ControllerBase
    {
        private readonly IKitapService _kitapService;

        public KitapController(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }

        [HttpGet]
        public async Task<IActionResult> TumKitaplariGetir()
        {
            var kitaplar = await _kitapService.TumKitaplariGetirAsync();
            return Ok(kitaplar);
        }

        [HttpPost]
        public async Task<IActionResult> KitapEkle([FromForm] KitapEkleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kitap = new Kitap
            {
                Ad = dto.Ad,
                Yazar = dto.Yazar,
                YayinEvi = dto.YayinEvi ?? "",
                SayfaSayisi = dto.SayfaSayisi,
                StokAdedi = dto.StokAdedi
            };

            if (dto.Gorsel != null && dto.Gorsel.Length > 0)
            {
                using var ms = new MemoryStream();
                await dto.Gorsel.CopyToAsync(ms);
                kitap.GorselVerisi = ms.ToArray();
            }

            var yeniKitap = await _kitapService.KitapEkleAsync(kitap);
            return CreatedAtAction(nameof(TumKitaplariGetir), new { id = yeniKitap.Id }, yeniKitap);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> KitapGetir(int id)
        {
            var kitap = await _kitapService.KitapGetirAsync(id);
            if (kitap == null) return NotFound();
            return Ok(kitap);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> KitapGuncelle(int id, [FromBody] Kitap kitap)
        {
            if (id != kitap.Id) return BadRequest("ID uyuşmuyor.");

            var guncellenen = await _kitapService.KitapGuncelleAsync(kitap);
            if (guncellenen == null) return NotFound();

            return Ok(guncellenen);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> KitapSil(int id)
        {
            var silindi = await _kitapService.KitapSilAsync(id);
            if (!silindi) return NotFound();
            return NoContent();
        }

    }
}
