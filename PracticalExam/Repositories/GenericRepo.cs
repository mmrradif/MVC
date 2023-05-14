using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Context;
using PracticalExam.Interfaces;

namespace PracticalExam.Repositories
{
    public class GenericRepo<T> : IAll<T> where T : class
    {
        private readonly EmployeeDbContext _employeeDbContext;
        internal DbSet<T> _dbSet;

        public GenericRepo(EmployeeDbContext employeeDbContext)
        {
            this._employeeDbContext = employeeDbContext;
            this._dbSet = _employeeDbContext.Set<T>();
        }

        

        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                var result = await this._dbSet.ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task Insert(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                
                
            }
            catch (Exception)
            {

                throw;
            }
        }



        public virtual  Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }



        public async Task SaveChangesAsync()
        {
            try
            {
                await _employeeDbContext.SaveChangesAsync();
                Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public  void Dispose()
        {
            try
            {
                _employeeDbContext.Dispose();
                GC.SuppressFinalize(this);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
