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
    public class MaterialItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaterialItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaterialItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MaterialItem.Include(m => m.Matrial);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MaterialItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialItem = await _context.MaterialItem
                .Include(m => m.Matrial)
                .FirstOrDefaultAsync(m => m.MaterialItemID == id);
            if (materialItem == null)
            {
                return NotFound();
            }

            return View(materialItem);
        }

        // GET: MaterialItems/Create
        public IActionResult Create()
        {
            ViewData["MatrialID"] = new SelectList(_context.Matrial, "MatrialID", "Name");
            return View();
        }

        // POST: MaterialItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialItemID,ItemName,ItemType,State,MatrialID")] MaterialItem materialItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatrialID"] = new SelectList(_context.Matrial, "MatrialID", "Name", materialItem.MatrialID);
            return View(materialItem);
        }

        // GET: MaterialItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialItem = await _context.MaterialItem.FindAsync(id);
            if (materialItem == null)
            {
                return NotFound();
            }
            ViewData["MatrialID"] = new SelectList(_context.Matrial, "MatrialID", "Name", materialItem.MatrialID);
            return View(materialItem);
        }

        // POST: MaterialItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialItemID,ItemName,ItemType,State,MatrialID")] MaterialItem materialItem)
        {
            if (id != materialItem.MaterialItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialItemExists(materialItem.MaterialItemID))
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
            ViewData["MatrialID"] = new SelectList(_context.Matrial, "MatrialID", "Name", materialItem.MatrialID);
            return View(materialItem);
        }

        // GET: MaterialItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialItem = await _context.MaterialItem
                .Include(m => m.Matrial)
                .FirstOrDefaultAsync(m => m.MaterialItemID == id);
            if (materialItem == null)
            {
                return NotFound();
            }

            return View(materialItem);
        }

        // POST: MaterialItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialItem = await _context.MaterialItem.FindAsync(id);
            _context.MaterialItem.Remove(materialItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialItemExists(int id)
        {
            return _context.MaterialItem.Any(e => e.MaterialItemID == id);
        }
    }
}
