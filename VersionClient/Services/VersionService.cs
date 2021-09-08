using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VersionClient.Models;

namespace VersionClient.Services
{
    public class VersionService
    {
        private readonly VersionContext _context;

        public VersionService(VersionContext context)
        {
            _context = context;
        }

    }
}
