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
    public class DocumentsController : Controller
    {
        private readonly ProgectContext _context;

        public DocumentsController(ProgectContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var progectContext = _context.Documents.Include(d => d.Types);
            return View(await progectContext.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Include(d => d.Types)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (documents == null)
            {
                return NotFound();
            }

            return View(documents);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["TypesID"] = new SelectList(_context.Types, "ID", "ID");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StructureID,TypesID,AccessCount,DocumentName,DocumentDescription,OtherDetails")] Documents documents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypesID"] = new SelectList(_context.Types, "ID", "ID", documents.TypesID);
            return View(documents);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents.FindAsync(id);
            if (documents == null)
            {
                return NotFound();
            }
            ViewData["TypesID"] = new SelectList(_context.Types, "ID", "ID", documents.TypesID);
            return View(documents);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StructureID,TypesID,AccessCount,DocumentName,DocumentDescription,OtherDetails")] Documents documents)
        {
            if (id != documents.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentsExists(documents.ID))
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
            ViewData["TypesID"] = new SelectList(_context.Types, "ID", "ID", documents.TypesID);
            return View(documents);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Include(d => d.Types)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (documents == null)
            {
                return NotFound();
            }

            return View(documents);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'ProgectContext.Documents'  is null.");
            }
            var documents = await _context.Documents.FindAsync(id);
            if (documents != null)
            {
                _context.Documents.Remove(documents);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentsExists(int id)
        {
          return _context.Documents.Any(e => e.ID == id);
        }
    }
}
