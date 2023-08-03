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
    public class GovernoratesController : Controller
    {
        private readonly DbA9b7cfLayersdbContext _context;

        public GovernoratesController(DbA9b7cfLayersdbContext context)
        {
            _context = context;
        }

        // GET: Governorates
        public async Task<IActionResult> Index()
        {
              return _context.Governorates != null ? 
                          View(await _context.Governorates.ToListAsync()) :
                          Problem("Entity set 'DbA9b7cfLayersdbContext.Governorates'  is null.");
        }

        // GET: Governorates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Governorates == null)
            {
                return NotFound();
            }

            var governorate = await _context.Governorates
                .FirstOrDefaultAsync(m => m.GovernorateId == id);
            if (governorate == null)
            {
                return NotFound();
            }

            return View(governorate);
        }

        // GET: Governorates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Governorates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GovernorateId,GovernorateName")] Governorate governorate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(governorate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(governorate);
        }

        // GET: Governorates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Governorates == null)
            {
                return NotFound();
            }

            var governorate = await _context.Governorates.FindAsync(id);
            if (governorate == null)
            {
                return NotFound();
            }
            return View(governorate);
        }

        // POST: Governorates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GovernorateId,GovernorateName")] Governorate governorate)
        {
            if (id != governorate.GovernorateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(governorate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GovernorateExists(governorate.GovernorateId))
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
            return View(governorate);
        }

        // GET: Governorates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Governorates == null)
            {
                return NotFound();
            }

            var governorate = await _context.Governorates
                .FirstOrDefaultAsync(m => m.GovernorateId == id);
            if (governorate == null)
            {
                return NotFound();
            }

            return View(governorate);
        }

        // POST: Governorates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Governorates == null)
            {
                return Problem("Entity set 'DbA9b7cfLayersdbContext.Governorates'  is null.");
            }
            var governorate = await _context.Governorates.FindAsync(id);
            if (governorate != null)
            {
                _context.Governorates.Remove(governorate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GovernorateExists(int id)
        {
          return (_context.Governorates?.Any(e => e.GovernorateId == id)).GetValueOrDefault();
        }
    }
}
