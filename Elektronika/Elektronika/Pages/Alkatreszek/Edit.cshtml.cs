#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Elektronika.Data;
using Elektronika.Models;

namespace Elektronika.Pages.Alkatreszek
{
    public class EditModel : PageModel
    {
        private readonly Elektronika.Data.ElektronikaContext _context;

        public EditModel(Elektronika.Data.ElektronikaContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Alkatresz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlkatreszExists(Alkatresz.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlkatreszExists(int id)
        {
            return _context.Alkatresz.Any(e => e.Id == id);
        }
    }
}
