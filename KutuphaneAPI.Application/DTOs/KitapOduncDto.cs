namespace KutuphaneAPI.Application.DTOs
{
    public class KitapOduncDto
    {
        public int Id { get; set; }
        public string AlanKisiAd { get; set; }
        public string AlanKisiSoyad { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }
        public KitapDto Kitap { get; set; }
        public bool IadeEdildi { get; set; } // Yeni alan

    }
}
