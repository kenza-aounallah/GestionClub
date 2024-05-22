using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubsGestionLastVersion.Models;

namespace ClubsGestionLastVersion.Controllers
{
    public class MembresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Membres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Membres.Include(m => m.Club);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Membres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membres
                .Include(m => m.Club)
                .FirstOrDefaultAsync(m => m.MembreId == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // GET: Membres/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "Nom");
            return View();
        }

        // POST: Membres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembreId,Nom,Prenom,Email,DateNaissance,DateAdhesion,ClubId")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "Nom", membre.ClubId);
            return View(membre);
        }

        // GET: Membres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membres.FindAsync(id);
            if (membre == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "Nom", membre.ClubId);
            return View(membre);
        }

        // POST: Membres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembreId,Nom,Prenom,Email,DateNaissance,DateAdhesion,ClubId")] Membre membre)
        {
            if (id != membre.MembreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreExists(membre.MembreId))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "Nom", membre.ClubId);
            return View(membre);
        }

        // GET: Membres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membres
                .Include(m => m.Club)
                .FirstOrDefaultAsync(m => m.MembreId == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // POST: Membres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membre = await _context.Membres.FindAsync(id);
            if (membre != null)
            {
                _context.Membres.Remove(membre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreExists(int id)
        {
            return _context.Membres.Any(e => e.MembreId == id);
        }
    }
}
