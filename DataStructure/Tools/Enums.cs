using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataStructure.Tools
{
    public class Enums
    {
        public enum SliderProject : byte
        {
            [Display(Name = "انتخاب کنید")]
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

        public enum ApplicationType
        {
            [Display(Name = "انتخاب کنید")]
            [Description("")]
            None = 0,

            [Display(Name = "لباسشویی")]
            [Description("لباسشویی")]
            MachinCloth = 1,

            [Display(Name = "ظرفشویی")]
            [Description("ظرفشویی")]
            MachinDishe = 2,

            [Display(Name = "یخچال")]
            [Description("یخچال")]
            Frizeer = 3,

            [Display(Name = "ساید")]
            [Description("ساید")]
            Side = 4,

            [Display(Name = "ماکروفر")]
            [Description("ماکروفر")]
            Microfer = 5,

            [Display(Name = "جاروبرقی")]
            [Description("جاروبرقی")]
            JarooBarghi = 6,

            [Display(Name = "اجاق گاز")]
            [Description("اجاق گاز")]
            Gaz = 7,

            [Display(Name = "کولر")]
            [Description("کولر")]
            cooler = 8,

            [Display(Name = "سایر موارد")]
            [Description("سایر موارد")]
            ect = 9

        }
    }
}
