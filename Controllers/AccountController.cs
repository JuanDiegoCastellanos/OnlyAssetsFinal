using Microsoft.AspNetCore.Mvc;
using OnlyAssetsFinal.Models;
using OnlyAssetsFinal.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlyAssetsFinal.Data.ViewModels;

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
            var data = await _service.GetAllAsync(p => p.Person, r => r.Role);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(p => p.Person, r => r.Role);
            
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(
                    n => n.NickName.Contains(searchString) || 
                    n.Email.Contains(searchString)
                ).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }

        // Get: Account/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetAccountByIdAsync(id);
            return View(data);
        }

        // Get: Account/Create
        public async Task<IActionResult> Create()
        {
            var accountDropdownsData = await _service.GetNewAccountDropdownsValues();
            ViewBag.Persons = new SelectList(accountDropdownsData.Persons, "Id", "FullName");
            ViewBag.Roles = new SelectList(accountDropdownsData.Roles, "Id", "RoleType");
            ViewBag.Assets = new SelectList(accountDropdownsData.Assets, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewAccountVM account)
        {
            if (!ModelState.IsValid)
            {
                var accountDropdownsData = await _service.GetNewAccountDropdownsValues();
                ViewBag.Persons = new SelectList(accountDropdownsData.Persons, "Id", "FullName");
                ViewBag.Roles = new SelectList(accountDropdownsData.Roles, "Id", "RoleType");
                ViewBag.Assets = new SelectList(accountDropdownsData.Assets, "Id", "Name");

                return View(account);
            }
            await _service.AddNewAccountAsync(account);
            return RedirectToAction(nameof(Index));
        }

        // Get: Account/Edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var accountDetails = await _service.GetAccountByIdAsync(id);
            if (accountDetails == null) return View("NotFound");

            var response = new NewAccountVM()
            {
                Id = accountDetails.Id,
                Email = accountDetails.Email,
                Password = accountDetails.Password,
                NickName = accountDetails.NickName,
                CreationDate = accountDetails.CreationDate,
                CountryCreation = accountDetails.CountryCreation,
                ProfilePictureURL = accountDetails.ProfilePictureURL,
                PersonId = accountDetails.PersonId,
                RoleId = accountDetails.RoleId
            };

            var accountDropdownsData = await _service.GetNewAccountDropdownsValues();
            ViewBag.Persons = new SelectList(accountDropdownsData.Persons, "Id", "FullName");
            ViewBag.Roles = new SelectList(accountDropdownsData.Roles, "Id", "RoleType");
            ViewBag.Assets = new SelectList(accountDropdownsData.Assets, "Id", "Name");
            
            return View(response);
        }

        [HttpPost]
         public async Task<IActionResult> Edit(int id, NewAccountVM account)
        {
            if (id != account.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var accountDropdownsData = await _service.GetNewAccountDropdownsValues();
                ViewBag.Persons = new SelectList(accountDropdownsData.Persons, "Id", "FullName");
                ViewBag.Roles = new SelectList(accountDropdownsData.Roles, "Id", "RoleType");
                ViewBag.Assets = new SelectList(accountDropdownsData.Assets, "Id", "Name");

                return View(account);
            }
            await _service.UpdateAccountAsync(account);
            return RedirectToAction(nameof(Index));
        }

        // Get: Account/Delete/id
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