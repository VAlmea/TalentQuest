using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		IQueryable<T> GetAll();
		Task<T> GetByIdAsync(Guid id);
		Task CreateAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
		void AddRange(IEnumerable<T> entities);
		Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
	}
}
