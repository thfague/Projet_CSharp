using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Commands
{
    /// <summary>
    /// COMMAND pour ajouter / modifier et supprimer une note
    /// </summary>
    class NoteCommand
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public NoteCommand(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Ajouter la note en base à partir du contexte
        /// </summary>
        /// <param name="n">Note à ajouter</param>
        /// <returns>Identifiant de la note ajoutée</returns>
        public int Ajouter(Note n)
        {
            _contexte.Notes.Add(n);
            return _contexte.SaveChanges();
        }

        /// <summary>
        /// Modifier une note déjà présente en base à partir du contexte
        /// </summary>
        /// <param name="n">Note à modifier</param>
        public void Modifier(Note n)
        {
            Note upNt = _contexte.Notes.Where(nt => nt.NoteId == n.NoteId).FirstOrDefault();
            if (upNt != null)
            {
                upNt.Appreciation = n.Appreciation;
                upNt.Valeur = n.Valeur;
                upNt.Matiere = n.Matiere;
                upNt.DateNote = n.DateNote;
                upNt.NoteId = n.NoteId;
            }
            _contexte.SaveChanges();
        }

        /// <summary>
        /// Supprimer une note en base à partir du contexte et de son identifiant
        /// </summary>
        /// <param name="noteID">Identifiant de la note à supprimer</param>
        public void Supprimer(int noteID)
        {
            Note delNt = _contexte.Notes.Where(nt => nt.NoteId == noteID).FirstOrDefault();
            if (delNt != null)
            {
                _contexte.Notes.Remove(delNt);
            }
            _contexte.SaveChanges();
        }
    }
}
