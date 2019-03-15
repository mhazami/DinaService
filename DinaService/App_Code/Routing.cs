using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinaService.App_Code
{
    public static class Routing
    {
        public static string GetSlug(string slug)
        {
            if (!string.IsNullOrEmpty(slug))
            {
                return slug.Trim().Replace(" ", "-");
            }
            return string.Empty;
        }
    }
}