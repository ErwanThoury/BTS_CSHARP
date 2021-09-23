using System;
using System.Collections.Generic;
using System.Text;

namespace modelMetier.entity
{
    public class Film
    {
        public string CodeFilm { get; set; }
        public string NomFilm { get; set; }
        public string ImageFilm { get; set; }
        public string GenreFilm { get; set; }
        public int NbVotes { get; set; }
        public int TotalVotes { get; set; }
        public List<Acteur> LesActeurs { get; set; }
        public List<Cinema> LesCinemas { get; set; }
    }
}
