using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mattaudio.Data;
using mattaudio.Models;
using mattaudio.Pages;

namespace mattaudio.Pages.Tracks
{
    public class EditModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(mattaudio.Data.mattaudioContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Something gone wrong");
                return NotFound();
            }

            Track = await _context.Track.FirstOrDefaultAsync(m => m.TrackID == id);

            if (Track == null)
            {
                _logger.LogError("Something gone wrong");
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TrackExists(Track.TrackID))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "Something gone wrong");
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.TrackID == id);
        }
    }
}
