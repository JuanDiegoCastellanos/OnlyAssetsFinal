// using Microsoft.AspNetCore.Mvc;
// using OnlyAssetsFinal.Models;
// using ustaTickets.Data.Services;

// namespace OnlyAssetsFinal.Controllers
// {
    
//     public class RoleController : Controller
//     {
//      private readonly IRoleService _service;

//         public RoleController(IRoleService service)
//         {
//             _service = service;
//         }

//         public async Task<IActionResult> Index()
//         {
//             var data = await _service.GetAllAsync();
//             return View(data);
//         }

//         // Get: Actor/Create
//         public IActionResult Create()
//         {
//             return View();
//         }

//         [HttpPost]
//         public async Task<IActionResult> Create([Bind("RoleType")]Role role)
//         {
//             if (!ModelState.IsValid)
//             {
//                 //var message = string.Join(" | ", ModelState.Values
//                 //    .SelectMany(v => v.Errors)
//                 //    .Select(e => e.ErrorMessage));
//                 return View(role);
//             }
//             await _service.AddAsync(role);
//             return RedirectToAction(nameof(Index));
//         }

//         // Get: Actor/Details/id
//         public async Task<IActionResult> Details(int id)
//         {
//             var roleDetails = await _service.GetByIdAsync(id);
//             if (roleDetails == null) return View("NotFound");
//             return View(roleDetails);
//         }

//         // Get: Actor/Edit/id
//         public async Task<IActionResult> Edit(int id)
//         {
//             var roleDetails = await _service.GetByIdAsync(id);
//             if (roleDetails == null) return View("NotFound");
//             return View(roleDetails);
//         }

//         [HttpPost]
//         public async Task<IActionResult> Edit(int id, [Bind("Id,RoleType")] Role role)
//         {
//             if (!ModelState.IsValid) return View(role);

//             if (id == role.Id)
//             {
//                 await _service.UpdateAsync(id, role);
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(role);
//         }

//         // Get: Actor/Delete/id
//         public async Task<IActionResult> Delete(int id)
//         {
//             var roleDetails = await _service.GetByIdAsync(id);
//             if (roleDetails == null) return View("NotFound");
//             return View(roleDetails);
//         }

//         [HttpPost, ActionName("Delete")]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             var roleDetails = await _service.GetByIdAsync(id);
//             if (roleDetails == null) return View("NotFound");

//             await _service.DeleteAsync(id);
//             return RedirectToAction(nameof(Index));
//         } 
//     }
// }