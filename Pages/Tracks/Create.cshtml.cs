using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mattaudio.Data;
using mattaudio.Models;

namespace mattaudio.Pages.Tracks
{
    public class CreateModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;

        public CreateModel(mattaudio.Data.mattaudioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Track Track { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Track.Add(Track);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
