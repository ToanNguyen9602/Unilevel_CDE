using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Campaign_user")]
    public class CampaignUser
    {
        [Key]
        public int Campaign_id { get; set; }

        [Key]
        public int Account_id { get; set; }

        [ForeignKey("Campaign_id")]
        public Campaign Campaign { get; set; }

        [ForeignKey("Account_id")]
        public Account Account { get; set; }
    }
}
