using System;
using System.ComponentModel.DataAnnotations;

namespace api.models.mv
{
    public class Permission
    {
        public class PermissionCreate
        {
            [Required(ErrorMessage = "Please enter the name of the employee")]
            [DataType(DataType.Text)]
            public string EmployeeNames { get; set; }
            [Required(ErrorMessage = "Please enter the employee's last name")]
            [DataType(DataType.Text)]
            public string EmployeeLastName { get; set; }
            [Required(ErrorMessage = "Please Indicate the type of permit")]
            public int PermissionType { get; set; }
            [Required(ErrorMessage = "Please indicate the date of the permit")]
            [DataType(DataType.Date)]
            public DateTime PermissionDate { get; set; }
        }

        public class PermissionUpdate
        {
            [Required(ErrorMessage = "Please indicate the permit ID")]
            public int Id { get; set; }
            [Required(ErrorMessage = "Please enter the name of the employee")]
            [DataType(DataType.Text)]
            public string EmployeeNames { get; set; }
            [Required(ErrorMessage = "Please enter the employee's last name")]
            [DataType(DataType.Text)]
            public string EmployeeLastName { get; set; }
            [Required(ErrorMessage = "Please Indicate the type of permit")]
            public int PermissionType { get; set; }
            [Required(ErrorMessage = "Please indicate the date of the permit")]
            [DataType(DataType.Date)]
            public DateTime PermissionDate { get; set; }
        }
    }
}