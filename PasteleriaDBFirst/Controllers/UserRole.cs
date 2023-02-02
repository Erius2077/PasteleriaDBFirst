using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasteleriaDBFirst.Models;

namespace PasteleriaDBFirst.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly PasteleriaContext _context;

        public UserRoleController(PasteleriaContext context)
        {
            _context = context;
        }

        // GET: UserRole
        public async Task<IActionResult> Index()
        {
              return _context.UserRole != null ? 
                          View(await _context.UserRole.ToListAsync()) :
                          Problem("Entity set 'PasteleriaContext.UserRole'  is null.");
        }

        // GET: UserRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var userrole = await _context.UserRole
                .FirstOrDefaultAsync(m => m.Iduserrole == id);
            if (userrole == null)
            {
                return NotFound();
            }

            return View(userrole);
        }

        // GET: UserRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iduserrole,UserRole1")] UserRole userrole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userrole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userrole);
        }

        // GET: UserRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var userrole = await _context.UserRole.FindAsync(id);
            if (userrole == null)
            {
                return NotFound();
            }
            return View(userrole);
        }

        // POST: UserRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iduserrole,UserRole1")] UserRole userrole)
        {
            if (id != userrole.Iduserrole)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userrole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userrole.Iduserrole))
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
            return View(userrole);
        }

        // GET: UserRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var userrole = await _context.UserRole
                .FirstOrDefaultAsync(m => m.Iduserrole == id);
            if (userrole == null)
            {
                return NotFound();
            }

            return View(userrole);
        }

        // POST: UserRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserRole == null)
            {
                return Problem("Entity set 'PasteleriaContext.UserRole'  is null.");
            }
            var userrole = await _context.UserRole.FindAsync(id);
            if (userrole != null)
            {
                _context.UserRole.Remove(userrole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRoleExists(int id)
        {
          return (_context.UserRole?.Any(e => e.UserRole == id)).GetValueOrDefault();
        }
    }
}
