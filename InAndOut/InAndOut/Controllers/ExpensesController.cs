using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ExpensesController : Controller
    {
        private  readonly ApplicationDbContext _db;

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
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        } //sercice side validation
    }
}
