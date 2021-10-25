using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objectList = _db.Expenses;
            return View(objectList);
        }

        // get create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text =i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        // POST create
        [HttpPost]
        [ValidateAntiForgeryToken] //для безопасности чтобы никто не мог менять код

        public IActionResult Create(Expense obj)
        {
            //првоерка на положительность
            if (ModelState.IsValid)
            {
                //obj.ExpenseRefId = 1;

                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        } //sercice side validation

        //GET  delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET  Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken] //для безопасности чтобы никто не мог менять код

        public IActionResult Update(Expense obj)
        {
            //првоерка на положительность
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        } 
    }
}
