using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mattaudio.Data;
using mattaudio.Models;

namespace mattaudio.Pages.Tracks
{
    public class DetailsModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;

        public DetailsModel(mattaudio.Data.mattaudioContext context)
        {
            _context = context;
        }

        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.Track.FirstOrDefaultAsync(m => m.TrackID == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
