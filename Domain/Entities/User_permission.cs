using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("User_permission")]
    public class User_permission
    {
        [Key]
        [Column(Order = 0)]
        public int Account_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Permission_id { get; set; }

        [ForeignKey("Account_id")]
        public virtual Account Account { get; set; }

        [ForeignKey("Permission_id")]
        public virtual Permission Permission { get; set; }
    }
}
