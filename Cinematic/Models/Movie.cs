using System;
using System.ComponentModel.DataAnnotations;

namespace Cinematic.Models
{
	public class Movie
	{
        [Key]
        public string Id { get; set; }
        public string? name { get; set; }
        public string? releaseDate { get; set; }
        public PosterImage? posterImage { get; set; }
       
    }

    public class PosterImage
    {
        [Key]
        public int Id { get; set; }
        public string? url { get; set; }
    }
}

