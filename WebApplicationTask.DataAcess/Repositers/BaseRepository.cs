using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTask.DataAcess.Data;
using WebApplicationTask.Models.Repository;

namespace WebApplicationTask.DataAcess.Repositers
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly AppDbContext _Context;
		public BaseRepository(AppDbContext Context)
		{
			_Context = Context;
		}

		public void Add(T entity)
		{
			_Context.Add(entity);
		}

		public T Find(Expression<Func<T, bool>> match)
		{
			return  _Context.Set<T>().FirstOrDefault(match) ;
		}

		public IEnumerable<T> GetAll()
		{
			return _Context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _Context.Set<T>().Find(id);	
		}

		public void Remove(T entity)
		{
			_Context.Remove(entity);
		}

		public void SaveChanges()
		{
			_Context.SaveChanges();
		}

		public void Update(T entity)
		{
			_Context.Update(entity);
		}
	}
}
