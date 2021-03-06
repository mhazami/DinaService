﻿using BLL;
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
    public class AdminContentController : BaseController
    {
        // GET: Admin/AdminContent
        public ActionResult Index()
        {
            var list = new ContentBO().GetAll();
            return View(list);
        }



        public ActionResult Create()
        {
            ViewBag.BrandsId = new SelectList(new BrandsBO().GetAll(), "BrandsId", "Title");
            return View(new Content());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Content content, HttpPostedFileBase image)
        {
            ViewBag.BrandsId = new SelectList(new BrandsBO().GetAll(), "BrandsId", "Title");

            try
            {
                if (!new ContentBO().Insert(content, image))
                {
                    ShowMessage("خطا دز ثبت مطلب", MessageType.Error);
                    return View(content);
                }
                ShowMessage("ثبت مطلب با موفقیت انجام شد", MessageType.Success);
                return View(new Content());

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(content);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.BrandsId = new SelectList(new BrandsBO().GetAll(), "BrandsId", "Title");

            var content = new ContentBO().Get(id);
            return View(content);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Content content, HttpPostedFileBase image)
        {
            try
            {
                ViewBag.BrandsId = new SelectList(new BrandsBO().GetAll(), "BrandsId", "Title");

                if (!new ContentBO().Update(content, image))
                {
                    ShowMessage("خطا دز ویرایش مطلب", MessageType.Error);
                    return View(content);
                }
                ShowMessage("ویرایش مطلب با موفقیت انجام شد", MessageType.Success);
                return View(content);

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(content);
            }
        }

        public ActionResult Details(int id)
        {
            var content = new ContentBO().Get(id);
            return View(content);
        }

        public ActionResult Delete(int id)
        {
            var content = new ContentBO().Get(id);
            return View(content);
        }

        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            var id = int.Parse(collection["Id"]);
            try
            {
                if (!new ContentBO().Delete(id))
                {
                    ShowMessage("خطا در حذف مطلب", MessageType.Error);
                    return View(id);
                }
                ShowMessage("خطا مطلب با موفقیت انجام شد", MessageType.Success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
                return View(id);
            }
        }
    }
}