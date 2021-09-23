using ClassesMetier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GestionnaireBDD
{
    public class GstBdd
    {
        MySqlConnection cnx;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public GstBdd()
        {
            string driver = "server=localhost;user id=root;password=;database=gestionsalles";
            cnx = new MySqlConnection(driver);
            cnx.Open();
        }

        public List<Manifestation> GetAllManifestations()
        {
            List<Manifestation> l = new List<Manifestation>();

            cmd = new MySqlCommand(" select * from manifestation inner join salle on idSalle = numSalle; ", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read()) // Equivalent au Fetch
            {
                Manifestation m = new Manifestation()
                {
                    IdManif = Convert.ToInt32(dr[0].ToString()),
                    NomManif = dr[1].ToString(),
                    DateDebutManif= dr[2].ToString(),
                    DateFinManif= dr[3].ToString(),
                    LaSalle = new Salle() 
                    { 
                        IdSalle = Convert.ToInt32(dr[4]),
                        NomSalle = dr[6].ToString(),
                        NbPlaces = Convert.ToInt32(dr[7].ToString())
                    }

                };
                l.Add(m);
            }
            dr.Close();

            return l;
        }

        public List<Place> GetAllPlacesByIdManifestation(int idManif,int idSalle)
        {
            List<Place> l = new List<Place>();
            //cmd = new MySqlCommand(" select numPlace, numTarif, libre from manifestation inner join occuper on idManif = numManif inner join place on numPlace = place.idPlace where idManif =" + idManif + " and place.numSalle = "+idSalle+";", cnx);
            cmd = new MySqlCommand("select numPlace, numTarif, libre, prix from manifestation inner join occuper on idManif = numManif inner join place on numPlace = place.idPlace inner join tarif on place.numTarif = tarif.idTarif where idManif = " + idManif + " and place.numSalle = " + idSalle + ";", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read()) // Equivalent au Fetch
            {
                bool verif;
                char etatA;
                if (Convert.ToInt32(dr[2]) == 1)
                {
                    etatA = 'o';
                    verif = true;
                }
                else
                {
                    etatA = 'l';
                    verif = false;
                }

                Place p = new Place()
                {
                    IdPlace = Convert.ToInt32(dr[0]),
                    CodeTarif = Convert.ToChar(dr[1]),
                    Occupee = verif,
                    Prix = Convert.ToDouble(dr[3]),
                    Etat = etatA
                };
                l.Add(p);
            }
            dr.Close();

            return l;
        }

        public List<Tarif> GetAllTarifs()
        {
            List<Tarif> l = new List<Tarif>();
            cmd = new MySqlCommand(" select * from tarif;", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read()) // Equivalent au Fetch
            {
                Tarif t = new Tarif()
                {
                    IdTarif = Convert.ToChar(dr[0]),
                    NomTarif = dr[1].ToString(),
                    Prix = Convert.ToInt32(dr[2])
                };
                l.Add(t);
            }
            dr.Close();
            return l;
        }

        public void ReserverPlace(int idPlace, int idSalle,int idManif)
        {
            cmd = new MySqlCommand(" update occuper set libre =1  where numPlace=" + idPlace+" and numSalle ="+idSalle+" and numManif = "+idManif+";", cnx);
            cmd.ExecuteNonQuery();
        }
    }
}
