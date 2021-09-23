using System;

namespace ModelObjet
{
    public class Condition
    {
        const int nbJours = 30;
        // Permet de savoir si on a le droit d'être remboursé
        // On l'est à condition que le nombre de jours ne dépasse pas 30 !
        public static bool Valider(int unNbDeJours)
        {
            bool valider = true;
            if (unNbDeJours > nbJours)
            {
                valider = false;
            }
            return valider;
        }
        // Permet de renvoyer le montant MAX remboursé en fonction de la catégorie
        public static int CalculerMontantMax(string uneCategorie)
        {
            int remboursementMax = 0;
            if(uneCategorie == "Livre")
            {
                remboursementMax = 30;
            }
            if(uneCategorie == "Jouet")
            {
                remboursementMax = 50;
            }
            if(uneCategorie == "Informatique")
            {
                remboursementMax = 1000;
            }
            return remboursementMax;
        }
        // Permet de retourner le total remboursé en fonction de tous les critères
        public static double CalculerMontantRembourse(int unNbDeJours, string uneCategorie, bool estMembre, string unEtat, int unPrix)
        {
            double prix = unPrix;
            if (Condition.CalculerMontantMax(uneCategorie) < prix)
            {
                prix = Condition.CalculerMontantMax(uneCategorie);
                
            }
            double montantRembourse = prix * (1 - (Condition.CalculerReductionMembre(estMembre) + Condition.CalculerReduction(unEtat)));
            if (Condition.Valider(unNbDeJours) == false)
            {
                montantRembourse = 0;
            }
            
            return Math.Round(montantRembourse,2);

        }
        // Permet de renvoyer la réduction si on est membre ou pas
        public static double CalculerReductionMembre(bool estMembre)
        {
            double reductionMembre;
            if(estMembre == true)
            {
                reductionMembre = 0;
            }
            else
            {
                reductionMembre = 0.20;
            }
            return reductionMembre;
        }
        // Permet de renvoyer la réduction en fonction de l'état de l'achat
        public static double CalculerReduction(string unEtat)
        {
            double reduction;
            if(unEtat == "Très abimé" || unEtat == "Abimé")
            {
                reduction = 0.30;
            }
            else
            {
                reduction = 0.10;
            }
            return reduction;
        }
    }
}
