﻿using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PNPGEAR.Common;
using PagedList;
namespace PNPGEAR.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page=1,int pageSize=1)
        {
            var dao = new UserDao();

            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SeachString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Them user khong thanh cong");
                }
            }
            return View("Index");
        }
        public ActionResult Details(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhat user khong thanh cong");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}