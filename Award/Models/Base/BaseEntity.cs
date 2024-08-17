using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AwardWeb.Models.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime AddDate { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        public DateTime? UpdateDate { get; set; }
    }
}
