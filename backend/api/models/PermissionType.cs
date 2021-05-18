
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.models
{
    [Table("PermissionTypes")]
    public class PermissionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        public virtual List<Permission> Permissions { get; set; }
    }
}