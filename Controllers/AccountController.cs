using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using ustaTickets.Data.Services;

namespace OnlyAssetsFinal.Controllers
{
    
    public class AccountController : Controller
    {
         private readonly IAccountService _service;

        public AccountController(IAccountService service)
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
        public async Task<IActionResult> Create([Bind("Email,Password,NickName,CreationDate,CountryCreation,ProfilePictureURL")]Account account)
        {
            if (!ModelState.IsValid)
            {
                //var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                return View(account);
            }
            await _service.AddAsync(account);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actor/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var accountDetails = await _service.GetByIdAsync(id);
            if (accountDetails == null) return View("NotFound");
            return View(accountDetails);
        }

        // Get: Actor/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var accountDetails = await _service.GetByIdAsync(id);
            if (accountDetails == null) return View("NotFound");
            return View(accountDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,NickName,CreationDate,CountryCreation,ProfilePictureURL")] Account account)
        {
            if (!ModelState.IsValid) return View(account);

            if (id == account.Id)
            {
                await _service.UpdateAsync(id, account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // Get: Actor/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var accountDetails = await _service.GetByIdAsync(id);
            if (accountDetails == null) return View("NotFound");
            return View(accountDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountDetails = await _service.GetByIdAsync(id);
            if (accountDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        } 
    }
}