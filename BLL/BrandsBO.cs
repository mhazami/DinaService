using DAL;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class BrandsBO : BusinessBase<Brands>
    {
        public bool Insert(Brands brands, HttpPostedFileBase image)
        {
            if (image == null)
            {
                throw new Exception("لطفا عکس برند را انتخاب کنید");
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

            brands.FileId = file.Id;
            return base.Insert(brands);
        }
        public bool Update(Brands brands, HttpPostedFileBase image)
        {
            bool isedit = true;
            if (image == null)
            {
                throw new Exception("لطفا عکس مطلب را انتخاب کنید");
            }

            File file = new FileBO().Get(brands.FileId);
            if (file == null)
            {
                file = new File
                {
                    Context = new byte[image.ContentLength]
                };
                isedit = false;
            }
            else
                file.Context = new byte[image.ContentLength];
            image.InputStream.Read(file.Context, 0, image.ContentLength);
            file.ContextType = image.ContentType;
            file.Title = image.FileName;
            file.FileSize = image.ContentLength / 1024;

            if (isedit)
            {
                if (!new FileBO().Update(file))
                {
                    throw new Exception("خطا در ویرایش تصویر");
                }
            }
            else
            {
                if (!new FileBO().Insert(file))
                {
                    throw new Exception("خطا در ویرایش تصویر");
                }
                brands.FileId = file.Id;
            }
            return base.Update(brands);
        }

        public override bool Delete(Brands brands)
        {
            var fileId = 0;
            if (brands.FileId != 0)
            {
                fileId = brands.FileId;
            }
            if (!base.Delete(brands))
                throw new Exception("خطا در حذف برند");
            if (fileId != 0)
                new FileBO().Delete(fileId);
            return true;
        }

    }


}
