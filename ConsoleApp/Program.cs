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

                Classe classe1 = new Classe { NomEtablissement = "Etablissement 1", Niveau = "Seconde" };
                Classe classe2 = new Classe { NomEtablissement = "Etablissement 1", Niveau = "Terminal" };
                contexte.Classes.Add(classe1);
                contexte.Classes.Add(classe2);
                contexte.SaveChanges();

                Eleve eleve1 = new Eleve { Nom = "FAGUE", Prenom = "Thibault", DateNaissance = new DateTime(1999, 6, 3), ClasseId = classe1.ClasseId };
                Eleve eleve2 = new Eleve { Nom = "BASSINET", Prenom = "Dylan", DateNaissance = new DateTime(1998, 10, 4), ClasseId = classe1.ClasseId };
                Eleve eleve3 = new Eleve { Nom = "BUISSON", Prenom = "Yoann", DateNaissance = new DateTime(1999, 8, 10), ClasseId = classe2.ClasseId };
                contexte.Eleves.Add(eleve1);
                contexte.Eleves.Add(eleve2);
                contexte.Eleves.Add(eleve3);
                contexte.SaveChanges();

                contexte.Notes.Add(new Note { Matiere = "Mathématiques", Appreciation = "Bon travail", Valeur = 15, DateNote = new DateTime(2019, 8, 6), EleveId = eleve1.EleveId });
                contexte.Notes.Add(new Note { Matiere = "Français", Appreciation = "Moyen", Valeur = 9, DateNote = new DateTime(2020, 7, 10), EleveId = eleve1.EleveId });
                contexte.Notes.Add(new Note { Matiere = "Mathématiques", Appreciation = "Assez mauvais", Valeur = 7, DateNote = new DateTime(2019, 10, 1), EleveId = eleve2.EleveId });
                contexte.SaveChanges();

                contexte.Absences.Add(new Absence { Motif = "Malade", DateAbsence = new DateTime(2019, 6, 11), EleveId = eleve1.EleveId });
                contexte.Absences.Add(new Absence { Motif = "Malade", DateAbsence = new DateTime(2020, 7, 1), EleveId = eleve1.EleveId });
                contexte.Absences.Add(new Absence { Motif = "Malade", DateAbsence = new DateTime(2019, 9, 6), EleveId = eleve3.EleveId });
                contexte.SaveChanges();
            }
            catch (Exception)
            {

            }            
        }
    }
}
