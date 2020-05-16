using System.Collections.Generic;

namespace Model.Entities
{
    public class Classe
    {
        /// <summary>
        /// Identifiant de la classe
        /// </summary>
        public int ClasseId { get; set; }
        /// <summary>
        /// Nom de l'établissement où se trouve la classe
        /// </summary>
        public string NomEtablissement { get; set; }
        /// <summary>
        /// Niveau de la classe
        /// </summary>
        public string Niveau { get; set; }
        /// <summary>
        /// Liste d'élèves de la classe
        /// </summary>
        public ICollection<Eleve> Eleves { get; set; }
    }
}
