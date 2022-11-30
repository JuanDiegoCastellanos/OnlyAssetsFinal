using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Services;

namespace OnlyAssetsFinal.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,SurName,FullName,BirthDate,Gender,PhoneNumber")] Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            await _service.AddAsync(person);
            return RedirectToAction(nameof(Index));
        }

        // Get: Person/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");
            return View(personDetails);
        }

        // Get: Person/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");
            return View(personDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,SurName,FullName,BirthDate,Gender,PhoneNumber")] Person person)
        {
            if (!ModelState.IsValid) return View(person);

            if (id == person.Id)
            {
                await _service.UpdateAsync(id, person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // Get: Person/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");
            return View(personDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personDetails = await _service.GetByIdAsync(id);
            if (personDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}