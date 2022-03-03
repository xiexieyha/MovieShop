﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   
    public class Movie
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Column(TypeName ="varchar")]
        public string Title { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }

        // Naviagtion
        public List<Trailer> Trailers { get; set; }
        public List<MovieGenre>? GernesOfMovie { get; set; }
        public List<MovieCast> MovieCast { get; set; }
        public List<MovieCrew> CrewesOfMovie { get; }
        public List<Review> ReviewOfMovie { get; set; }
        public List<Favorite> FavoriteOfMovie { get; set; }
        public List<Purchase> PurchaseOfMovie { get; set; }
    }
}
