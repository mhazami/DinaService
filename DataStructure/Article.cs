using System.ComponentModel.DataAnnotations;
using static DataStructure.Tools.Enums;

namespace DataStructure
{
    public class Article
    {
        [Key]
        [MaxLength(200)]
        public string Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Slug { get; set; }

        public int Video { get; set; }

        [MaxLength(4000)]
        public string Remark { get; set; }

        public SliderProject Position{ get; set; }

    }
}
