#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Elektronika.Data;
using Elektronika.Models;

namespace Elektronika.Pages.Alkatreszek
{
    public class CreateModel : PageModel
    {
        private readonly Elektronika.Data.ElektronikaContext _context;

        public CreateModel(Elektronika.Data.ElektronikaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alkatresz Alkatresz { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Alkatresz.Add(Alkatresz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
