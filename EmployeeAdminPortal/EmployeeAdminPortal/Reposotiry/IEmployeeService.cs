using EmployeeAdminPortal.Models;

namespace EmployeeAdminPortal.Reposotiry
{
    public interface IEmployeeService
    {
        //Retive Data
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(Guid id);
        Task<Employee> GetByName(string name);

        //Add new Employee
        Task<Employee> AddEmployee(Employee emp);


        // Edit Data Delete or Update
        Task<Employee> UpdateEmployeeData(Guid id, Employee emp);
        Task<bool> DeleteEmployeeData(Guid id);
    }
}