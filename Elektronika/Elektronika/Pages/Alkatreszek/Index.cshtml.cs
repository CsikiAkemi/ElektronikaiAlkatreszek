#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Elektronika.Data;
using Elektronika.Models;

namespace Elektronika.Pages.Alkatreszek
{
    public class IndexModel : PageModel
    {
        private readonly Elektronika.Data.ElektronikaContext _context;

        public IndexModel(Elektronika.Data.ElektronikaContext context)
        {
            _context = context;
        }

        public IList<Alkatresz> Alkatresz { get;set; }

        public async Task OnGetAsync()
        {
            Alkatresz = await _context.Alkatresz.ToListAsync();
        }
    }
}
