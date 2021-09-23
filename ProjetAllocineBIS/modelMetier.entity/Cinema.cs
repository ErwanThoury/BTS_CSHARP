using System;
using System.Collections.Generic;
using System.Text;

namespace modelMetier.entity
{
    public class Cinema
    {
        public string CodeCinema { get; set; }
        public string NomCine { get; set; }
        public string AdresseCine { get; set; }
        public string CodePostalCine { get; set; }
        public string VilleCine { get; set; }
        public double LatitudeCine { get; set; }
        public double LongitudeCine { get; set; }
        public string ImageCine { get; set; }
        public List<Film> LesFilms { get; set; }


    }
}
