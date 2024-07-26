using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
	public class RezervasyonUpdateDto
	{
		public int Id { get; set; }
		public DateTime RezervasyonTarih { get; set; }
		public int Müşteri_Id { get; set; }
		public int Kuaför_Id { get; set; }

		public string musteriKullaniciAdi { get; set; }
	}
}
