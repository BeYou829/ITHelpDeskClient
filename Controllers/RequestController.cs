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
        public async Task<IActionResult> ListTicket()
        {
            var user = await _userManager.GetUserAsync(User);
           
            if (!Guid.TryParse(user!.Id, out var userGuid))
            {
                return BadRequest("Invalid user ID format");
            }
            var listOfRequest = await _context.Requests.Where(x => x.UserGuid == user.Id)
                .Select(x => new ListOfRequestVM
                {
                    Title = x.Title!,
                    Description = x.Description!,
                    CreatedOn = x.CreatedOn.ToString(),
                    RequestNumber = x.RequestNumber!
                })
                .ToListAsync();
            return View(listOfRequest);
        }
    }
}
