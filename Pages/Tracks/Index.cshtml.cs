using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IndexModel(mattaudio.Data.mattaudioContext context)
        {
            _context = context;
        }

        public IList<Track> Track { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TrackGenre { get; set; }
        public string TrackTitle { get; set; }
        
        //async/await
        public async Task OnGetAsync()
        {
            //LINQ_start
            var genreQuery = from m in _context.Track
                             orderby m.Genre
                             select m.Genre;

            var tracks = from m in _context.Track
                         select m;
            //LINQ_end
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                tracks = tracks.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(TrackGenre))
            {
                tracks = tracks.Where(x => x.Genre == TrackGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Track = await tracks.ToListAsync();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAsGA59IPSi5JFapZk-zZ2sysoaUbAEGDs"
            });

            foreach (var x in Track)
            {
                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = x.Title;
                searchListRequest.MaxResults = 1;
                searchListRequest.Type = "video";

                var searchListResponse = await searchListRequest.ExecuteAsync();
                foreach (var searchResult in searchListResponse.Items){
                    //VideoID.Add(searchResult.Id.VideoId);
                    x.VideoID = searchResult.Id.VideoId;
                }
            }
        }
    }
}
