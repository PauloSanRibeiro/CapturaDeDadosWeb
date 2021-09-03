using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VersionClient.Models;

namespace VersionClient.Services
{
    public class ClientService
    {
        private readonly VersionContext _context;

        public ClientService(VersionContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await _context.Client.OrderBy(x => x.NameClient).ToListAsync();
        }

        //Insert de cadastro cliente
        public async Task InsertAsync(Client obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
