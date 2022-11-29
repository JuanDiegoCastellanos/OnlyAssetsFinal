using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using ustaTickets.Data.Services;

namespace OnlyAssetsFinal.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _service;

        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Description,TotalAmount")]Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                //var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                return View(purchase);
            }
            await _service.AddAsync(purchase);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actor/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var purchaseDeatils = await _service.GetByIdAsync(id);
            if (purchaseDeatils == null) return View("NotFound");
            return View(purchaseDeatils);
        }

        // Get: Actor/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var purchaseDeatils = await _service.GetByIdAsync(id);
            if (purchaseDeatils == null) return View("NotFound");
            return View(purchaseDeatils);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,TotalAmount")] Purchase purchase)
        {
            if (!ModelState.IsValid) return View(purchase);

            if (id == purchase.Id)
            {
                await _service.UpdateAsync(id, purchase);
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // Get: Actor/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var purchaseDeatils = await _service.GetByIdAsync(id);
            if (purchaseDeatils == null) return View("NotFound");
            return View(purchaseDeatils);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseDeatils = await _service.GetByIdAsync(id);
            if (purchaseDeatils == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        } 
    }
}