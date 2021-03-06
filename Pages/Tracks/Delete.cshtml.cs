using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mattaudio.Data;
using mattaudio.Models;

namespace mattaudio.Pages.Tracks
{
    public class DeleteModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(mattaudio.Data.mattaudioContext context, ILogger<DeleteModel> logger)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Something gone wrong");
                return NotFound();
            }

            Track = await _context.Track.FindAsync(id);

            if (Track != null)
            {
                _context.Track.Remove(Track);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
