using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apps.Data;
using Apps.Models.Tables;

namespace Apps.Controllers.TableController
{
    public class SpecialitesController : Controller
    {
        private readonly IdentityContext _context;
        public IList<Specialites> specialites { get; set; }

        public SpecialitesController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Specialites
        public async Task<IActionResult> Index(string searching)
        {
            var specs = from s in _context.Specialites select s;
            if (!String.IsNullOrEmpty(searching))
            {
                specs = specs.Where(s => s.nameSpecialite.Contains(searching));
            }
            return View(await specs.ToListAsync());
        }


       

        

        // GET: Specialites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialites = await _context.Specialites
                .SingleOrDefaultAsync(m => m.idSpecialite == id);
            if (specialites == null)
            {
                return NotFound();
            }

            return View(specialites);
        }

        // GET: Specialites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSpecialite,nameSpecialite")] Specialites specialites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialites);
        }

        // GET: Specialites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialites = await _context.Specialites.SingleOrDefaultAsync(m => m.idSpecialite == id);
            if (specialites == null)
            {
                return NotFound();
            }
            return View(specialites);
        }

        // POST: Specialites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSpecialite,nameSpecialite")] Specialites specialites)
        {
            if (id != specialites.idSpecialite)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialitesExists(specialites.idSpecialite))
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
            return View(specialites);
        }

        // GET: Specialites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialites = await _context.Specialites
                .SingleOrDefaultAsync(m => m.idSpecialite == id);
            if (specialites == null)
            {
                return NotFound();
            }

            return View(specialites);
        }

        // POST: Specialites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialites = await _context.Specialites.SingleOrDefaultAsync(m => m.idSpecialite == id);
            _context.Specialites.Remove(specialites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialitesExists(int id)
        {
            return _context.Specialites.Any(e => e.idSpecialite == id);
        }
    }
}
