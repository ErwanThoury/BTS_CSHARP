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
using ModelMetier;
using Windows.UI.Popups;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjetTraders
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
        List<ActionReelle> lesActionsReelles;
        Dictionary<string, List<ActionAchetee>> dico;
        List<string> lesTraders;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lesActionsReelles = new List<ActionReelle>();
            dico = new Dictionary<string, List<ActionAchetee>>();
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 14
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145
                }
            );
            lesActionsReelles.Add
            (
                new ActionReelle()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130
                }
            );


            dico.Add
            ("Enzo", new List<ActionAchetee>()
            {
                new ActionAchetee()
                {
                    CodeAction = "AAPL",
                    NomAction = "Apple",
                    ValeurAction = 200,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "MSFT",
                    NomAction = "Microsoft",
                    ValeurAction = 140,
                    PrixAchat = 100,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 35,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "IBM",
                    NomAction = "International Business Machines",
                    ValeurAction = 140,
                    PrixAchat = 110,
                    Quantite = 40
                }
            }
            );
            dico.Add
            ("Noa", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "FB",
                    NomAction = "Facebook",
                    ValeurAction = 180,
                    PrixAchat = 210,
                    Quantite = 10
                },
                new ActionAchetee()
                {
                    CodeAction = "AXA",
                    NomAction = "Axa assurances",
                    ValeurAction = 25,
                    PrixAchat = 15,
                    Quantite = 20
                },
                new ActionAchetee()
                {
                    CodeAction = "SAP",
                    NomAction = "SAP SE",
                    ValeurAction = 120,
                    PrixAchat = 100,
                    Quantite = 30
                }
            }
            );
            dico.Add
            ("Lilou", new List<ActionAchetee>()
                {
                new ActionAchetee()
                {
                    CodeAction = "TWTR",
                    NomAction = "Twitter",
                    ValeurAction = 40,
                    PrixAchat = 25,
                    Quantite = 50
                },
                new ActionAchetee()
                {
                    CodeAction = "INTC",
                    NomAction = "Intel Corporation",
                    ValeurAction = 50,
                    PrixAchat = 35,
                    Quantite = 15
                },
                new ActionAchetee()
                {
                    CodeAction = "VMW",
                    NomAction = "VMware",
                    ValeurAction = 145,
                    PrixAchat = 150,
                    Quantite = 30
                },
                new ActionAchetee()
                {
                    CodeAction = "TXN",
                    NomAction = "Texas Instrument Incorporated",
                    ValeurAction = 130,
                    PrixAchat = 140,
                    Quantite = 25
                }
            }
            );
            lesTraders = new List<string>();
            lesTraders.Add("Enzo");
            lesTraders.Add("Noa");
            lesTraders.Add("Lilou");

            lvTraders.ItemsSource = lesTraders;
            lvActionReelle.ItemsSource = lesActionsReelles;
            
        }
        private async void BtnAcheter_Click(object sender, RoutedEventArgs e)
        {
            if(lvActionReelle.SelectedItem == null)
            {
                var dialog5 = new MessageDialog("Selectionne une action!");
                await dialog5.ShowAsync();
            }
            else
            {
                if(txtPrixAchat.Text == "")
                {
                    var dialog6 = new MessageDialog("Saisissez un prix d'achat!");
                    await dialog6.ShowAsync();
                }
                else
                {
                    if(txtQuantite.Text == "")
                    {
                        var dialog7 = new MessageDialog("Saisissez une quantite");
                        await dialog7.ShowAsync();
                    }
                    else
                    {
                        ActionAchetee actionAchetee = new ActionAchetee()
                        {
                            CodeAction = (lvActionReelle.SelectedItem as ActionReelle).CodeAction,
                            NomAction = (lvActionReelle.SelectedItem as ActionReelle).NomAction,
                            ValeurAction = (lvActionReelle.SelectedItem as ActionReelle).ValeurAction,
                            PrixAchat = Convert.ToDouble(txtPrixAchat.Text),
                            Quantite = Convert.ToInt32(txtQuantite.Text)

                        };
                        dico[lvTraders.SelectedItem.ToString()].Add(actionAchetee);
                        lvActionAchat.ItemsSource = null;
                        lvActionAchat.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
                        double mtPortefeuille = 0;
                        foreach (ActionAchetee aa in dico[lvTraders.SelectedItem.ToString()])
                        {
                            mtPortefeuille += aa.Quantite * aa.PrixAchat;
                        }
                        txtTotal.Text = mtPortefeuille.ToString();
                        txtNomAction.Text = "";
                        txtPrixAchatAction.Text = "";
                        txtQuantiteAchetee.Text = "";
                        txtValeurAction.Text = "";
                    }
                }
            }
            

        }

        private async void BtnVendre_Click(object sender, RoutedEventArgs e)
        {
            if (lvActionAchat.SelectedItem == null)
            {
                var dialog1 = new MessageDialog("Selectionne une action!");
                await dialog1.ShowAsync();
            }
            else
            {
                if (txtQuantiteVendue.Text == "")
                {
                    var dialog = new MessageDialog("Indique une quantite!");
                    await dialog.ShowAsync();
                }
                else
                {
                    ((lvActionAchat.SelectedItem) as ActionAchetee).Quantite -= Convert.ToInt32(txtQuantiteVendue.Text);
                    if(((lvActionAchat.SelectedItem) as ActionAchetee).Quantite < 0)
                    {
                        var dialog3 = new MessageDialog("Vous n'avez pas assez!");
                        await dialog3.ShowAsync();
                        ((lvActionAchat.SelectedItem) as ActionAchetee).Quantite += Convert.ToInt32(txtQuantiteVendue.Text);
                    }
                    else
                    {
                        if(((lvActionAchat.SelectedItem) as ActionAchetee).Quantite == 0)
                        {
                            dico[lvTraders.SelectedItem.ToString()].Remove(lvActionAchat.SelectedItem as ActionAchetee);
                        }
                        lvActionAchat.ItemsSource = null;
                        lvActionAchat.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
                        txtNomAction.Text = "";
                        txtPrixAchatAction.Text = "";
                        txtQuantiteAchetee.Text = "";
                        txtValeurAction.Text = "";
                        double mtPortefeuille = 0;
                        foreach (ActionAchetee aa in dico[lvTraders.SelectedItem.ToString()])
                        {
                            mtPortefeuille += aa.Quantite * aa.PrixAchat;
                        }
                        txtTotal.Text = mtPortefeuille.ToString();
                    }
                }
            }
        }

        private void LvTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvTraders.SelectedItem != null)
            {
                lvActionAchat.ItemsSource = dico[lvTraders.SelectedItem.ToString()];
                txtNomAction.Text = "";
                txtPrixAchatAction.Text = "";
                txtQuantiteAchetee.Text = "";
                txtValeurAction.Text = "";
                double mtPortefeuille = 0;
                foreach (ActionAchetee aa in dico[lvTraders.SelectedItem.ToString()])
                {
                    mtPortefeuille += aa.Quantite * aa.PrixAchat;
                }
                txtTotal.Text = mtPortefeuille.ToString();
            }
        }

        private void LvActionAchat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(lvActionAchat.SelectedItem != null)
            {
                txtNomAction.Text = ((lvActionAchat.SelectedItem) as ActionAchetee).NomAction;
                txtPrixAchatAction.Text = ((lvActionAchat.SelectedItem) as ActionAchetee).PrixAchat.ToString();
                txtQuantiteAchetee.Text = ((lvActionAchat.SelectedItem) as ActionAchetee).Quantite.ToString();
                txtValeurAction.Text = ((lvActionAchat.SelectedItem) as ActionAchetee).ValeurAction.ToString();

            }
        }
    }
}
