using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Data;
using MegaDeskWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace MegaDeskWeb.Pages.DesksQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Data.MegaDeskWebContext _context;

        public IndexModel(MegaDeskWeb.Data.MegaDeskWebContext context)
        {
            _context = context;
        }

        public SelectList Customers { get; set; }

        public IList<DeskQuote> DeskQuote { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string CustomerName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> quoteQuery = from q in _context.DeskQuote
                                           orderby q.CustomerName
                                           select q.CustomerName;

            var quotes = from q in _context.DeskQuote
                         select q;

            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(q => q.CustomerName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CustomerName))
            {
                quotes = quotes.Where(q => q.CustomerName == CustomerName);
            }

            Customers = new SelectList(await quoteQuery.Distinct().ToListAsync());

            if (_context.DeskQuote != null)
            {
                DeskQuote = await quotes
                .Include(d => d.DeliveryType)
                .Include(d => d.Desk)
                .ToListAsync();
            }
        }
    }
}
