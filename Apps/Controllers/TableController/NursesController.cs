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
    public class NursesController : Controller
    {
        private readonly IdentityContext _context;

        public NursesController(IdentityContext context)
        {
            _context = context;
        }

        // GET: Nurses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nurses.ToListAsync());
        }

        // GET: Nurses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurses = await _context.Nurses
                .SingleOrDefaultAsync(m => m.idNurse == id);
            if (nurses == null)
            {
                return NotFound();
            }

            return View(nurses);
        }

        // GET: Nurses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nurses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idNurse,nameNurse,emailNurse,passwordNurse,phoneNurse,created")] Nurses nurses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nurses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nurses);
        }

        // GET: Nurses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurses = await _context.Nurses.SingleOrDefaultAsync(m => m.idNurse == id);
            if (nurses == null)
            {
                return NotFound();
            }
            return View(nurses);
        }

        // POST: Nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idNurse,nameNurse,emailNurse,passwordNurse,phoneNurse,created")] Nurses nurses)
        {
            if (id != nurses.idNurse)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nurses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NursesExists(nurses.idNurse))
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
            return View(nurses);
        }

        // GET: Nurses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurses = await _context.Nurses
                .SingleOrDefaultAsync(m => m.idNurse == id);
            if (nurses == null)
            {
                return NotFound();
            }

            return View(nurses);
        }

        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nurses = await _context.Nurses.SingleOrDefaultAsync(m => m.idNurse == id);
            _context.Nurses.Remove(nurses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NursesExists(int id)
        {
            return _context.Nurses.Any(e => e.idNurse == id);
        }
    }
}
