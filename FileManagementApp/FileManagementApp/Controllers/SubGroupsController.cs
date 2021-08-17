using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileManagementApp.Data;
using FileManagementApp.Models;

namespace FileManagementApp.Controllers
{
    public class SubGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SubGroups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubGroups.Include(s => s.Group);
            return View(await applicationDbContext.ToListAsync());
        }
        
        // GET: SubGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroups
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.SubGroupID == id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return View(subGroup);
        }

        // GET: SubGroups/Create
        public IActionResult Create()
        {
           
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: SubGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubGroupID,SubGroupName,GroupID")] SubGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subGroup);
                await _context.SaveChangesAsync();
                TempData["msg"] = "Save SubGroup Success";
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", subGroup.GroupID);
            return View(subGroup);
        }

        // GET: SubGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroups.FindAsync(id);
            if (subGroup == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName");
            return View(subGroup);
        }

        // POST: SubGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGroup);
                    TempData["msg"] = "Update SubGroup Success";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGroupExists(subGroup.SubGroupID))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", subGroup.GroupID);
            return View(subGroup);
        }

        // GET: SubGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroups
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.SubGroupID == id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return View(subGroup);
        }

        // POST: SubGroups/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subGroup = await _context.SubGroups.FindAsync(id);
            _context.SubGroups.Remove(subGroup);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Delete SubGroup Success";
            return RedirectToAction(nameof(Index));
        }

        private bool SubGroupExists(int id)
        {
            return _context.SubGroups.Any(e => e.SubGroupID == id);
        }
    }
}
