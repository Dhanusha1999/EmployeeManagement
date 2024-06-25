using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId {  get; set; }
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Salary {  get; set; }
        [ForeignKey("Gender")]
        public int GenderId {  get; set; }
        [ForeignKey("Department")]
        public int DepartmentId {  get; set; }
        [ForeignKey("EmployeementType")]
        public int EmployeementTypeId {  get; set; }
    }
}
