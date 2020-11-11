using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Disc_Store.Models;

namespace CRUD_Disc_Store.Controllers
{
    public class DiscsController : Controller
    {
        private readonly Context _context;

        public DiscsController(Context context)
        {
            _context = context;
        }

        // GET: Discs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Discs.ToListAsync());
        }

        // GET: Discs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discs = await _context.Discs
                .FirstOrDefaultAsync(m => m.DiscID == id);
            if (discs == null)
            {
                return NotFound();
            }

            return View(discs);
        }

        // GET: Discs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Discs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscID,Title,Author,Genre")] Discs discs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discs);
        }

        // GET: Discs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discs = await _context.Discs.FindAsync(id);
            if (discs == null)
            {
                return NotFound();
            }
            return View(discs);
        }

        // POST: Discs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscID,Title,Author,Genre")] Discs discs)
        {
            if (id != discs.DiscID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscsExists(discs.DiscID))
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
            return View(discs);
        }

        // GET: Discs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discs = await _context.Discs
                .FirstOrDefaultAsync(m => m.DiscID == id);
            if (discs == null)
            {
                return NotFound();
            }

            return View(discs);
        }

        // POST: Discs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discs = await _context.Discs.FindAsync(id);
            _context.Discs.Remove(discs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscsExists(int id)
        {
            return _context.Discs.Any(e => e.DiscID == id);
        }
    }
}
