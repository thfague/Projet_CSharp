using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Queries
{
    /// <summary>
    /// QUERY pour récupérer des entités de types Absence
    /// </summary>
    class NoteQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public NoteQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les notes
        /// </summary>
        /// <returns>IQueryable de Note</returns>
        public IQueryable<Note> GetAll()
        {
            return _contexte.Notes;
        }

        /// <summary>
        /// Récupérer une note par son ID
        /// </summary>
        /// <param name="id">Identifiant de la note à récupérer</param>
        /// <returns>IQueryable de Note</returns>
        public IQueryable<Note> GetByID(int id)
        {
            return _contexte.Notes.Where(n => n.NoteId == id);
        }

        /// <summary>
        /// Récupérer une note par l'ID de l'élève
        /// </summary>
        /// <param name="eleveID">Identifiant de l'élève qui concerne la note à récupérer</param>
        /// <returns>IQueryable de Note</returns>
        public IQueryable<Note> GetByEleveID(int eleveID)
        {
            return _contexte.Notes.Where(n => n.EleveId == eleveID);
        }
    }
}
