using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Distributor")]
    public class Distributor
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Phone { get; set; }

        [Required]
        public int Area_id { get; set; }

        [Required]
        public int Position_group { get; set; }

        [ForeignKey("Area_id")]
        public Area Area { get; set; }

        [ForeignKey("Position_group")]
        public Position_group PositionGroup { get; set; }
    }
}
