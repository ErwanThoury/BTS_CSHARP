using System;
using MySql.Data.MySqlClient;
using modelMetier.entity;
using System.Collections.Generic;

namespace modelMetier.gestionnaire
{
    public class GstBDD
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        public GstBDD()
        {
            string driver = "server=localhost;user id=root;password=;database=allocined";
            cnx = new MySqlConnection(driver);
            cnx.Open();
        }
        public List<Cinema> GetAllCinema()
        {
            List<Cinema> lesCinemas = new List<Cinema>();

            cmd = new MySqlCommand(" select * from cinema; ", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read()) // Equivalent au Fetch
            {
                Cinema unCinema = new Cinema()
                {
                    CodeCinema = dr[0].ToString(),
                    NomCine = dr[1].ToString(),
                    AdresseCine = dr[2].ToString(),
                    CodePostalCine = dr[3].ToString(),
                    VilleCine = dr[4].ToString(),
                    LatitudeCine = Convert.ToDouble(dr[5]),
                    LongitudeCine = Convert.ToDouble(dr[6]),
                    ImageCine = dr[7].ToString()
                };
                lesCinemas.Add(unCinema);
            }
            dr.Close();
            return lesCinemas;
        }
        public Cinema GetAllInfoCinema(string idCinema)
        {
            Cinema unCinema;
            cmd = new MySqlCommand(" select * from cinema where codeCine= '"+idCinema+"';", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
                unCinema = new Cinema()
                {
                    CodeCinema = dr[0].ToString(),
                    NomCine = dr[1].ToString(),
                    AdresseCine = dr[2].ToString(),
                    CodePostalCine = dr[3].ToString(),
                    VilleCine = dr[4].ToString(),
                    LatitudeCine = Convert.ToDouble(dr[5]),
                    LongitudeCine = Convert.ToDouble(dr[6]),
                    ImageCine = dr[7].ToString()
                };
            dr.Close();
            return unCinema;
        }
        public List<Film> GetAllFilmsParCinema(string idCinema)
        {
            List<Film> lesFilms = new List<Film>();

            cmd = new MySqlCommand(" select codeFilm, nomFilm, ImageFilm from Film inner join projeter on codeFilm = numFilm inner join cinema on numCinema = codeCine where codeCine='"+idCinema+"'; ", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read()) // Equivalent au Fetch
            {
                Film unFilm = new Film()
                {
                    CodeFilm=dr[0].ToString(),
                    NomFilm=dr[1].ToString(),
                    ImageFilm=dr[2].ToString()
                };
                lesFilms.Add(unFilm);
            }
            dr.Close();
            return lesFilms;
        }
        public List<Acteur> GetAllActeurParFilm(string idFilm)
        {
            List<Acteur> lesActeurs = new List<Acteur>();

            cmd = new MySqlCommand(" select nomActeur, imageActeur from Film inner join jouer on codeFilm = numFilm inner join Acteur on numActeur = codeActeur where codeFilm='" + idFilm + "'; ", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read()) // Equivalent au Fetch
            {
                Acteur unActeur = new Acteur()
                {
                    NomActeur = dr[0].ToString(),
                    ImageActeur = dr[1].ToString()
                };
                lesActeurs.Add(unActeur);
            }
            dr.Close();
            return lesActeurs;
        }
        public Film GetNotesDuFilm(string idFilm)
        {


            cmd = new MySqlCommand(" select nbVotes, totalVotes from Film where codeFilm='" + idFilm + "'; ", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            Film lesNotes = new Film()
            {
                NbVotes = Convert.ToInt32(dr[0]),
                TotalVotes = Convert.ToInt32(dr[1])
            };


            dr.Close();
            return lesNotes;
        }
        public void SetNoteFilm(string nouvelleNote, string codeFilm)
        {
            string nouveauTotal = (Convert.ToInt32(this.GetNotesDuFilm(codeFilm).TotalVotes) + Convert.ToInt32(nouvelleNote)).ToString();
            string nouveauNbVotes = (Convert.ToInt32(this.GetNotesDuFilm(codeFilm).NbVotes)+1).ToString();
            cmd = new MySqlCommand("update film set totalVotes =" + nouveauTotal+", nbVotes=" +nouveauNbVotes + " where codeFilm='"+codeFilm+"';", cnx);
            cmd.ExecuteNonQuery();
        }
    }
}
