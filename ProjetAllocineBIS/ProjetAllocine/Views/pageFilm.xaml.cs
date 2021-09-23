using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using modelMetier.gestionnaire;
using modelMetier.entity;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetAllocine.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pageFilm : Page
    {
        public pageFilm()
        {
            this.InitializeComponent();
        }
        private Cinema leCinema;
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        GstBDD bdd;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            leCinema = e.Parameter as Cinema;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bdd = new GstBDD();
            lstFilms.ItemsSource = bdd.GetAllFilmsParCinema(leCinema.CodeCinema);
            txtLatitude.Text = bdd.GetAllInfoCinema(leCinema.CodeCinema).LatitudeCine.ToString();
            txtLongitude.Text = bdd.GetAllInfoCinema(leCinema.CodeCinema).LongitudeCine.ToString();
            txtAdresse.Text = bdd.GetAllInfoCinema(leCinema.CodeCinema).AdresseCine.ToString();
            txtNomCinema.Text = "Pour le cinéma " + bdd.GetAllInfoCinema(leCinema.CodeCinema).NomCine.ToString();

            BasicGeoposition snPosition = new BasicGeoposition { Latitude = leCinema.LatitudeCine, Longitude = leCinema.LongitudeCine };
            Geopoint snPoint = new Geopoint(snPosition);



            var MyLandmarks = new List<MapElement>();
            var spaceNeedleIcon = new MapIcon
            {
                Location = snPoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = leCinema.NomCine
            };
            MyLandmarks.Add(spaceNeedleIcon);
            var LandmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarks
            };
            map.Layers.Add(LandmarksLayer);
            map.Center = snPoint;
            map.ZoomLevel = 18;

        }

        private void lstFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fvActeur.ItemsSource = bdd.GetAllActeurParFilm((lstFilms.SelectedItem as Film).CodeFilm);
            txtNbrVote.Text = bdd.GetNotesDuFilm((lstFilms.SelectedItem as Film).CodeFilm).NbVotes.ToString();
            txtTotalVote.Text = bdd.GetNotesDuFilm((lstFilms.SelectedItem as Film).CodeFilm).TotalVotes.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bdd.SetNoteFilm((sldNote.Value).ToString(), (lstFilms.SelectedItem as Film).CodeFilm);
            txtNbrVote.Text = bdd.GetNotesDuFilm((lstFilms.SelectedItem as Film).CodeFilm).NbVotes.ToString();
            txtTotalVote.Text = bdd.GetNotesDuFilm((lstFilms.SelectedItem as Film).CodeFilm).TotalVotes.ToString();
        }
    }
}
