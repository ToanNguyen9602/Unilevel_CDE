using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Notifi_user")]
    public class Notifi_user
    {
        [Key]
        public int Notification_id { get; set; }

        [Key]
        public int Staff { get; set; }

        [ForeignKey("Notification_id")]
        public Notification Notification { get; set; }

        [ForeignKey("Staff")]
        public Account Account { get; set; }
    }
}
