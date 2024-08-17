using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AwardEntity.Base;

namespace AwardEntity
{
    public class Award :BaseEntity
    {  
        [Display(Name = "Başarım")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Display(Name = "Çerçeve Rengi")]
        public string BorderColor { get; set; }

        [Display(Name = "Yazı Rengi")]
        public string FontColor { get; set; }

        [Display(Name = "İkon Sınıfı")]
        public string FontClass { get; set; }

        public Category Category { get; set; } 
    }
}
