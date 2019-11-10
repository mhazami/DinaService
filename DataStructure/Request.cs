using System.ComponentModel.DataAnnotations;
using static DataStructure.Tools.Enums;

namespace DataStructure
{
    public class Request
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(250), Required]
        public string Name { get; set; }

        [MaxLength(11), Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public ApplicationType ApplicationType { get; set; }

        public string Message { get; set; }

    }
}
