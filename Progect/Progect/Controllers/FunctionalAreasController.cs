using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Progect.Data;
using Progect.Models;

namespace Progect.Controllers
{
    public class FunctionalAreasController : Controller
    {
        private readonly ProgectContext _context;

        public FunctionalAreasController(ProgectContext context)
        {
            _context = context;
        }

        // GET: FunctionalAreas
        public async Task<IActionResult> Index()
        {
              return View(await _context.FunctionalArea.ToListAsync());
        }

        // GET: FunctionalAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FunctionalArea == null)
            {
                return NotFound();
            }

            var functionalArea = await _context.FunctionalArea
                .FirstOrDefaultAsync(m => m.ID == id);
            if (functionalArea == null)
            {
                return NotFound();
            }

            return View(functionalArea);
        }

        // GET: FunctionalAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FunctionalAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FunctionalAreaDescription")] FunctionalArea functionalArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionalArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(functionalArea);
        }

        // GET: FunctionalAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FunctionalArea == null)
            {
                return NotFound();
            }

            var functionalArea = await _context.FunctionalArea.FindAsync(id);
            if (functionalArea == null)
            {
                return NotFound();
            }
            return View(functionalArea);
        }

        // POST: FunctionalAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FunctionalAreaDescription")] FunctionalArea functionalArea)
        {
            if (id != functionalArea.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functionalArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionalAreaExists(functionalArea.ID))
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
            return View(functionalArea);
        }

        // GET: FunctionalAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FunctionalArea == null)
            {
                return NotFound();
            }

            var functionalArea = await _context.FunctionalArea
                .FirstOrDefaultAsync(m => m.ID == id);
            if (functionalArea == null)
            {
                return NotFound();
            }

            return View(functionalArea);
        }

        // POST: FunctionalAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FunctionalArea == null)
            {
                return Problem("Entity set 'ProgectContext.FunctionalArea'  is null.");
            }
            var functionalArea = await _context.FunctionalArea.FindAsync(id);
            if (functionalArea != null)
            {
                _context.FunctionalArea.Remove(functionalArea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionalAreaExists(int id)
        {
          return _context.FunctionalArea.Any(e => e.ID == id);
        }
    }
}
