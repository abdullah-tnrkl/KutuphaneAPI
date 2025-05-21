namespace KutuphaneAPI.Application.DTOs
{
    public class KitapDto
    {
        public int ıd { get; set; }
        public string ad { get; set; }
        public string yazar { get; set; }
        public string? yayinEvi { get; set; }
        public int sayfaSayisi { get; set; }
        public int stokAdedi { get; set; }
    }
}
