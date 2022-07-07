using Products_page_Question_2.Models;
using Products_page_Question_2.Services;
using System.Web.Mvc;

namespace Products_page_Question_2.Controllers
{
    /// Provides functionality to the /Categories/ route.
    public class CategoriesController : Controller
    {
        Category_Service Category_Service = new Category_Service();

        //GET: /Categories/
        /// Displays a Categories page.
        ///   /// <returns>An Categories page.</returns>
        public ActionResult Index()
        {
            return View(Category_Service.GetCategories());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (Category_Service.GetCategory(id) != null)
                return View(Category_Service.GetCategory(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                Category_Service.AddCategory(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (Category_Service.GetCategory(id) != null)
                return View(Category_Service.GetCategory(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                Category_Service.UpdateCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Bad_Request", "Error");
            if (Category_Service.GetCategory(id) != null)
                return View(Category_Service.GetCategory(id));
            else
                return RedirectToAction("Not_Found", "Error");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_Service.RemoveCategory(Category_Service.GetCategory(id));
            return RedirectToAction("Index");
        }
    }
}