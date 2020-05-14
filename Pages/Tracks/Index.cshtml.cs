using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using mattaudio.Data;
using mattaudio.Models;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Google.Apis.Services;

namespace mattaudio.Pages.Tracks
{
    public class IndexModel : PageModel
    {
        private readonly mattaudio.Data.mattaudioContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(mattaudio.Data.mattaudioContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Track> Track { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string TrackArtist { get; set; }
        public string TrackTitle { get; set; }
        
        //async/await
        public async Task OnGetAsync()
        {
            //LINQ
            var tracks = from m in _context.Track
                         select m;
            
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                try {
                    tracks = tracks.Where(s => s.Title.Contains(SearchString));
                }
                catch (Exception ex) {
                    _logger.LogError(ex, "Something gone wrong");
                    throw;
                }
            }

            Track = await tracks.ToListAsync();

            /*var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                //ApiKey = "AIzaSyAsGA59IPSi5JFapZk-zZ2sysoaUbAEGDs"
                ApiKey = "AIzaSyCISgKX5TuyCAqmdEXzPC_ziS4QYNVm2ZA"
            });

            foreach (var x in Track)
            {
                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = x.Artist + x.Title;
                searchListRequest.MaxResults = 1;
                searchListRequest.Type = "video";

                var searchListResponse = await searchListRequest.ExecuteAsync();
                foreach (var searchResult in searchListResponse.Items){
                    x.VideoID = searchResult.Id.VideoId;
                }
            }*/
        }
    }
}
