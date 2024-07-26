using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
	public class İletişim : BaseEntity
	{
		public string İletişimNo { get; set; }
		public string İletişimMail {  get; set; }

		public string Adres {  get; set; }
	}
}
