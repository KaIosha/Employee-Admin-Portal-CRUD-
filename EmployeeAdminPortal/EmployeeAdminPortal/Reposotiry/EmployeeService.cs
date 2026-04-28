using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Reposotiry
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;

        }

        public async Task<Employee> AddEmployee(Employee emp)
        {
            await _db.Employees.AddAsync(emp);
            await _unitOfWork.Save();
            return emp;
        }

        public async Task<bool> DeleteEmployeeData(Guid id)
        {
            var Emp = await _db.Employees.FindAsync(id);
            if (Emp == null)
            {
                throw new InvalidOperationException($"Employee with Id '{id}' not found.");
            }
            _db.Employees.Remove( Emp );
            await _unitOfWork.Save();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(Guid id)
        {
            var emp = await _db.Employees.FindAsync(id);
            if (emp == null)
            {
                throw new InvalidOperationException($"Employee with Id '{id}' not found.");
            }

            return emp;
        }


        public async Task<Employee> GetByName(string name)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(e => e.Name == name);
            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with name '{name}' not found.");
            }
            return employee;
        }

        public async Task<Employee> UpdateEmployeeData(Guid id,Employee emp)
        {
            var getEmp = await _db.Employees.FindAsync(id);
            if (getEmp == null)
            {
              throw new InvalidOperationException($"Employee with id '{id}' not found.");
            }
            getEmp.Name = emp.Name;
            getEmp.Salary= emp.Salary;
            getEmp.Email = emp.Email;
            getEmp.Phone = emp.Phone;

            await _unitOfWork.Save();
            return getEmp;

        }

 
    }
}
