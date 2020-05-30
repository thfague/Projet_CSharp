using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Commands
{
    /// <summary>
    /// COMMAND pour ajouter / modifier et supprimer une classe
    /// </summary>
    class ClasseCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public ClasseCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter la classe en base à partir du contexte
        /// </summary>
        /// <param name="c">Classe à ajouter</param>
        /// <returns>Identifiant de la classe ajoutée</returns>
        public int Ajouter(Classe c)
        {
            _contexte.Classes.Add(c);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier une classe déjà présente en base à partir du contexte
        /// </summary>
        /// <param name="c">Classe à modifier</param>
        public void Modifier(Classe c)
        {
            Classe upClasse = _contexte.Classes.Where(cl => cl.ClasseId == c.ClasseId).FirstOrDefault();
            if (upClasse != null)
            {
                upClasse.NomEtablissement = c.NomEtablissement;
                upClasse.Niveau = c.Niveau;
                upClasse.ClasseId = c.ClasseId;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer une classe en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="classeID">Identifiant de la classe à supprimer</param>
        public void Supprimer(int classeID)
        {
            Classe delCl = _contexte.Classes.Where(cl => cl.ClasseId == classeID).FirstOrDefault();
            if (delCl != null)
            {
                _contexte.Classes.Remove(delCl);
            }
            _contexte.SaveChanges();
        }
    }
}
