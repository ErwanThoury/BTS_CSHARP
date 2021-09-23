using System;

namespace ClassesMetier
{
    public class Manifestation
    {
        public int IdManif { get; set; }
        public string NomManif { get; set; }
        public string DateDebutManif { get; set; }
        public string DateFinManif { get; set; }
        public Salle LaSalle { get; set; }
    }
}
