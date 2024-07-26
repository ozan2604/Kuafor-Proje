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
	internal class AdminConfigürations : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
			builder.Property(x => x.AdminMail).IsRequired().HasMaxLength(50);
			builder.Property(x => x.AdminŞifre).IsRequired().HasMaxLength(50);
			builder.Property(x => x.AdminNo).IsRequired().HasMaxLength(50);
		}
	}
	
}
