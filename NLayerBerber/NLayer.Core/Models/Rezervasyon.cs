namespace NLayer.Core.Models
{
	public class Rezervasyon : BaseEntity
	{
		public DateTime RezervasyonTarih { get; set; }
		public int Müşteri_Id  { get; set; }
		public int Kuaför_Id { get; set; }  

		public Müşteri Müşteri { get; set; }
		public Kuaför Kuaför { get; set; }
		public string musteriKullaniciAdi { get; set; }

	}
}
