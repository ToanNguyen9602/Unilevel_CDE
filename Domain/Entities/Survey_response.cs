using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_response")]
    public class Survey_response
    {
        [Key]
        public int Id { get; set; }

        public int Survey_id { get; set; }

        public int Account_id { get; set; }

        [ForeignKey("Survey_id")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("Account_id")]
        public virtual Account Account { get; set; }
    }
}
