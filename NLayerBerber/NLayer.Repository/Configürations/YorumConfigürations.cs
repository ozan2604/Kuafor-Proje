using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configürations
{
	internal class YorumConfigürations : IEntityTypeConfiguration<Yorum>
	{
		public void Configure(EntityTypeBuilder<Yorum> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.YorumDetay).IsRequired().HasMaxLength(500);
			builder.Property(x => x.YorumTarih).IsRequired();
			builder.Property(x => x.KullaniciAdi).IsRequired();


		}
	}
}
