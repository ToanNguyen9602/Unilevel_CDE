using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_detail")]
    public class Survey_detail
    {
        [Key]
        public int Id { get; set; }

        public int Survey_id { get; set; }

        public int User { get; set; }

        [ForeignKey("Survey_id")]
        public Survey Survey { get; set; }

        [ForeignKey("User")]
        public Account UserAccount { get; set; }
    }
}
