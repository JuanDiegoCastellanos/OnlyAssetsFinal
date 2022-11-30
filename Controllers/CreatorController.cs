using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Services;

namespace OnlyAssetsFinal.Controllers
{
    public class CreatorController : Controller
    {
        private readonly ICreatorService _service;

        public CreatorController(ICreatorService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get: Creator/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CompanyName,ContactNumber,ProfilePictureURL")] Creator creator)
        {
            if (!ModelState.IsValid)
            {
                return View(creator);
            }
            await _service.AddAsync(creator);
            return RedirectToAction(nameof(Index));
        }

        // Get: Creator/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var creatorDetails = await _service.GetByIdAsync(id);
            if (creatorDetails == null) return View("NotFound");
            return View(creatorDetails);
        }

        // Get: Creator/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var creatorDetails = await _service.GetByIdAsync(id);
            if (creatorDetails == null) return View("NotFound");
            return View(creatorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyName,ContactNumber,ProfilePictureURL")] Creator creator)
        {
            if (!ModelState.IsValid) return View(creator);

            if (id == creator.Id)
            {
                await _service.UpdateAsync(id, creator);
                return RedirectToAction(nameof(Index));
            }
            return View(creator);
        }

        // Get: Creator/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var creatorDetails = await _service.GetByIdAsync(id);
            if (creatorDetails == null) return View("NotFound");
            return View(creatorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creatorDetails = await _service.GetByIdAsync(id);
            if (creatorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}