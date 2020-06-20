using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EleveViewModel
    {
        /// <summary>
        /// Identifiant de l'élève
        /// </summary>
        public int EleveId { get; set; }
        /// <summary>
        /// Nom de l'élève
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Prénom de l'élève
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Date de naissance de l'élève
        /// </summary>
        public DateTime DateNaissance { get; set; }
        /// <summary>
        /// Identifiant de la classe dans laquelle se trouve l'élève
        /// </summary>
        public int ClasseId { get; set; }
    }
}