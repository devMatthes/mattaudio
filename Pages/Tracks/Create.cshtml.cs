using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using mattaudio.Data;
using mattaudio.Models;
using mattaudio.Pages;

namespace mattaudio.Pages.Tracks
{
    public class CreateModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(mattaudio.Data.mattaudioContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            try {
                return Page();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Something gone wrong");
                throw;
            }
        }

        [BindProperty]
        public Track Track { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Something gone wrong");
                return Page();
            }
            try {
                _context.Track.Add(Track);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception ex) {
                _logger.LogWarning(ex, "Couldn't add a song");
                throw;
            }
        }
    }
}
