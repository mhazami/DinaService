using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataStructure.Tools
{
    public class Enums
    {
        public enum SliderProject : byte
        {
            [Display(Name = "")]
            [Description("")]
            None = 0,
            [Display(Name = "سایت اصلی")]
            [Description("سایت اصلی")]
            Orgin = 1,
            [Display(Name = "برودتی")]
            [Description("برودتی")]
            Cool = 2,
            [Display(Name = "آشپزخانه")]
            [Description("آشپزخانه")]
            kitchen = 3,
            [Display(Name = "لباسشویی - ظرفشویی")]
            [Description("لباسشویی - ظرفشویی")]
            Wash = 4,
            [Display(Name = "جاروبرقی - ماکروفر")]
            [Description("جاروبرقی - ماکروفر")]
            Electric = 5,

        }

        public enum MessageType
        {
            Error,
            Success,
            Warning,
            Primary,
            Defualt,
            Info
        }
    }
}
