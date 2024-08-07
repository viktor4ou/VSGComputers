using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSGComputers.Data;
using VSGComputers.Models;

namespace VSGComputers.Controllers
{
    public class ComputersController : Controller
    {
        private ComputersDbContext db;
        public ComputersController(ComputersDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Computer> computers = db.Computers.ToList();
            return View(computers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Computer computer)
        {
            if (ModelState.IsValid)
            {
                db.Computers.Add(computer);
                db.SaveChanges();
                TempData["success"] = "Successfully created";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Computer searchedComputer = db.Computers.ToList().Find(i => i.Id == id);
            db.Computers.Remove(searchedComputer);
            db.SaveChanges();
            TempData["success"] = "Successfully deleted";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCurrent(int id)
        {
            Computer searchedComputer = db.Computers.ToList().Find(i => i.Id == id);
            db.Computers.Remove(searchedComputer);
            db.SaveChanges();
            TempData["success"] = "Successfully deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = db.Computers.Find(id);
            if (result is null)
            {
                return NotFound();
            }
            
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Computer computer)
        {
            if (computer is null)
            {
                return NotFound();
            }

            db.Computers.Update(computer);
            db.SaveChanges();
            TempData["success"] = "Successfully updated";
            return RedirectToAction("Index");
        }
    }
}
