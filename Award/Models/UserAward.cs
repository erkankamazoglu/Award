using System.ComponentModel.DataAnnotations.Schema;

namespace Award.Models
{
    public class UserAward
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Award")]
        public int AwardId { get; set; }

        public User User { get; set; }
        public Award Award { get; set; }
    }
}
