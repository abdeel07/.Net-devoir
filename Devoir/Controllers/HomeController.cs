using Devoir.Models;
using Devoir.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Devoir.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = new User();
            user.CIN = 1;
            user.name = "admin";
            user.type = "Admin";
            user.email = "admin@.com";
            user.password = "123";

            UserList.users.Add(user);
            return View();
        }

        public ActionResult Login()
        {
            if (Request.Form.Count > 0)
            {
                bool B = false;

                for (int i = 0; i < UserList.users.Count; i++)
                {
                    if (UserList.users[i].email == Request.Form["email"] && UserList.users[i].password == Request.Form["password"])
                    {
                        B = true;

                        if (UserList.users[i].type == "Client")
                            return RedirectToAction("ListProduct", "User");
                        else if(UserList.users[i].type == "Admin")
                            return RedirectToAction("Index", "Product");
                    }
                }
                if (B == false)
                    MessageBox.Show("Not found !");
            }

            return View();
        }
    }
}