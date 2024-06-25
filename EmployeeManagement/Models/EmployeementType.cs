using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeementType
    {
        [Key]
        public int EmployeementTypeId {  get; set; }
        [Required]
        public string EMployeementTypeName {  get; set; }
    }
}
