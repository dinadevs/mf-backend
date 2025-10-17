using mf_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_backend.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly AppDbContext _context;
        public VehiclesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Vehicles.ToListAsync();
            return View(data);
        }
    }
}
