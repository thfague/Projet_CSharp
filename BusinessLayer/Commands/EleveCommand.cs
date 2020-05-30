using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Commands
{
    /// <summary>
    /// COMMAND pour ajouter / modifier et supprimer un élève
    /// </summary>
    public class EleveCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public EleveCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter l'élève en base à partir du contexte
        /// </summary>
        /// <param name="e">Elève à ajouter</param>
        /// <returns>Identifiant de l'élève ajouté</returns>
        public int Ajouter(Eleve e)
        {
            _contexte.Eleves.Add(e);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier un élève déjà présent en base à partir du contexte
        /// </summary>
        /// <param name="e">Elève à modifier</param>
        public void Modifier(Eleve e)
        {
            Eleve upElv = _contexte.Eleves.Where(elv => elv.EleveId == e.EleveId).FirstOrDefault();
            if (upElv != null)
            {
                upElv.Nom = e.Nom;
                upElv.Prenom = e.Prenom;
                upElv.DateNaissance = e.DateNaissance;
                upElv.ClasseId = e.ClasseId;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer un élève en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="eleveID">Identifiant de l'élève à supprimer</param>
        public void Supprimer(int eleveID)
        {
            Eleve delElv = _contexte.Eleves.Where(elv => elv.EleveId == eleveID).FirstOrDefault();
            if (delElv != null)
            {
                _contexte.Eleves.Remove(delElv);
            }
            _contexte.SaveChanges();
        }
    }
}
