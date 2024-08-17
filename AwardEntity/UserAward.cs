using System.ComponentModel.DataAnnotations.Schema;
using AwardEntity.Base;

namespace AwardEntity
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
