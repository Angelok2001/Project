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
    public class StructuresController : Controller
    {
        private readonly ProgectContext _context;

        public StructuresController(ProgectContext context)
        {
            _context = context;
        }

        // GET: Structures
        public async Task<IActionResult> Index()
        {
              return View(await _context.Structures.ToListAsync());
        }

        // GET: Structures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Structures == null)
            {
                return NotFound();
            }

            var structures = await _context.Structures
                .FirstOrDefaultAsync(m => m.ID == id);
            if (structures == null)
            {
                return NotFound();
            }

            return View(structures);
        }

        // GET: Structures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Structures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StructureDescription")] Structures structures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(structures);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(structures);
        }

        // GET: Structures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Structures == null)
            {
                return NotFound();
            }

            var structures = await _context.Structures.FindAsync(id);
            if (structures == null)
            {
                return NotFound();
            }
            return View(structures);
        }

        // POST: Structures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StructureDescription")] Structures structures)
        {
            if (id != structures.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(structures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StructuresExists(structures.ID))
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
            return View(structures);
        }

        // GET: Structures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Structures == null)
            {
                return NotFound();
            }

            var structures = await _context.Structures
                .FirstOrDefaultAsync(m => m.ID == id);
            if (structures == null)
            {
                return NotFound();
            }

            return View(structures);
        }

        // POST: Structures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Structures == null)
            {
                return Problem("Entity set 'ProgectContext.Structures'  is null.");
            }
            var structures = await _context.Structures.FindAsync(id);
            if (structures != null)
            {
                _context.Structures.Remove(structures);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StructuresExists(int id)
        {
          return _context.Structures.Any(e => e.ID == id);
        }
    }
}
