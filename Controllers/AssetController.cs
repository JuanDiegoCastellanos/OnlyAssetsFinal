using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Services;

namespace OnlyAssetsFinal.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService _service;

        public AssetController(IAssetService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get: Asset/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,AssetType,AssetImageUrl,Price,Rating")] Asset asset)
        {
            if (!ModelState.IsValid)
            {
                //var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                return View(asset);
            }
            await _service.AddAsync(asset);
            return RedirectToAction(nameof(Index));
        }

        // Get: Asset/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var assetDetails = await _service.GetByIdAsync(id);
            if (assetDetails == null) return View("NotFound");
            return View(assetDetails);
        }

        // Get: Asset/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var assetDetails = await _service.GetByIdAsync(id);
            if (assetDetails == null) return View("NotFound");
            return View(assetDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AssetType,AssetImageUrl,Price,Rating")] Asset asset)
        {
            if (!ModelState.IsValid) return View(asset);

            if (id == asset.Id)
            {
                await _service.UpdateAsync(id, asset);
                return RedirectToAction(nameof(Index));
            }
            return View(asset);
        }

        // Get: Asset/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var assetDetails = await _service.GetByIdAsync(id);
            if (assetDetails == null) return View("NotFound");
            return View(assetDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetDetails = await _service.GetByIdAsync(id);
            if (assetDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}