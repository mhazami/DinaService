using BLL;
using DataStructure;
using DinaService.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataStructure.Tools.Enums;

namespace DinaService.Areas.Admin.Controllers
{
    public class AdminBrandsController : BaseController
    {
        // GET: Admin/AdminBrands
        public ActionResult Index()
        {
            var list = new BrandsBO().GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brands brands, HttpPostedFileBase image)
        {
            try
            {
                if (!new BrandsBO().Insert(brands, image))
                {
                    ShowMessage("خطا در ثبت برند", MessageType.Error);
                    return RedirectToAction("Index");
                }
                ShowMessage("ثبت برند با موفقیت انجام شد", MessageType.Success);
                return View(new Brands());

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(brands);
            }
        }

        public ActionResult Edit(int id)
        {
            var brand = new BrandsBO().Get(id);
            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brands brands, HttpPostedFileBase image)
        {
            try
            {
                if (!new BrandsBO().Update(brands,image))
                {
                    ShowMessage("خطا در ویرایش برند", MessageType.Error);
                    return View(brands);
                }
                ShowMessage("ویرایش برند با موفقیت انجام شد", MessageType.Success);
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(brands);
            }
        }

        public ActionResult Delete(int id)
        {
            var brand = new BrandsBO().Get(id);
            return View(brand);
        }

        [HttpPost]
        public ActionResult Delete(Brands brands)
        {
            try
            {
                if (!new BrandsBO().Delete(brands))
                {
                    ShowMessage("خطا در حذف برند", MessageType.Error);
                    return View(brands);
                }
                ShowMessage("حذف برند با موفقیت انجام شد", MessageType.Success);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(brands);
            }
        }
    }
}