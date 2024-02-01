using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Visit_request")]
    public class VisitRequest
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public bool Status { get; set; }

        public int VisitorId { get; set; }

        [ForeignKey("VisitorId")]
        public Account Visitor { get; set; }

        public int RequesterId { get; set; }

        [ForeignKey("RequesterId")]
        public Account Requester { get; set; }
    }
}
