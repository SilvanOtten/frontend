using FrontEnd.Agents;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalAgent _animalAgent { get; }

        public AnimalController(IAnimalAgent animalAgent)
        {
            _animalAgent = animalAgent;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var model = await _animalAgent.GetAllAnimals();

            return View(model);
        }

        // GET: Animal/Details/5
        public IActionResult Details(int id)
        {
            var model = _animalAgent.GetAnimalById(id);

            return View(model);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            return View();
        }

        // TO-DO: Check if we can do modelbinding here and how to test it
        // POST: Animal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Animal animal)
        {
            try
            {
                _animalAgent.Create(animal);

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }
        // TO-DO: Edit and delete

        //// GET: Animal/Edit/5
        //public IActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Animal/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Animal/Delete/5
        //public IActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Animal/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}