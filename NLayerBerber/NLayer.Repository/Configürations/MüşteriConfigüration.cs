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
	public class MüşteriConfigüration : IEntityTypeConfiguration<Müşteri>
	{
		public void Configure(EntityTypeBuilder<Müşteri> builder)
		{
			builder.ToTable("Müşteri");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.MüşteriName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.MüşteriTelNo).IsRequired().HasMaxLength(50);
			builder.Property(x => x.MüşteriMail).IsRequired().HasMaxLength(50);
			builder.Property(x => x.MüşteriŞifre).IsRequired().HasMaxLength(50);
			builder.Property(x => x.KullaniciAdi).IsRequired().HasMaxLength(50);

			builder.HasMany(x => x.Rezervasyon).WithOne(x => x.Müşteri).HasForeignKey(x => x.Müşteri_Id);

			// builder.HasMany(x => x.Rezervasyon).WithOne(x => x.Kuaför).HasForeignKey(x => x.Kuaför_Id);
		}

		
			
		}
}
