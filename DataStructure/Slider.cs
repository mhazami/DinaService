using System.ComponentModel.DataAnnotations;
using DataStructure.Tools;

namespace DataStructure
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        public virtual int FileId { get; set; }

        public virtual File File { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public Enums.SliderProject Place { get; set; }
    }
}
