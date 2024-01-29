using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string File { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        public short Status { get; set; }

        public DateTime Date_start { get; set; }

        public DateTime Date_end { get; set; }

        [Required]
        public int Report { get; set; }

        [Required]
        public int Implement { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("Report")]
        public Account Reporter { get; set; }

        [ForeignKey("Implement")]
        public Account Implementer { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
