﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AbsenceViewModel
    {
        /// <summary>
        /// Identifiant de l'absence
        /// </summary>
        public int AbsenceId { get; set; }
        /// <summary>
        /// Date de l'absence
        /// </summary>
        public DateTime DateAbsence { get; set; }
        /// <summary>
        /// Motif de l'absence
        /// </summary>
        public string Motif { get; set; }
        /// <summary>
        /// Identifiant de l'élève concerné par l'absence
        /// </summary>
        public int EleveId { get; set; }
        /// <summary>
        /// Élève concerné par l'absence
        /// </summary>
        public EleveViewModel Eleve { get; set; }
    }
}