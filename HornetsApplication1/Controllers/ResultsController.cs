using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HornetsApplication1.Models;

namespace HornetsApplication1.Controllers
{
    public class ResultsController : Controller
    {
        private readonly SchoolContext _context;

        public ResultsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Result.Include(r => r.Class).Include(r => r.Exam).Include(r => r.Student).Include(r => r.Subject);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result
                .Include(r => r.Class)
                .Include(r => r.Exam)
                .Include(r => r.Student)
                .Include(r => r.Subject)
                .SingleOrDefaultAsync(m => m.ResultId == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "ClassId");
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "ExamId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResultId,StudentId,ClassId,ExamId,SubjectId,Year,Grade")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "ClassId", result.ClassId);
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "ExamId", result.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", result.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", result.SubjectId);
            return View(result);
        }

        // GET: Results/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result.SingleOrDefaultAsync(m => m.ResultId == id);
            if (result == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "ClassId", result.ClassId);
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "ExamId", result.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", result.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", result.SubjectId);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ResultId,StudentId,ClassId,ExamId,SubjectId,Year,Grade")] Result result)
        {
            if (id != result.ResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultExists(result.ResultId))
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
            ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "ClassId", result.ClassId);
            ViewData["ExamId"] = new SelectList(_context.Exam, "ExamId", "ExamId", result.ExamId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", result.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", result.SubjectId);
            return View(result);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result
                .Include(r => r.Class)
                .Include(r => r.Exam)
                .Include(r => r.Student)
                .Include(r => r.Subject)
                .SingleOrDefaultAsync(m => m.ResultId == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _context.Result.SingleOrDefaultAsync(m => m.ResultId == id);
            _context.Result.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultExists(string id)
        {
            return _context.Result.Any(e => e.ResultId == id);
        }
    }
}
