using System.Collections.Generic;

namespace NLayer.Core.Models
{
	public class Kuaför : BaseEntity
	{
		public string KuaförName { get; set; }
		public string KuaförTel { get; set; }
		public ICollection<Rezervasyon> Rezervasyon { get; set; }
	}
}
