using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_campaign")]
    public class Survey_campaign
    {
        [Key]
        public int Id { get; set; }

        public int Survey_id { get; set; }

        public int Campaign_id { get; set; }

        [ForeignKey("Survey_id")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("Campaign_id")]
        public virtual Campaign Campaign { get; set; }
    }
}
