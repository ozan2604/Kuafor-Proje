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
    internal class İletişimConfigüration : IEntityTypeConfiguration<İletişim>
    {
        public void Configure(EntityTypeBuilder<İletişim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.İletişimNo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.İletişimMail).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Adres).IsRequired().HasMaxLength(250);
        }
    }
}
