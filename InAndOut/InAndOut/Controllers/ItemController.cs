using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Models;
using InAndOut.Data;


namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objectList = _db.Items;
            return View(objectList);
        }
    }
}
