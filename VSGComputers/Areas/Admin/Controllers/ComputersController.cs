using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSGComputers.Data;
using VSGComputers.DataAccess.Repository.Interfaces;
using VSGComputers.Models;

namespace VSGComputers.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComputersController : Controller
    {
        private readonly IComputerRepository computerRepository;
        public ComputersController(IComputerRepository computerRepository)
        {
            this.computerRepository = computerRepository;
        }
        public IActionResult Index()
        {
            List<Computer> computers = computerRepository.GetAll().ToList();
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
                computerRepository.Add(computer);
                computerRepository.Save();
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
            Computer searchedComputer = computerRepository.GetBy(i => i.Id == id);
            computerRepository.Remove(searchedComputer);
            computerRepository.Save();
            TempData["success"] = "Successfully deleted";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCurrent(int id)
        {
            Computer searchedComputer = computerRepository.GetBy(i => i.Id == id);
            computerRepository.Remove(searchedComputer);
            computerRepository.Save();
            TempData["success"] = "Successfully deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = computerRepository.GetBy(i => i.Id == id);
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

            computerRepository.Update(computer);
            computerRepository.Save();
            TempData["success"] = "Successfully updated";
            return RedirectToAction("Index");
        }
    }
}
