using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Services;

namespace OnlyAssetsFinal.Controllers
{

    public class RoleController : Controller
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get: Role/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("RoleType")] Role role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            await _service.AddAsync(role);
            return RedirectToAction(nameof(Index));
        }

        // Get: Role/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var roleDetails = await _service.GetByIdAsync(id);
            if (roleDetails == null) return View("NotFound");
            return View(roleDetails);
        }

        // Get: Role/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var roleDetails = await _service.GetByIdAsync(id);
            if (roleDetails == null) return View("NotFound");
            return View(roleDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("RoleType")] Role role)
        {
            if (!ModelState.IsValid) return View(role);

            if (id == role.Id)
            {
                await _service.UpdateAsync(id, role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // Get: Role/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var roleDetails = await _service.GetByIdAsync(id);
            if (roleDetails == null) return View("NotFound");
            return View(roleDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleDetails = await _service.GetByIdAsync(id);
            if (roleDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}