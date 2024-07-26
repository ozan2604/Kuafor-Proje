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
	internal class RezervasyonConfigüration : IEntityTypeConfiguration<Rezervasyon>
	{
		public void Configure(EntityTypeBuilder<Rezervasyon> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.RezervasyonTarih).IsRequired();

			builder.HasOne(x => x.Kuaför).WithMany(x => x.Rezervasyon);


		}
	}
}
