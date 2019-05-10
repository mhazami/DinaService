using DAL;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DataStructure.Tools.Enums;

namespace BLL
{
    public class ContentBO : BusinessBase<Content>
    {
        public List<Content> GetSiteMapContent()
        {
            List<Content> list = base.GetAll();
            string url = string.Empty;
            foreach (Content item in list)
            {
                switch (item.Place)
                {
                    case SliderProject.Orgin:
                        if (string.IsNullOrEmpty(item.Link))
                        {
                            url = "http://dinaservice.com";
                            item.Link = $"{url}/{item.Id}/{GetSlug(item.Slug)}";
                        }
                        break;
                    case SliderProject.Cool:
                        url = "http://cool.dinaservice.com";
                        item.Link = $"{url}/{item.Id}/{GetSlug(item.Slug)}";
                        break;
                    case SliderProject.kitchen:
                        url = "http://kitchen.dinaservice.com";
                        item.Link = $"{url}/{item.Id}/{GetSlug(item.Slug)}";
                        break;
                    case SliderProject.Wash:
                        url = "http://Wash.dinaservice.com";
                        item.Link = $"{url}/{item.Id}/{GetSlug(item.Slug)}";
                        break;
                    case SliderProject.Electric:
                        url = "http://electric.dinaservice.com";
                        item.Link = $"{url}/{item.Id}/{GetSlug(item.Slug)}";
                        break;

                }
            }
            return list;
        }

        public bool Update(Content content, HttpPostedFileBase image)
        {
            if (image != null)
            {
                File oldfile = new FileBO().Get(content.FileId);
                File file = null;
                if (oldfile == null)
                {
                    file = new File();
                }
                else
                {
                    file = oldfile;
                }

                file.Context = new byte[image.ContentLength];
                image.InputStream.Read(file.Context, 0, image.ContentLength);
                file.ContextType = image.ContentType;
                file.Title = image.FileName;
                file.FileSize = image.ContentLength / 1024;
                if (oldfile == null)
                {
                    if (!new FileBO().Insert(file))
                    {
                        throw new Exception("خطا در ویرایش تصویر");
                    }
                    content.FileId = file.Id;
                }
                else
                {
                    if (!new FileBO().Update(file))
                    {
                        throw new Exception("خطا در ویرایش تصویر");
                    }
                }
               

            }


            return base.Update(content);
        }

        public bool Insert(Content content, HttpPostedFileBase image)
        {
            if (image == null)
            {
                throw new Exception("لطفا عکس مطلب را انتخاب کنید");
            }

            File file = new File
            {
                Context = new byte[image.ContentLength]
            };
            image.InputStream.Read(file.Context, 0, image.ContentLength);
            file.ContextType = image.ContentType;
            file.Title = image.FileName;
            file.FileSize = image.ContentLength / 1024;

            if (!new FileBO().Insert(file))
            {
                throw new Exception("خطا در ثبت تصویر");
            }

            content.FileId = file.Id;
            return Insert(content);

        }

        public List<Content> GetSiteMapContent(SliderProject place)
        {
            List<Content> list = base.Where(c => c.Place == place);
            string url = string.Empty;
            if (place != SliderProject.Orgin)
            {
                url = $"http://{place.ToString().ToLower()}.dinaservice.com";
            }
            else
            {
                url = $"http://dinaservice.com";
            }

            foreach (Content item in list)
            {
                if (string.IsNullOrEmpty(item.Link))
                {
                    item.Link = $"{url}/Content/Items/{item.Id}/{GetSlug(item.Slug)}";
                }
            }
            return list;
        }

        public string GetSlug(string slug)
        {
            slug = slug.Replace(" ", "-");
            return slug;
        }

        public override bool Insert(Content obj)
        {
            string url = string.Empty;
            obj.PublicDate = DateTime.Now;


            return base.Insert(obj);
        }

        public override void CheckConstraint(Content obj)
        {
            if (string.IsNullOrEmpty(obj.Title))
            {
                throw new Exception("لطفا عنوان مطلب را وارد کنید");
            }

            if (string.IsNullOrEmpty(obj.KeyWords))
            {
                throw new Exception("لطفا کلمات کلیدی مطلب را وارد کنید");
            }

            if (string.IsNullOrEmpty(obj.Slug))
            {
                throw new Exception("لطفا توصیحات آدرس مطلب را وارد کنید");
            }

            if (string.IsNullOrEmpty(obj.Description))
            {
                throw new Exception("لطفا توضیحات مطلب را وارد کنید");
            }

            if (string.IsNullOrEmpty(obj.Alt))
            {
                throw new Exception("لطفا توضیحات تصویر مطلب را وارد کنید");
            }

            if (obj.Place == SliderProject.None)
            {
                throw new Exception("لطفا عنوان مطلب را وارد کنید");
            }
            string url = string.Empty;
            obj.PublicDate = DateTime.Now;
        }

        public List<string> GetKeyWord(string keywords)
        {
            List<string> list = keywords.Split('-').ToList();
            return list;
        }
    }
}
