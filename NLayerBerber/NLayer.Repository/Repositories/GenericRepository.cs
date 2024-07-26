using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		protected readonly AppDbContext _context; //readonly: değer değişemez sabittir
		private readonly DbSet<T> _dbset;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
			_dbset = _context.Set<T>();
		}

		public async Task AddAsync(T entity)
		{
			await _dbset.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await _dbset.AddRangeAsync(entities);
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await _dbset.AnyAsync(expression);
		}

		public IQueryable<T> GetAll()
		{
			return _dbset.AsNoTracking().AsQueryable();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbset.FindAsync(id);
		}

		public void Remove(T entity)
		{
			_dbset.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_dbset.RemoveRange(entities);
		}

		public void Update(T entity)
		{
			_dbset.Update(entity);
		}

		public IQueryable<T> where(Expression<Func<T, bool>> expression)
		{
			return _dbset.Where(expression);
		}
	}
}
