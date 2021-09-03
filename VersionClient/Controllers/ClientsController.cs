using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VersionClient.Models;

namespace VersionClient.Controllers
{
    public class ClientsController : Controller
    {
        private readonly VersionContext _context;

        public ClientsController(VersionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Client.ToListAsync());
        }

        //GET: Clients/Create
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClient,NameClient,UrlLogin")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


    }
}
