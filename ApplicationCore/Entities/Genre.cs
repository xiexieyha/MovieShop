﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Genre
    {
       
        public int Id { get; set; }

        
        public string Name { get; set; }

        //navigational
        public List<MovieGenre> MoviesOfGenre { get; set; }

    }
}
