﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        [Key]
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }

        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
    }
}
