using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DataStructure.Tools.Enums;

namespace DataStructure
{
    public class Content
    {
        [Key]
        public int Id { get; set; }

        public virtual int FileId { get; set; }

        //public virtual File File { get; set; }

        [Required(ErrorMessage = "لطفا عنوان مطلب را وارد کنید"), MaxLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات عکس را وارد کنید")]
        public string Alt { get; set; }

        public string KeyWords { get; set; }

        public string Slug { get; set; }

        public SliderProject Place { get; set; }

        public DateTime PublicDate { get; set; }

        [NotMapped]
        public string Link { get; set; }

        public int BrandsId { get; set; }

      

    }
}
