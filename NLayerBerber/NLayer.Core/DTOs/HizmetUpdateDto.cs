using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
	public class HizmetUpdateDto
	{
        public int Id { get; set; }	
        public string HizmetAdı { get; set; }

		public string Detay { get; set; }

		public decimal Fiyat { get; set; }
	}
}
