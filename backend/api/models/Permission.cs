using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace api.models
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string EmployeeNames { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string EmployeeLastName { get; set; }
        [Required]
        public int PermissionType { get; set; }
        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime PermissionDate { get; set; }

        public virtual PermissionType Type { get; set; }
    }
}