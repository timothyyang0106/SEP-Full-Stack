﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(24)] public string Name { get; set; } = null!;

        public ICollection<MovieGenre> MoviesOfGenre { get; set; } = null!;
    }
}