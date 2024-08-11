using System.ComponentModel.DataAnnotations.Schema;

namespace Award.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string BorderColor { get; set; }
        public string FontColor { get; set; }
        public string FontClass { get; set; }

        public Category Category { get; set; }
    }
}
