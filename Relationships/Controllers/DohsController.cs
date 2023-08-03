using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Relationships.Models;

namespace Relationships.Controllers
{
    public class DohsController : Controller
    {
        private readonly DbA9b7cfLayersdbContext _context;

        public DohsController(DbA9b7cfLayersdbContext context)
        {
            _context = context;
        }

        // GET: Dohs
        public async Task<IActionResult> Index()
        {
            var dbA9b7cfLayersdbContext = _context.Dohs.Include(d => d.Governorate);
            return View(await dbA9b7cfLayersdbContext.ToListAsync());
        }

        // GET: Dohs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dohs == null)
            {
                return NotFound();
            }

            var doh = await _context.Dohs
                .Include(d => d.Governorate)
                .FirstOrDefaultAsync(m => m.DohId == id);
            if (doh == null)
            {
                return NotFound();
            }

            return View(doh);
        }

        // GET: Dohs/Create
        public IActionResult Create()
        {
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "GovernorateId", "GovernorateId");
            return View();
        }

        // POST: Dohs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DohId,DohName,GovernorateId")] Doh doh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "GovernorateId", "GovernorateId", doh.GovernorateId);
            return View(doh);
        }

        // GET: Dohs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dohs == null)
            {
                return NotFound();
            }

            var doh = await _context.Dohs.FindAsync(id);
            if (doh == null)
            {
                return NotFound();
            }
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "GovernorateId", "GovernorateId", doh.GovernorateId);
            return View(doh);
        }

        // POST: Dohs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DohId,DohName,GovernorateId")] Doh doh)
        {
            if (id != doh.DohId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DohExists(doh.DohId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "GovernorateId", "GovernorateId", doh.GovernorateId);
            return View(doh);
        }

        // GET: Dohs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dohs == null)
            {
                return NotFound();
            }

            var doh = await _context.Dohs
                .Include(d => d.Governorate)
                .FirstOrDefaultAsync(m => m.DohId == id);
            if (doh == null)
            {
                return NotFound();
            }

            return View(doh);
        }

        // POST: Dohs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dohs == null)
            {
                return Problem("Entity set 'DbA9b7cfLayersdbContext.Dohs'  is null.");
            }
            var doh = await _context.Dohs.FindAsync(id);
            if (doh != null)
            {
                _context.Dohs.Remove(doh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DohExists(int id)
        {
          return (_context.Dohs?.Any(e => e.DohId == id)).GetValueOrDefault();
        }
    }
}
