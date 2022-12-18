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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(ProductList.products);
        }

        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid == true)
            {
                product.ID = Int32.Parse(Request.Form["ID"]);
                product.name = Request.Form["name"];
                product.type = Request.Form["type"];
                product.prix = float.Parse(Request.Form["prix"]);
                product.qstock = Int32.Parse(Request.Form["qstock"]);
                product.dateAjout = DateTime.Now;

                ProductList.products.Add(product);


                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (Request.Form.Count > 0)
            {
                bool B = false;

                for (int i = 0; i < ProductList.products.Count; i++)
                {
                    if (ProductList.products[i].ID == id)
                    {
                        B = true;
                        ProductList.products[i].name = Request.Form["name"];
                        ProductList.products[i].type = Request.Form["type"];
                        ProductList.products[i].prix = float.Parse(Request.Form["prix"]);
                        ProductList.products[i].qstock = Int32.Parse(Request.Form["qstock"]);
                        return RedirectToAction("Index");
                    }
                }
                if (B == false)
                    MessageBox.Show("Not found !");
            }

            for (int i = 0; i < ProductList.products.Count; i++)
            {
                if (ProductList.products[i].ID == id)
                {

                    return View(ProductList.products[i]);
                }
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            bool B = false;

            for (int i = 0; i < ProductList.products.Count; i++)
            {
                if (ProductList.products[i].ID == id)
                {
                    B = true;
                    ProductList.products.RemoveAt(i);
                    return RedirectToAction("Index");
                }
            }
            if (B == false)
                MessageBox.Show("Not found !");
            return View();
        }

        public ActionResult Details(int? id)
        {
            bool B = false;

            for (int i = 0; i < ProductList.products.Count; i++)
            {
                if (ProductList.products[i].ID == id)
                {
                    B = true;

                    return View(ProductList.products[i]);
                }
            }
            if (B == false)
                MessageBox.Show("Not found !");

            return View();
        }

        public ActionResult Search()
        {
            if (Request.Form.Count > 0)
            {
                bool B = false;
                int id = Int32.Parse(Request.Form["ID"]);

                for (int i = 0; i < ProductList.products.Count; i++)
                {
                    if (ProductList.products[i].ID == id)
                    {
                        B = true;

                        return RedirectToAction("Details", new { id = id });
                    }
                }
                if (B == false)
                    MessageBox.Show("Not found !");
            }

            return View();
        }
    }
}
