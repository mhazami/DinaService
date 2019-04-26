using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructure.Tools.Enums;

namespace BLL
{
    public class SiteMapBO
    {
        public List<SiteMap> GetWashSiteMap()
        {
            var result = new List<SiteMap>();
            string url = "http://wash.dinaservice.com";
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/1/تعمیر-ماشین-لباسشویی",
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/2/تعمیر-ماشین-ظرفشویی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Home/AboutUs/1/درباره-دیناسرویس"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Home/ContactUs/1/تماس-با-دیناسرویس"
            });
            List<Content> contents = new ContentBO().Where(c => c.Place == SliderProject.Wash);
            foreach (Content item in contents)
            {
                var obj = new SiteMap()
                {
                    Link = $"{url}/Content/Items/{item.Id}/{GetSlug(item.Slug)}"
                };
                result.Add(obj);
                List<string> keywords = item.KeyWords.Split(',').ToList();
                foreach (var key in keywords)
                {
                    var obj2 = new SiteMap()
                    {
                        Link = $"{url}/Content/Category/{item.Id}/{GetSlug(key)}"
                    };
                    result.Add(obj2);
                }
            }
            var brands = new BrandsBO().GetAll();
            foreach (var item in brands)
            {
                var obj = new SiteMap()
                {
                    Link = $"{url}/Brands/List/{item.BrandsId}/{GetSlug(item.Slug)}"
                };
                result.Add(obj);
            }

            return result;


        }

        public string GetSlug(string slug)
        {
            slug = slug.Replace(" ", "-");
            return slug;
        }
    }
}
