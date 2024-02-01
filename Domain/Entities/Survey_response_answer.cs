using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_response_answer")]
    public class Survey_response_answer
    {
        [Key]
        public int Id { get; set; }

        public int Survey_response_id { get; set; }

        public int Answer_id { get; set; }

        [ForeignKey("Survey_response_id")]
        public virtual Survey_response SurveyResponse { get; set; }

        [ForeignKey("Answer_id")]
        public virtual Answer Answer { get; set; }
    }
}
