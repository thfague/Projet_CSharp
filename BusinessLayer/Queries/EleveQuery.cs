﻿using Model;
using Model.Entities;
using System.Linq;

namespace BusinessLayer.Queries
{
    /// <summary>
    /// QUERY pour récupérer des entités de types Eleve
    /// </summary>
    public class EleveQuery
    {
        private readonly Contexte _contexte;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="contexte">Contexte EF à utiliser</param>
        public EleveQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        /// <summary>
        /// Récupérer tous les élèves
        /// </summary>
        /// <returns>IQueryable de Eleve</returns>
        public IQueryable<Eleve> GetAll()
        {
            return _contexte.Eleves;
        }

        /// <summary>
        /// Récupérer un élève par son ID
        /// </summary>
        /// <param name="id">Identifiant de l'élève à récupérer</param>
        /// <returns>IQueryable de Eleve</returns>
        public IQueryable<Eleve> GetByID(int id)
        {
            return _contexte.Eleves.Where(e => e.EleveId == id);
        }
    }
}
