using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Rate")]
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        public short RateValue { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Comment { get; set; }

        public DateTime Created { get; set; }

        public int Rater { get; set; }

        public int Task_id { get; set; }

        [ForeignKey("Rater")]
        public Account RaterAccount { get; set; }

        [ForeignKey("Task_id")]
        public Task Task { get; set; }
    }
}
