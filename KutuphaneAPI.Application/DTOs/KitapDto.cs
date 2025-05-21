namespace KutuphaneAPI.Application.DTOs
{
    public class KitapDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string? YayinEvi { get; set; }
        public int SayfaSayisi { get; set; }
        public int StokAdedi { get; set; }
    }
}
