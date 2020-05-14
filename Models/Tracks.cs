using System;
using System.ComponentModel.DataAnnotations;

namespace mattaudio.Models
{
    public class Track
    {
        public int TrackID { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }

        public string VideoID { get; set; }
    }
}