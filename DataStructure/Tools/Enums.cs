using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataStructure.Tools
{
    public class Enums
    {
        public enum SliderProject : byte
        {
            [Display(Name = "سایت اصلی")]
            [Description("سایت اصلی")]
            Orgin = 0,
            [Display(Name = "برودتی")]
            [Description("برودتی")]
            Cool = 1,
            [Display(Name = "آشپزخانه")]
            [Description("آشپزخانه")]
            kitchen = 2,
            [Display(Name = "لباسشویی - ظرفشویی")]
            [Description("لباسشویی - ظرفشویی")]
            Wash = 3,
            [Display(Name = "جاروبرقی - ماکروفر")]
            [Description("جاروبرقی - ماکروفر")]
            Electric = 4,

        }
    }
}
