using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InterdispProj1.Models;
using InterdispProj1.Data;

namespace InterdispProj1.Controllers
{
    public class DataEntryController : Controller
    {
        private readonly IDataEntryRepository _context;

        public DataEntryController(IDataEntryRepository dataEntryRepository)
        {
            _context = dataEntryRepository;
        }

        // GET: DataEntry
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: DataEntry/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntry = await _context.GetById(id);
            if (dataEntry == null)
            {
                return NotFound();
            }

            return View(dataEntry);
        }

        // GET: DataEntry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To,Value")] DataEntry dataEntry)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(dataEntry);
                return RedirectToAction(nameof(Index));
            }
            return View(dataEntry);
        }

        // GET: DataEntry/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntry = await _context.GetById(id);
            if (dataEntry == null)
            {
                return NotFound();
            }
            return View(dataEntry);
        }

        // POST: DataEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,From,To,Value")] DataEntry dataEntry)
        {
            if (id != dataEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(dataEntry);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( await _context.DataEntryExists(dataEntry.Id) == false)
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
            return View(dataEntry);
        }

        // GET: DataEntry/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataEntry = await _context.GetById(id);
            if (dataEntry == null)
            {
                return NotFound();
            }

            return View(dataEntry);
        }

        // POST: DataEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dataEntry = await _context.GetById(id);
            await _context.Delete(dataEntry);
            return RedirectToAction(nameof(Index));
        }


    }
}
