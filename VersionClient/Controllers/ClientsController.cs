using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VersionClient.Models;
using System.Net.Http;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace VersionClient.Controllers
{
    public class ClientsController : Controller
    {
        private readonly VersionContext _context;
        private const int _quantMaxLinhasPorPagina = 5;

        public ClientsController(VersionContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            //ViewBag.ListaTamPag = new SelectList(new int[] { _quantMaxLinhasPorPagina, 10, 15, 20 }, _quantMaxLinhasPorPagina);

            return View(await _context.Client.OrderBy(x => x.NameClient).ToListAsync());
        }

        [Authorize]
        //GET: Clients/Create
        public IActionResult Create()
        {

            return View();
        }
        [Authorize]
        //POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClient,NameClient,UrlLogin")] Client client)
        {
            if (_context.Client.Any(c => c.NameClient == client.NameClient))
            {
                ModelState.AddModelError("Nome", $"Cliente já cadastrado");
            }

            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        //GET: Clients/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FirstOrDefaultAsync(m => m.IdClient == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        //GET: Clients/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //POST: Clients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClient,NameClient,UrlLogin")] Client client)
        {
            if (id != client.IdClient)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (ApplicationException)
                {
                    if (!ClientExists(client.IdClient))
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

            return View(client);
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.IdClient == id);
        }


        //GET: Client/Delete
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FirstOrDefaultAsync(m => m.IdClient == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        //POST: Client/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
