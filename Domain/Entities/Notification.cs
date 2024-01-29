using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Content { get; set; }

        public DateTime Created { get; set; }
    }
}
