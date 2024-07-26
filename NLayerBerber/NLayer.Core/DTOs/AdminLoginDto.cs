using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
	public class AdminLoginDto : BaseDto
	{
		public string AdminMail { get; set; }
		public string AdminŞifre { get; set; }
	}
}
