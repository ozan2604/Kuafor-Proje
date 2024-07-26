using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
	public class YorumDto : BaseDto
	{
		public string KullaniciAdi { get; set; }
		public string YorumDetay { get; set; }

		public DateTime YorumTarih { get; set; }
		public int Like { get; set; }
		public int DisLike { get; set; }
	}
}
