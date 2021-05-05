using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DigitalPrescription.Data.Interfaces;



namespace DigitalPrescription.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDb db;


        public Repository(AppDb db )
        {
            this.db=db;
        }
        

    public Task<int> Count(Expression<Func<T, bool>> predicate) =>db.Set<T>().CountAsync(predicate);


    public async Task<T> Create(T entity)
        {
          var result= await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }
     public async Task<T> Delete(int id)
        {
           var result=await GetById(id);
           if (result!=null)
           {
            db.Set<T>().Remove(result);
            await db.SaveChangesAsync();
            return result;
           }
            
           return null;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T,bool>> predicate)
        {
            return await db.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }



        public async Task<T> Update(T entity,object key)
        {
           if (entity==null)
              return null;
           T exist=await db.Set<T>().FindAsync(key); 
           if(exist!=null)
                db.Entry(exist).CurrentValues.SetValues(entity);
                await db.SaveChangesAsync();

           
           return exist; 
        }
        
    }
}