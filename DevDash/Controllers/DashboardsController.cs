using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevDash.Data;
using DevDash.Models;

namespace DevDash.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dashboards
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dashboard.Include(d => d.GitHub).Include(d => d.Trello).Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dashboards/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dashboard = await _context.Dashboard
        //        .Include(d => d.GitHub)
        //        .Include(d => d.Trello)
        //        .Include(d => d.User)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (dashboard == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dashboard);
        //}

        //// GET: Dashboards/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.Set<GitHub>(), "UserId", "UserId");
        //    ViewData["UserId"] = new SelectList(_context.Set<Trello>(), "UserId", "UserId");
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
        //    return View();
        //}

        //// POST: Dashboards/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserId,RepoId,BoardId,DashboardName,DashboardId")] Dashboard dashboard)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(dashboard);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Set<GitHub>(), "UserId", "UserId", dashboard.UserId);
        //    ViewData["UserId"] = new SelectList(_context.Set<Trello>(), "UserId", "UserId", dashboard.UserId);
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", dashboard.UserId);
        //    return View(dashboard);
        //}

        //// GET: Dashboards/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dashboard = await _context.Dashboard.SingleOrDefaultAsync(m => m.Id == id);
        //    if (dashboard == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Set<GitHub>(), "UserId", "UserId", dashboard.UserId);
        //    ViewData["UserId"] = new SelectList(_context.Set<Trello>(), "UserId", "UserId", dashboard.UserId);
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", dashboard.UserId);
        //    return View(dashboard);
        //}

        //// POST: Dashboards/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,RepoId,BoardId,DashboardName,DashboardId")] Dashboard dashboard)
        //{
        //    if (id != dashboard.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(dashboard);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DashboardExists(dashboard.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Set<GitHub>(), "UserId", "UserId", dashboard.UserId);
        //    ViewData["UserId"] = new SelectList(_context.Set<Trello>(), "UserId", "UserId", dashboard.UserId);
        //    ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", dashboard.UserId);
        //    return View(dashboard);
        //}

        //// GET: Dashboards/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var dashboard = await _context.Dashboard
        //        .Include(d => d.GitHub)
        //        .Include(d => d.Trello)
        //        .Include(d => d.User)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (dashboard == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(dashboard);
        //}

        //// POST: Dashboards/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var dashboard = await _context.Dashboard.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Dashboard.Remove(dashboard);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DashboardExists(int id)
        //{
        //    return _context.Dashboard.Any(e => e.Id == id);
        //}
    }
}
