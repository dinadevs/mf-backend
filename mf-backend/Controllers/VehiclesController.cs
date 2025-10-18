using mf_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
                return NotFound();

            var data =  await _context.Vehicles.FindAsync(id);

            if(data == null)
                return NotFound();

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
                return NotFound();

            if (ModelState.IsValid)
                {

                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Vehicles.FindAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Vehicles.FindAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Vehicles.FindAsync(id);

            if (data == null)
                return NotFound();

            _context.Vehicles.Remove(data);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Report(int? id)
        {
            if(id == null)
                return NotFound();

            var vehicle = await _context.Vehicles.FindAsync(id);

            if(vehicle == null)
                return NotFound();

            var Consumptions = await _context.Consumptions
                .Where(c => c.VehicleId == vehicle.Id)
                .OrderByDescending(c => c.Date)
                .ToListAsync();

            decimal total = Consumptions.Sum(c => c.Value);

            ViewBag.Vehicle = vehicle;
            ViewBag.TotalConsumption = total;

            return View(Consumptions);
        }
    }
}
