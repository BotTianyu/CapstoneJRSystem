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


            return View();
        }


        [HttpPost]
        public IActionResult Login(Account model)
        {
            // 在这里进行对填入信息的判断
            if (ModelState.IsValid)
            {
                // 执行相应的逻辑，保存信息等
                // 你可以在这里调用其他控制器的方法，传递填入的信息等
                // 例如，可以调用UserController的方法来处理用户信息

                Account account = new Account(_context);
                Dictionary<string, string> dataList = account.ExportToDictionary();
                if(model.Password == dataList[model.UserName])
                {
                    return RedirectToAction("Print");
                }
                else
                {
                    return RedirectToAction("Fail");
                }

                //var userInfo = _userController.ProcessUserInfo(model.UserName, model.Password);
                // 其他逻辑操作
                // 重定向到成功页面或其他操作
            }
            else
            {
                // 如果填入的信息不合法，返回表单视图，以便用户重新填写
                //return View(model);
                return RedirectToAction("Fail");
            }
        }



        //public IActionResult Login(Account model)
        //{
        //    // 在这里进行对填入信息的判断
        //    if (ModelState.IsValid)
        //    {
        //        // 执行相应的逻辑，保存信息等
        //        bool isValidCredentials = _userService.ValidateCredentials(model.UserName, model.Password);
        //        if (isValidCredentials)
        //        {
        //            // 验证成功，保存userID到Session或其他适当的地方
        //            int userId = _userService.GetUserIdByUsername(model.UserName);
        //            HttpContext.Session.SetInt32("UserId", userId);

        //            return RedirectToAction("Success"); // 重定向到成功页面或其他操作
        //        }
        //        else
        //        {
        //            // 验证失败，返回错误消息或视图
        //            ModelState.AddModelError(string.Empty, "Invalid username or password");
        //            return View(model);
        //        }
        //    }
        //    else
        //    {
        //        // 如果填入的信息不合法，返回表单视图，以便用户重新填写
        //        return View(model);
        //    }
        //}

        private bool AccountExists(string id)
        {
          return (_context.AccountSets?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}



