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
        private readonly IWebHostEnvironment webHostEnvironment;
        public ComputersController(IComputerRepository computerRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.computerRepository = computerRepository;
            this.webHostEnvironment = webHostEnvironment;
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
        public IActionResult Create(Computer computer, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"img\Computers");

                    
                    using (FileStream s = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(s);
                    }

                    computer.ImageURL = @"\img\Computers\" + filename;
                }
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
        public IActionResult Edit(Computer computer, IFormFile ? file)
        {

            if (computer is null)
            {
                return NotFound();
            }

            string wwwRootPath = webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"img\Computers");
                string oldImagePath = Path.Combine(wwwRootPath, computer.ImageURL.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))    
                {
                    System.IO.File.Delete(oldImagePath);
                }
                using (FileStream s = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                {
                    file.CopyTo(s);
                }
                computer.ImageURL = @"\img\Computers\" + filename;
            }
            computerRepository.Update(computer);
            computerRepository.Save();
            TempData["success"] = "Successfully updated";
            return RedirectToAction("Index");
        }
    }
}
