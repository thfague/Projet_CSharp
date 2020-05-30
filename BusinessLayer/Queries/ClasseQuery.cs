using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Queries
{
    /// <summary>
    /// QUERY pour récupérer des entités de types Classe
    /// </summary>
    class ClasseQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public ClasseQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer toutes les classes
        /// </summary>
        /// <returns>IQueryable de Classe</returns>
        public IQueryable<Classe> GetAll()
        {
            return _contexte.Classes;
        }

        /// <summary>
        /// Récupérer une classe par son ID
        /// </summary>
        /// <param name="id">Identifiant de la classe à récupérer</param>
        /// <returns>IQueryable de Classe</returns>
        public IQueryable<Classe> GetByID(int id)
        {
            return _contexte.Classes.Where(c => c.ClasseId == id);
        }
    }
}
