using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EleveViewModel
    {
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
    }
}