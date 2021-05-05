using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPrescription.Data.Interfaces
{
   public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);



        Task<T> GetById(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity,object key);

        Task<T> Delete(int id);

        Task<int> Count(Expression<Func<T, bool>> predicate);
    }
}
