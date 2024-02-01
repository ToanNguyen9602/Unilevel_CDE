using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
    }
}
