using Model;
using Model.Entities;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Contexte contexte = new Contexte();
                contexte.Classes.ToList();
                contexte.Eleves.ToList();
                contexte.Notes.ToList();
                contexte.Absences.ToList();

                Classe classe = new Classe { NomEtablissement = "Etablissement 1", Niveau = "Seconde" };
                contexte.Classes.Add(classe);
                contexte.SaveChanges();
                contexte.Eleves.Add(new Eleve { Nom = "DUPONT", Prenom = "Jean", DateNaissance = DateTime.Now, ClasseId = classe.ClasseId });
                contexte.SaveChanges();
            }
            catch (Exception)
            {
                
            }            
        }
    }
}
