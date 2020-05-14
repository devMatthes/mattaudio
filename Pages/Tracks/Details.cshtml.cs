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
    public class DetailsModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(mattaudio.Data.mattaudioContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

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
    }
}
