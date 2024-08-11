using AwardWeb.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwardWeb.Models
{
    public class UserAward : BaseEntity
    { 

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Award")]
        public int AwardId { get; set; }

        public User User { get; set; }
        public Award Award { get; set; }
    }
}
