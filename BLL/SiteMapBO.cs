using DataStructure;
using System.Collections.Generic;
using System.Linq;
using static DataStructure.Tools.Enums;

namespace BLL
{
    public class SiteMapBO
    {
        public List<SiteMap> GetWashSiteMap()
        {
            List<SiteMap> result = new List<SiteMap>();
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
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/تعمیر-ماشین-ظرفشویی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/تعمیرات-ماشین-ظرفشویی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/تعمیر-ماشین-لباسشویی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/تعمیرات-ماشین-لباسشویی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/تعمیرات-لوازم-خانگی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/مرکز-تعمیر-لوازم-خانگی"
            });
            result.Add(new SiteMap()
            {
                Link = "http://wash.dinaservice.com/Content/Category/3/تعمیر-لوازم-خانگی"
            });
            List<Content> contents = new ContentBO().Where(c => c.Place == SliderProject.Wash);
            foreach (Content item in contents)
            {
                SiteMap obj = new SiteMap()
                {
                    Link = $"{url}/Content/Items/{item.Id}/{GetSlug(item.Slug)}"
                };
                result.Add(obj);
                List<string> keywords = item.KeyWords.Split(',').ToList();
                foreach (string key in keywords)
                {
                    SiteMap obj2 = new SiteMap()
                    {
                        Link = $"{url}/Content/Category/{item.Id}/{GetSlug(key)}"
                    };
                    result.Add(obj2);
                }
            }
            List<Brands> brands = new BrandsBO().GetAll();
            foreach (Brands item in brands)
            {
                SiteMap obj = new SiteMap()
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
