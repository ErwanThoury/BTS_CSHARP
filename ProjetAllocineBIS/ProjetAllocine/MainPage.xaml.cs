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
using modelMetier.gestionnaire;
using Windows.UI.Xaml.Navigation;
using modelMetier.entity;


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjetAllocine
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        GstBDD Bdd;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Bdd = new GstBDD();
            lstCinemas.ItemsSource = Bdd.GetAllCinema();
            int strasbourg;
        }

        private void lstCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.pageFilm), (lstCinemas.SelectedItem) as Cinema);
        }
    }
}
