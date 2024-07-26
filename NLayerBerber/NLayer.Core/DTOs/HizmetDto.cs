using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
	public class HizmetDto : BaseDto
	{
		public string HizmetAdı { get; set; }

		public string Detay { get; set; }

		public decimal Fiyat { get; set; }
	}
}
