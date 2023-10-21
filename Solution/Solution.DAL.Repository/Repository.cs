using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Solution.DAL.EF;

namespace Solution.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
       
        protected readonly SolutionDbContext dbContext;
       
        public Repository(SolutionDbContext context)
        {
            dbContext = context;
        }

        public void AddRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().AddRange(t);
        }

        public IQueryable<T> AsQueryable()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Delete(T t)
        {
            try
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception ee)
            {

                
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            //Predicado es una expresion lambda que se tiene que cumplir para traer la info
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

       

        public T GetOneByMsg(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().FirstOrDefault(predicado);
        }

        public void Insert(T t)
        {
            if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else{
                dbContext.Set<T>().Add(t);

            }
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().RemoveRange(t);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Update(T t)
        {
            /*if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                dbContext.Set<T>().Attach(t);
            }*/
            
            dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            
        }

        public void UpdateRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().UpdateRange(t);
        }
    }
}
