using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class MatrialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatrialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matrials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matrial.ToListAsync());
        }

        // GET: Matrials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrial = await _context.Matrial
                .FirstOrDefaultAsync(m => m.MatrialID == id);
            if (matrial == null)
            {
                return NotFound();
            }

            return View(matrial);
        }

        // GET: Matrials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matrials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatrialID,Name,Part")] Matrial matrial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matrial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matrial);
        }

        // GET: Matrials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrial = await _context.Matrial.FindAsync(id);
            if (matrial == null)
            {
                return NotFound();
            }
            return View(matrial);
        }

        // POST: Matrials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatrialID,Name,Part")] Matrial matrial)
        {
            if (id != matrial.MatrialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matrial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatrialExists(matrial.MatrialID))
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
            return View(matrial);
        }

        // GET: Matrials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matrial = await _context.Matrial
                .FirstOrDefaultAsync(m => m.MatrialID == id);
            if (matrial == null)
            {
                return NotFound();
            }

            return View(matrial);
        }

        // POST: Matrials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matrial = await _context.Matrial.FindAsync(id);
            _context.Matrial.Remove(matrial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatrialExists(int id)
        {
            return _context.Matrial.Any(e => e.MatrialID == id);
        }
    }
}
