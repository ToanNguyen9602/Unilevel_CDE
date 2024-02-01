using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Visit")]
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        public int Time { get; set; }

        public DateTime DateTime { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Intent { get; set; }

        public short Status { get; set; }

        public int Creator { get; set; }

        public int? Guest { get; set; }

        public int DistributorId { get; set; }

        public int TaskId { get; set; }

        [ForeignKey("Creator")]
        public Account CreatorAccount { get; set; }

        [ForeignKey("Guest")]
        public Account GuestAccount { get; set; }

        [ForeignKey("DistributorId")]
        public Distributor Distributor { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
