using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly TalentQuestDbContext _context;

		public GenericRepository(TalentQuestDbContext context)
		{
			_context = context;
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_context.Set<T>().AddRange(entities);
		}

		public async Task CreateAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_context.Remove(entity);
		}

		public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
		{
			return await _context.Set<T>().Where(match).ToListAsync();
		}

		public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>().FirstOrDefaultAsync(predicate);			
		}

		public IQueryable<T> GetAll()
		{
			return _context.Set<T>();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _context.Set<T>().FindAsync(id);
		}


		public void Update(T entity)
		{			
			_context.Update(entity);
		}
	}
}
