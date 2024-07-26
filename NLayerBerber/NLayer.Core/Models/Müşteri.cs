using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class Müşteri : BaseEntity
	{
		
		public string MüşteriName { get; set; }

		public string MüşteriTelNo { get; set; }

		public string MüşteriMail { get; set; }

		public string MüşteriŞifre { get; set; }
		public string KullaniciAdi { get; set; }

		public ICollection<Rezervasyon> Rezervasyon { get; set; }
		

	}
}
