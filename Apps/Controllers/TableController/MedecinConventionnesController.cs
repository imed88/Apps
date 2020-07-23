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
    public class MedecinConventionnesController : Controller
    {
        private readonly IdentityContext _context;

        public MedecinConventionnesController(IdentityContext context)
        {
            _context = context;
        }

        // GET: MedecinConventionnes
        
        public async Task<IActionResult> Index()
        {
            var identityContext = _context.MedConv.Include(m => m.specialites);
            return View(await identityContext.ToListAsync());
        }


        // GET: MedecinConventionnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecinConventionne = await _context.MedConv
                .Include(m => m.specialites)
                .SingleOrDefaultAsync(m => m.IdMedConv == id);
            if (medecinConventionne == null)
            {
                return NotFound();
            }

            return View(medecinConventionne);
        }

        // GET: MedecinConventionnes/Create
        public IActionResult Create()
        {
            ViewData["idSpecialite"] = new SelectList(_context.Specialites, "idSpecialite", "nameSpecialite");
            return View();
        }

        // POST: MedecinConventionnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedConv,NomMedConv,PrenomMedConv,Email,Jours_Usine,PlageHoraire,Honoraire_seance,MobielMedConv,idSpecialite")] MedecinConventionne medecinConventionne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medecinConventionne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idSpecialite"] = new SelectList(_context.Specialites, "idSpecialite", "nameSpecialite", medecinConventionne.idSpecialite);
            return View(medecinConventionne);
        }

        // GET: MedecinConventionnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecinConventionne = await _context.MedConv.SingleOrDefaultAsync(m => m.IdMedConv == id);
            if (medecinConventionne == null)
            {
                return NotFound();
            }
            ViewData["idSpecialite"] = new SelectList(_context.Specialites, "idSpecialite", "nameSpecialite", medecinConventionne.idSpecialite);
            return View(medecinConventionne);
        }

        // POST: MedecinConventionnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedConv,NomMedConv,PrenomMedConv,Email,Jours_Usine,PlageHoraire,Honoraire_seance,MobielMedConv,idSpecialite")] MedecinConventionne medecinConventionne)
        {
            if (id != medecinConventionne.IdMedConv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medecinConventionne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedecinConventionneExists(medecinConventionne.IdMedConv))
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
            ViewData["idSpecialite"] = new SelectList(_context.Specialites, "idSpecialite", "nameSpecialite", medecinConventionne.idSpecialite);
            return View(medecinConventionne);
        }

        // GET: MedecinConventionnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecinConventionne = await _context.MedConv
                .Include(m => m.specialites)
                .SingleOrDefaultAsync(m => m.IdMedConv == id);
            if (medecinConventionne == null)
            {
                return NotFound();
            }

            return View(medecinConventionne);
        }

        // POST: MedecinConventionnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medecinConventionne = await _context.MedConv.SingleOrDefaultAsync(m => m.IdMedConv == id);
            _context.MedConv.Remove(medecinConventionne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedecinConventionneExists(int id)
        {
            return _context.MedConv.Any(e => e.IdMedConv == id);
        }
    }
}
