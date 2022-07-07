using Microsoft.AspNet.Identity;
using Products_page_Question_2.Models;
using Products_page_Question_2.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Products_page_Question_2.Controllers
{
    /// Provides functionality to the /Products/ route.
    public class ProductsController : Controller
    {
       
        private Item_Service item_Service;
        Category_Service Category_Service;
        private ApplicationDbContext db = new ApplicationDbContext();

        public ProductsController()
        {
            
            this.item_Service = new Item_Service();
            this.Category_Service = new Category_Service();
        }

        /// Displays a Products page.
        //GET: /Products/
        /// <returns>A Products page.</returns>
        public ActionResult Products(int? id)
        {
            var items_results = new List<Item>();
            try
            {
                if (id != null)
                {
                    if (id == 0)
                    {
                        items_results = item_Service.GetItems();
                        ViewBag.Department = "All Products";
                    }
                    else
                    {
                        items_results = item_Service.GetItems().Where(x => x.Category_ID == (int)id).ToList();
                        ViewBag.Department = Category_Service.GetCategory(id).Name;
                    }
                }
                else
                {
                    items_results = item_Service.GetItems();
                    ViewBag.Department = "All Products";
                }
            }
            catch (Exception ex) { }
            return View(items_results);
        }
       
    }
}