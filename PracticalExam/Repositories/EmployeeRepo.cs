using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Context;
using PracticalExam.Database_Models;

namespace PracticalExam.Repositories
{
    public class EmployeeRepo : GenericRepo<Employee>
    {
        public EmployeeRepo(EmployeeDbContext employeeDbContext) : base(employeeDbContext)
        {
        }

        public override async Task<Employee> GetById(int id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);           
            return result;        
        }



        public override async Task<bool> Update(Employee entity)
        {
            var existingData = await this.GetById(entity.Id);
            if (existingData != null)
            {
                existingData.FirstName = entity.FirstName;
                existingData.lastName = entity.lastName;
                existingData.BirthDate= entity.BirthDate;
                existingData.Salary= entity.Salary;
                existingData.IsManger = entity.IsManger;

                return true;

            }
            return false;
        }



        public override async Task<bool> Delete(int id)
        {
            var dataExists = await this.GetById(id);
            if (dataExists != null)
            {
                _dbSet.Remove(dataExists);
                return true;
            }
            return false;
        }
    }
}
