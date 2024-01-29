using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Fullname { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Photo { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime Created { get; set; }

        public int Area_id { get; set; }

        public int Position_group { get; set; }

        [ForeignKey("Area_id")]
        public Area Area { get; set; }

        [ForeignKey("Position_group")]
        public Position_group PositionGroup { get; set; }
    }
}
