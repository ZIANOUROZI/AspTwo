using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspTwo.Data;
using AspTwo.Models;

namespace AspTwo.Controllers
{
    public class CourseClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseClasses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseClasses.Include(c => c.Teachers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseClass = await _context.CourseClasses
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(m => m.CourseClassId == id);
            if (courseClass == null)
            {
                return NotFound();
            }

            return View(courseClass);
        }

        // GET: CourseClasses/Create
        public IActionResult Create()
        {
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: CourseClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseClassId,Title,FkTeacherId")] CourseClass courseClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", courseClass.FkTeacherId);
            return View(courseClass);
        }

        // GET: CourseClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseClass = await _context.CourseClasses.FindAsync(id);
            if (courseClass == null)
            {
                return NotFound();
            }
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", courseClass.FkTeacherId);
            return View(courseClass);
        }

        // POST: CourseClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseClassId,Title,FkTeacherId")] CourseClass courseClass)
        {
            if (id != courseClass.CourseClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseClassExists(courseClass.CourseClassId))
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
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", courseClass.FkTeacherId);
            return View(courseClass);
        }

        // GET: CourseClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseClass = await _context.CourseClasses
                .Include(c => c.Teachers)
                .FirstOrDefaultAsync(m => m.CourseClassId == id);
            if (courseClass == null)
            {
                return NotFound();
            }

            return View(courseClass);
        }

        // POST: CourseClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseClass = await _context.CourseClasses.FindAsync(id);
            if (courseClass != null)
            {
                _context.CourseClasses.Remove(courseClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseClassExists(int id)
        {
            return _context.CourseClasses.Any(e => e.CourseClassId == id);
        }
    }
}
