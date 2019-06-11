using BLL;
using DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using static DataStructure.Tools.Enums;

namespace Wash.Controllers
{
    public class XMLController : Controller
    {
        // GET: XML
        public ContentResult GetSiteMap()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            List<SiteMap> contents = new SiteMapBO().GetWashSiteMap();
            XDocument sitemap = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement(ns + "urlset", from item in contents
                                                                                                                   select new XElement("url",
new XElement("loc", item.Link),
new XElement("changefreq", "monthly"),
new XElement("priority", "0.5"))));


            var x = sitemap.ToString();
            string res = x.Replace("<url xmlns=\"\">", "<url>");
            builder.AppendLine(res);

            string path = Server.MapPath("~/Sitemap.xml");

            if (!System.IO.File.Exists(path))
            {
                using (FileStream fs = System.IO.File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(builder.ToString());
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                using (FileStream fs = System.IO.File.OpenWrite(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(builder.ToString());
                    fs.Write(info, 0, info.Length);
                }
            }

            return Content(builder.ToString(), "text/xml");
        }

        public ContentResult GetRSS()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");

            List<Content> contents = new ContentBO().GetSiteMapContent(SliderProject.Wash);
            XDocument rss = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
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

            builder.AppendLine(rss.ToString());

            string path = Server.MapPath("~/feed.xml");

            if (!System.IO.File.Exists(path))
            {
                using (FileStream fs = System.IO.File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(builder.ToString());
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                using (FileStream fs = System.IO.File.OpenWrite(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(builder.ToString());
                    fs.Write(info, 0, info.Length);
                }
            }

            return Content(rss.ToString(), "text/xml");
        }
    }
}