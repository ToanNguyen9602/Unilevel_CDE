using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Survey_request")]
    public class Survey_request
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; }

        public DateTime Date_start { get; set; }

        public DateTime Date_end { get; set; }

        public bool Status { get; set; }

        public int Survey_id { get; set; }

        public int Receiver { get; set; }

        [ForeignKey("Survey_id")]
        public Survey Survey { get; set; }

        [ForeignKey("Receiver")]
        public Account ReceiverAccount { get; set; }
    }
}
