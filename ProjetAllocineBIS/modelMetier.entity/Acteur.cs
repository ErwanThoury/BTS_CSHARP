using System;
using System.Collections.Generic;
using System.Text;

namespace modelMetier.entity
{
    public class Acteur
    {
        public string CodeActeur { get; set; }
        public string NomActeur { get; set; }
        public string ImageActeur { get; set; }
        public List<Film> LesFilms { get; set; }


    }
}
