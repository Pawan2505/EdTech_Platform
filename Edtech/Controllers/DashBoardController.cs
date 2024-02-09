using Edtech.Data;
using Edtech.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edtech.Controllers
{
    
    public class DashBoardController : Controller
    {
        private readonly AppDbContext _context;

        public DashBoardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Students2 != null ?
                        View(await _context.Students2.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Courses'  is null.");
        }
        public async Task<IActionResult> AdminIndex()
        {
            return _context.Students2 != null ?
                        View(await _context.Students2.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Courses'  is null.");
        }

        [Authorize(Roles = "Admin,Teacher,Student")]
        public IActionResult Enroll()
        {
            return View();
        }

        
    }
}
