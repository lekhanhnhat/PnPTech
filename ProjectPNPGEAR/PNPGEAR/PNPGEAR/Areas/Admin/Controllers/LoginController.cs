using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using PNPGEAR.Areas.Admin.Models;
using Models.Framework;
using System.Web.Security;
using Models.DAO;
using PNPGEAR.Common;

namespace PNPGEAR.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var admin = dao.GetById(model.UserName);
                    var adminSession = new AdminLogin();
                    adminSession.AdminName = admin.Username;
                    adminSession.AdminID = admin.AdminID;


                    Session.Add(CommonConstants.ADMIN_SESSION, adminSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mat khau khong dung.");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap khong dung.");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}