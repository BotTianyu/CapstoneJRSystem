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
    public class AccountsController : Controller
    {
        private readonly ReferralDBContext _context;

        public AccountsController(ReferralDBContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
              return _context.AccountSets != null ? 
                          View(await _context.AccountSets.ToListAsync()) :
                          Problem("Entity set 'ReferralDBContext.AccountSets'  is null.");
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AccountSets == null)
            {
                return NotFound();
            }

            var account = await _context.AccountSets
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,UserName,SetupTime,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AccountSets == null)
            {
                return NotFound();
            }

            var account = await _context.AccountSets.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccountId,UserName,SetupTime,Password")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
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
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AccountSets == null)
            {
                return NotFound();
            }

            var account = await _context.AccountSets
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AccountSets == null)
            {
                return Problem("Entity set 'ReferralDBContext.AccountSets'  is null.");
            }
            var account = await _context.AccountSets.FindAsync(id);
            if (account != null)
            {
                _context.AccountSets.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Print()
        {


            return View();
        }

        public IActionResult Fail()
        {
            Account account = new Account(_context);
            Dictionary<string, string> dataList = account.ExportToDictionary();

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Account model)
        {
                Account account = new Account(_context);
                Dictionary<string, string> dataList = account.ExportToDictionary();
            if (model.Password == dataList[model.UserName])
            {
                return RedirectToAction("Print");
            }
            else
            {
                return RedirectToAction("Fail");
            }


            return RedirectToAction("Fail");
            
        }



  

        private bool AccountExists(string id)
        {
          return (_context.AccountSets?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}



