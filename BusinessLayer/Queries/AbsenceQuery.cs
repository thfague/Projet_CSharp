using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Queries
{
    /// <summary>
    /// QUERY pour récupérer des entités de types Absence
    /// </summary>
    class AbsenceQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public AbsenceQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les absences
        /// </summary>
        /// <returns>IQueryable de Absence</returns>
        public IQueryable<Absence> GetAll()
        {
            return _contexte.Absences;
        }

        /// <summary>
        /// Récupérer une absence par son ID
        /// </summary>
        /// <param name="id">Identifiant de l'absence à récupérer</param>
        /// <returns>IQueryable de Absence</returns>
        public IQueryable<Absence> GetByID(int id)
        {
            return _contexte.Absences.Where(a => a.AbsenceId == id);
        }

        /// <summary>
        /// Récupérer une absence par l'ID de l'élève
        /// </summary>
        /// <param name="eleveID">Identifiant de l'élève qui concerne l'absence à récupérer</param>
        /// <returns>IQueryable de Absence</returns>
        public IQueryable<Absence> GetByEleveID(int eleveID)
        {
            return _contexte.Absences.Where(a => a.EleveId == eleveID);
        }
    }
}
