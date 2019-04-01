using BLL;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using static DataStructure.Tools.Enums;

namespace DinaService.Controllers
{
    public class XMLController : Controller
    {
        public ContentResult GetSiteMap()
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var contents = new ContentBO().GetSiteMapContent(SliderProject.Orgin);
            var sitemap = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
              new XElement(ns + "urlset", from item in contents select new XElement("url",
              new XElement("loc", item.Link),
              new XElement("changefreq", "monthly"),
              new XElement("priority", "0.5"))));
            return Content(sitemap.ToString(), "text/xml");
        }

        public ContentResult GetRSS()
        {
            var contents = new ContentBO().GetSiteMapContent(SliderProject.Orgin);
                        var rss = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
             new XElement("rss",
               new XAttribute("version", "2.0"),
                 new XElement("channel",
                   new XElement("title", "آخرین مطالب سایت دیناسرویس"),
                   new XElement("link", "http://dinaservice.com/feed.xml"),
                   new XElement("description", "آخرین مطالب سایت دیناسرویس"),
                   new XElement("copyright", "(c)" + DateTime.Now.Year + ", دینا سرویس.تمامی حقوق محفوظ است"),
                 from item in contents
                 select
                 new XElement("item",
                   new XElement("title", item.Title),
                   new XElement("description", item.Description),
                   new XElement("link", item.Link),
                   new XElement("pubDate", item.PublicDate)

                 )
               )
             )
           );
            return Content(rss.ToString(), "text/xml");
        }
    }
}