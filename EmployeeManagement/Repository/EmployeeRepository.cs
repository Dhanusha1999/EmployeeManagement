using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //connectionstring

        private readonly string connectionStringName;
        public EmployeeRepository(IConfiguration configuration)
        {
            connectionStringName = configuration.GetConnectionString("EmployeeCRUD");
        }
        public void DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                List<Department> departmentList = new List<Department>();
                using (SqlConnection connection = new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllDepartments", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                        department.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                        departmentList.Add(department);
                    }
                    connection.Close();
                    return departmentList;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
                using(SqlConnection connection=new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployee", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        EmployeeViewModel employee = new EmployeeViewModel();
                        
                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.FirstName = Convert.ToString(reader["FirstName"]);
                        employee.LastName = Convert.ToString(reader["LastName"]);
                        employee.Salary = Convert.ToInt32(reader["Salary"]);
                        employee.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                        employee.EmployeementTypeName = Convert.ToString(reader["EmployeementTypeName"]);
                        employee.Gender = Convert.ToString(reader["GenderName"]);


                        employeeList.Add(employee);
                    }
                    connection.Close();
                    return employeeList;
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployeeById", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Employee employee = null;

                    if (reader.Read())
                    {
                        employee = new Employee();

                        employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                        employee.FirstName = Convert.ToString(reader["FirstName"]);
                        employee.LastName = Convert.ToString(reader["LastName"]);
                        employee.Salary = Convert.ToInt32(reader["Salary"]);
                        employee.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                        employee.EmployeementTypeId = Convert.ToInt32(reader["EmployeementTypeId"]);
                        employee.GenderId = Convert.ToInt32(reader["GenderId"]);
                    }

                    connection.Close();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<Gender> GetAllGender()
        {
            try
            {
                List<Gender> genderList = new List<Gender>();
                using (SqlConnection connection = new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllGender", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Gender gender = new Gender();
                        gender.GenderId= Convert.ToInt32(reader["GenderId"]);
                        gender.GenderName = Convert.ToString(reader["GenderName"]);
                        genderList.Add(gender);
                    }
                    connection.Close();
                    return genderList;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<EmployeementType> GetEmployeementTypes()
        {
            try
            {
                List<EmployeementType> typeList = new List<EmployeementType>();
                using (SqlConnection connection = new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployeementType", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeementType type = new EmployeementType();
                        type.EmployeementTypeId = Convert.ToInt32(reader["EmployeementTypeId"]);
                        type.EMployeementTypeName = Convert.ToString(reader["EmployeementTypeName"]);
                        typeList.Add(type);
                    }
                    connection.Close();
                    return typeList;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void InsertEmployee(Employee employee)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd=new SqlCommand("spInsertEmployee", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@deptId", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@emptypeId", employee.EmployeementTypeId);
                    cmd.Parameters.AddWithValue("@genderId", employee.GenderId);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringName))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@firstname", employee.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", employee.LastName);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@deptId", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@emptypeId", employee.EmployeementTypeId);
                    cmd.Parameters.AddWithValue("@genderId", employee.GenderId);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
      
    }
}
