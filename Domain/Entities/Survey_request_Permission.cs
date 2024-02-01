using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_resquest_Permission")]
    public class Survey_request_Permission
    {
        [Key]
        [Column(Order = 0)]
        public int Survey_request_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Permission_id { get; set; }

        [ForeignKey("Survey_request_id")]
        public virtual Survey_request Survey_request { get; set; }

        [ForeignKey("Permission_id")]
        public virtual Permission Permission { get; set; }
    }
}
