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
using GestionnaireBDD;
using ClassesMetier;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPGestionSalles
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
        GstBdd bdd;
        double prix;
        List<Place> ldp;
        List<Place> lp;
        private async void btnReserver_Click(object sender, RoutedEventArgs e)
        {
            if(lstManifs.SelectedItem == null)
            {
                var dialog1 = new MessageDialog("Sélectionner une manif!");
                await dialog1.ShowAsync();
            }
            else
            {
                if(gvPlaces.SelectedItem == null)
                {
                    var dialog2 = new MessageDialog("Sélectionner une place!");
                    await dialog2.ShowAsync();
                }
                else
                {
                    foreach(Place p in ldp)
                    {
                        bdd.ReserverPlace(p.IdPlace, (lstManifs.SelectedItem as Manifestation).LaSalle.IdSalle, (lstManifs.SelectedItem as Manifestation).IdManif);
                        p.Etat = 'o';
                        p.Occupee = true;
                    }
                    var dialog = new MessageDialog("Vos places sont réservées");
                    await dialog.ShowAsync();
                    gvPlaces.ItemsSource = lp;
                    prix = 0;
                    txtTotal.Text = prix.ToString();
                }
            }


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bdd = new GstBdd();
            lstManifs.ItemsSource = bdd.GetAllManifestations();
            lstTarifs.ItemsSource = bdd.GetAllTarifs();
        }
        
        private void lstManifs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lp = bdd.GetAllPlacesByIdManifestation((lstManifs.SelectedItem as Manifestation).IdManif, (lstManifs.SelectedItem as Manifestation).LaSalle.IdSalle);
            gvPlaces.ItemsSource = lp;
            prix = 0;
            txtTotal.Text = prix.ToString();
            ldp = new List<Place>();
            txtNumSalle.Text = (lstManifs.SelectedItem as Manifestation).LaSalle.IdSalle.ToString();
            txtNomSalle.Text = (lstManifs.SelectedItem as Manifestation).LaSalle.NomSalle.ToString();
            txtNbPlaces.Text = (lstManifs.SelectedItem as Manifestation).LaSalle.NbPlaces.ToString();
        }
        
        private async void gvPlaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gvPlaces.SelectedItem != null)
            {
                Place p = gvPlaces.SelectedItem as Place;
                bool occupee = p.Occupee;


                if (occupee)
                {
                    var dialog = new MessageDialog("La place est déjà occupée!");
                    await dialog.ShowAsync();
                }

                else
                {
                    if (p.Etat == 'r')
                    {
                        p.Etat = 'l';
                        prix -= p.Prix;
                        txtTotal.Text = prix.ToString();
                        ldp.Remove(p);
                    }
                    else
                    {
                        p.Etat = 'r';
                        prix += p.Prix;
                        ldp.Add(p);
                        txtTotal.Text = prix.ToString();
                    }
                }
            }

            
        }
    }
}
