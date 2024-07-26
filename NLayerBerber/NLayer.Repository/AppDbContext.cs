using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Hizmet> Hizmets { get; set;}

		public DbSet<İletişim>İletişims { get; set; }
		public DbSet<Kuaför> Kuaförs { get; set; }	
		public DbSet<Müşteri> Müşteris { get; set; }
		public DbSet<Rezervasyon> Rezervasyons { get; set; }	
		public DbSet<Yorum> Yorums { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			
			base.OnModelCreating(modelBuilder);
		}


	}
}
