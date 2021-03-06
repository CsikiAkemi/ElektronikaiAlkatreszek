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
    public class DeleteModel : PageModel
    {
        private readonly Elektronika.Data.ElektronikaContext _context;

        public DeleteModel(Elektronika.Data.ElektronikaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Alkatresz Alkatresz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alkatresz = await _context.Alkatresz.FirstOrDefaultAsync(m => m.Id == id);

            if (Alkatresz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alkatresz = await _context.Alkatresz.FindAsync(id);

            if (Alkatresz != null)
            {
                _context.Alkatresz.Remove(Alkatresz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
