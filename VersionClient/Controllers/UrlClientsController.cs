using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VersionClient.Models;

namespace VersionClient.Controllers
{
    public class UrlClientsController : Controller
    {
        private readonly VersionContext _context;

        public UrlClientsController(VersionContext context)
        {
            _context = context;
        }

        // GET: UrlClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Version.ToListAsync());
        }

        // GET: UrlClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlClient = await _context.Version
                .FirstOrDefaultAsync(m => m.IdUrlClient == id);
            if (urlClient == null)
            {
                return NotFound();
            }

            return View(urlClient);
        }

        // GET: UrlClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UrlClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address")] UrlClient urlClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urlClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urlClient);
        }

        // GET: UrlClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlClient = await _context.Version.FindAsync(id);
            if (urlClient == null)
            {
                return NotFound();
            }
            return View(urlClient);
        }

        // POST: UrlClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address")] UrlClient urlClient)
        {
            if (id != urlClient.IdUrlClient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urlClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrlClientExists(urlClient.IdUrlClient))
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
            return View(urlClient);
        }

        // GET: UrlClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlClient = await _context.Version
                .FirstOrDefaultAsync(m => m.IdUrlClient == id);
            if (urlClient == null)
            {
                return NotFound();
            }

            return View(urlClient);
        }

        // POST: UrlClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urlClient = await _context.Version.FindAsync(id);
            _context.Version.Remove(urlClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrlClientExists(int id)
        {
            return _context.Version.Any(e => e.IdUrlClient == id);
        }
    }
}
