using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configürations
{
	public class KuaförConfigüration : IEntityTypeConfiguration<Kuaför>
	{
		public void Configure(EntityTypeBuilder<Kuaför> builder)
		{

			builder.ToTable("Kuaför");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();

			builder.Property(x => x.KuaförName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.KuaförTel).IsRequired().HasMaxLength(50);

			builder.HasMany(x => x.Rezervasyon).WithOne(x => x.Kuaför).HasForeignKey(x => x.Kuaför_Id);
		}
	}
}
