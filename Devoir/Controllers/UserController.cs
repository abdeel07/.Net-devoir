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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(UserList.users);
        }

        public ActionResult Create(User user)
        {

            if (ModelState.IsValid == true)
            {
                user.CIN = Int32.Parse(Request.Form["CIN"]);
                user.name = Request.Form["name"];
                user.type = "Client";
                user.email = Request.Form["email"];
                user.password = Request.Form["password"];

                UserList.users.Add(user);

                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            
            if (Request.Form.Count > 0)
            {
                bool B = false;

                for (int i = 0; i < UserList.users.Count; i++)
                {
                    if(UserList.users[i].CIN == id)
                    {
                        B = true;
                        UserList.users[i].name = Request.Form["name"];
                        UserList.users[i].type = Request.Form["type"];
                        UserList.users[i].email = Request.Form["email"];
                        UserList.users[i].password = Request.Form["password"];
                        return RedirectToAction("Index");
                    }
                }
                if(B == false)
                    MessageBox.Show("Not found !");
            }
            
            return View();
        }

        public ActionResult Delete(int? id)
        {
            bool B = false;

            for (int i = 0; i < UserList.users.Count; i++)
            {
                if (UserList.users[i].CIN == id)
                {
                    B = true;
                    UserList.users.RemoveAt(i);
                    return RedirectToAction("Index");
                }
            }
            if (B == false)
                MessageBox.Show("Not found !");
            return View();
        }

        public ActionResult Detail(int? id)
        {
            bool B = false;

            for (int i = 0; i < UserList.users.Count; i++)
            {
                if (UserList.users[i].CIN == id)
                {
                    B = true;

                    return View(UserList.users[i]);
                }
            }
            if (B == false)
                MessageBox.Show("Not found !");

            return View();
        }

        public ActionResult ListProduct()
        {
            return View(ProductList.products);
        }

    }
}
