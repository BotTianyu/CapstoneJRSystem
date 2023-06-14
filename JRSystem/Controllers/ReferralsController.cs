using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JRSystem.Models;

namespace JRSystem.Controllers
{
    public class ReferralsController : Controller
    {
        private readonly ReferralDBContext _context;

        public ReferralsController(ReferralDBContext context)
        {
            _context = context;
        }

        // GET: Referrals
        public async Task<IActionResult> Index()
        {
              return _context.ReferralSets != null ? 
                          View(await _context.ReferralSets.ToListAsync()) :
                          Problem("Entity set 'ReferralDBContext.ReferralSets'  is null.");
        }

        // GET: Referrals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ReferralSets == null)
            {
                return NotFound();
            }

            var referral = await _context.ReferralSets
                .FirstOrDefaultAsync(m => m.ReferralId == id);
            if (referral == null)
            {
                return NotFound();
            }

            return View(referral);
        }

        // GET: Referrals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Referrals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferralId,ReferralName,ReferralDate,deadline,JobTitle")] Referral referral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referral);
        }

        // GET: Referrals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ReferralSets == null)
            {
                return NotFound();
            }

            var referral = await _context.ReferralSets.FindAsync(id);
            if (referral == null)
            {
                return NotFound();
            }
            return View(referral);
        }

        // POST: Referrals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReferralId,ReferralName,ReferralDate,deadline,JobTitle")] Referral referral)
        {
            if (id != referral.ReferralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferralExists(referral.ReferralId))
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
            return View(referral);
        }

        // GET: Referrals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ReferralSets == null)
            {
                return NotFound();
            }

            var referral = await _context.ReferralSets
                .FirstOrDefaultAsync(m => m.ReferralId == id);
            if (referral == null)
            {
                return NotFound();
            }

            return View(referral);
        }

        // POST: Referrals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ReferralSets == null)
            {
                return Problem("Entity set 'ReferralDBContext.ReferralSets'  is null.");
            }
            var referral = await _context.ReferralSets.FindAsync(id);
            if (referral != null)
            {
                _context.ReferralSets.Remove(referral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferralExists(string id)
        {
          return (_context.ReferralSets?.Any(e => e.ReferralId == id)).GetValueOrDefault();
        }
    }
}
