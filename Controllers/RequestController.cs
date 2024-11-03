using ITHelpDeskClient.Data;
using ITHelpDeskClient.Models;
using ITHelpDeskClient.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using ViewModels;

namespace ITHelpDeskClient.Controllers
{
    public class RequestController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public RequestController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult MainRequest()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateTicket()
        {
            var user = await _userManager.GetUserAsync(User);
            var viewmodel = new CreateTicketVM
            {
                User = user,
                Request = new RequestVM()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketVM model)
        {
            if (ModelState.IsValid)
            {
                var request = new Request
                {
                    Title = model.Request.Title,
                    UserGuid = model.User!.Id,
                    Description = model.Request.Description,
                    RequestType = model.Request.RequestType,
                    RequestNumber = model.Request.RequestType.ToString().Substring(0, 3).ToUpper() + DateTime.Now.ToString("yyMMddhmmss")

                };

                _context.Requests.Add(request);
                await _context.SaveChangesAsync();

                return RedirectToAction("ConfirmedTicket","Request");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ConfirmedTicket()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListTicket(string? searchTerm)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!Guid.TryParse(user!.Id, out var userGuid))
            {
                return BadRequest("Invalid user ID format");
            }

            //Consulta
            var query = _context.Requests
                .Where(x => x.UserGuid == user.Id);

            // Aplica el filtro de búsqueda si hay un término de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Title!.Contains(searchTerm) || x.RequestNumber!.Contains(searchTerm));
            }

            var listOfRequest = await query
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ListOfRequestVM
                {
                    Title = x.Title!,
                    Description = x.Description!,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yy"),
                    RequestNumber = x.RequestNumber!
                })
                .ToListAsync();

            // Guarda el término de búsqueda en ViewBag para que el campo de búsqueda lo mantenga
            ViewBag.SearchTerm = searchTerm;

            return View(listOfRequest);
        }

    }
}
