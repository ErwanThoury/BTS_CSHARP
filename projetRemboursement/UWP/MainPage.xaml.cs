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
using ModelObjet;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<string> lesCategories;
        List<string> lesEtats;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private  void CmdValider_Click(object sender, RoutedEventArgs e)
        {
            // A vous de jouer :)
           
            int nbJour = Convert.ToInt32(sldNbJours.Value);
            string categorie = cboCategories.SelectedItem.ToString();
            string etat = cboEtats.SelectedItem.ToString();
            bool membre = true;
            if(rbNon.IsChecked == true)
            {
                membre = false;
            }

            int prix = Convert.ToInt32(txtPrix.Text);
            lblRemboursement.Text = Condition.CalculerMontantRembourse(nbJour,categorie,membre,etat,prix).ToString();
        }

        private void SldNbJours_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            lblNbJours.Text =sldNbJours.Value.ToString();
            // A vous de jouer :)

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Ne pas modifier les lignes ci-dessous
            lesCategories = new List<string>();
            lesCategories.Add("Jouet"); lesCategories.Add("Livre"); lesCategories.Add("Informatique");
            cboCategories.ItemsSource = lesCategories;

            lesEtats = new List<string>();
            lesEtats.Add("Abimé"); lesEtats.Add("Très abimé"); lesEtats.Add("Bon"); lesEtats.Add("Très bon");
            cboEtats.ItemsSource = lesEtats;
        }
    }
}
