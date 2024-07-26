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
	internal class HizmetConfigüration : IEntityTypeConfiguration<Hizmet>
	{
	

		public void Configure(EntityTypeBuilder<Hizmet> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.HizmetAdı).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Detay).IsRequired().HasMaxLength(500);
			builder.Property(x => x.Fiyat).IsRequired();
		}
	}
}
