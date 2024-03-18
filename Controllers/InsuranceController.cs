using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsuranceCLP.Data;
using InsuranceCLP.Models;

namespace InsuranceCLP.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly InsuranceCLPContext _context;

        public InsuranceController(InsuranceCLPContext context)
        {
            _context = context;
        }

        // GET: Insurance
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsuranceModel.ToListAsync());
        }

        // GET: Insurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceModel = await _context.InsuranceModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceModel == null)
            {
                return NotFound();
            }

            return View(insuranceModel);
        }

        // GET: Insurance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurance/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Value,UserId")] InsuranceModel insuranceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceModel);
        }

        // GET: Insurance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceModel = await _context.InsuranceModel.FindAsync(id);
            if (insuranceModel == null)
            {
                return NotFound();
            }
            return View(insuranceModel);
        }

        // POST: Insurance/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Value,UserId")] InsuranceModel insuranceModel)
        {
            if (id != insuranceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceModelExists(insuranceModel.Id))
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
            return View(insuranceModel);
        }

        // GET: Insurance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceModel = await _context.InsuranceModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceModel == null)
            {
                return NotFound();
            }

            return View(insuranceModel);
        }

        // POST: Insurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceModel = await _context.InsuranceModel.FindAsync(id);
            if (insuranceModel != null)
            {
                _context.InsuranceModel.Remove(insuranceModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceModelExists(int id)
        {
            return _context.InsuranceModel.Any(e => e.Id == id);
        }
    }
}
