using System;
using System.ComponentModel.DataAnnotations;

namespace mattaudio.Models
{
    public class Track
    {
        public int TrackID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }

        public string VideoID { get; set; }
    }
}