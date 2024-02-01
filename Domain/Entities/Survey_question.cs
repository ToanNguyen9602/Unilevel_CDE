using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_question")]
    public class Survey_question
    {
        [Key]
        public int Id { get; set; }

        public int Survey_id { get; set; }

        public int Question_id { get; set; }

        [ForeignKey("Survey_id")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("Question_id")]
        public virtual Question Question { get; set; }
    }
}
