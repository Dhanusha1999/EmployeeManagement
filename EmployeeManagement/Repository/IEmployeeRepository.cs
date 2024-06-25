using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        public void InsertEmployee(Employee employee);
        public IEnumerable<EmployeeViewModel> GetAllEmployees();
        public void UpdateEmployee(int id,Employee employee);  
        public void DeleteEmployee(int id);

        public IEnumerable<Department> GetAllDepartments();

        public IEnumerable<EmployeementType> GetEmployeementTypes();
        public IEnumerable<Gender> GetAllGender();
        public Employee GetEmployeeById(int id);
    }
}
