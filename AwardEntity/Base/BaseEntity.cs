using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AwardEntity.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime AddDate { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        public DateTime? UpdateDate { get; set; }
    }
}
