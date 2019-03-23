using DataStructure.Tools;
using System.Web.Mvc;

namespace DinaService.AppCode
{
    public class BaseController : Controller
    {
        public void ShowMessage(string message, Enums.MessageType messageType)
        {
            string script = string.Empty;
            switch (messageType)
            {
                case Enums.MessageType.Defualt:
                    script += $"ShowDefualtMessage('','{message}')";
                    break;
                case Enums.MessageType.Error:
                    script += $"ShowErrorMessage('خطا!','{message}')";
                    break;

                case Enums.MessageType.Info:
                    script += $"ShowInfoMessage('','{message}')";
                    break;
                case Enums.MessageType.Primary:
                    script += $"ShowPrimaryMessage('','{message}')";
                    break;
                case Enums.MessageType.Success:
                    script += $"ShowSuccessMessage('عملیات با موفقیت انجام شد','{message}')";
                    break;
                case Enums.MessageType.Warning:
                    script += $"ShowWarningMessage('توجه!','{message}')";
                    break;
            }
            ViewBag.Message = script;

        }
    }
}