using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab26Tom.Models;

namespace Lab26Tom.Controllers
{
    public class LFGController : Controller
    {
        private readonly Lab26TomContext _context;

        public LFGController(Lab26TomContext context)
        {
            _context = context;
        }

        // GET: LFGs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LFG.ToListAsync());
        }

        // GET: LFGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lFG = await _context.LFG
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lFG == null)
            {
                return NotFound();
            }

            return View(lFG);
        }

        // GET: LFGs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LFGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Gamertag,DestinyClass,Request")] LFG lFG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lFG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lFG);
        }

        // GET: LFGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lFG = await _context.LFG.SingleOrDefaultAsync(m => m.ID == id);
            if (lFG == null)
            {
                return NotFound();
            }
            return View(lFG);
        }

        // POST: LFGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Gamertag,DestinyClass,Request")] LFG lFG)
        {
            if (id != lFG.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lFG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LFGExists(lFG.ID))
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
            return View(lFG);
        }

        // GET: LFGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lFG = await _context.LFG
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lFG == null)
            {
                return NotFound();
            }

            return View(lFG);
        }

        // POST: LFGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lFG = await _context.LFG.SingleOrDefaultAsync(m => m.ID == id);
            _context.LFG.Remove(lFG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LFGExists(int id)
        {
            return _context.LFG.Any(e => e.ID == id);
        }
    }
}
