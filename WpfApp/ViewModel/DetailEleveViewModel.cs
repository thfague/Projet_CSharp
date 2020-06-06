using BusinessLayer;
using Model.Entities;
using System;
using System.Linq;
using WpfApp.ViewModel.Common;

namespace WpfApp.ViewModel
{
    /// <summary>
    /// ViewModel représentant un Eleve (avec son détail)
    /// Hérite de BaseViewModel
    /// </summary>
    public class DetailEleveViewModel : BaseViewModel
    {
        #region Variables

        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _moyenne;
        private string _nbAbsences;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="e">Eleve à transformer en DetailEleveViewModel</param>
        /// </summary>
        public DetailEleveViewModel(Eleve e)
        {
            _nom = e.Nom;
            _prenom = e.Prenom;
            _dateNaissance = e.DateNaissance;
            _moyenne = BusinessManager.Instance.GetAvgByEleveId(e.EleveId);
            _nbAbsences = BusinessManager.Instance.GetNbAbsencesByEleveId(e.EleveId);
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Nom de l'élève
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Prenom de l'élève
        /// </summary>
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        /// <summary>
        /// Date de naissance de l'élève
        /// </summary>
        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        /// <summary>
        /// Moyenne de l'élève
        /// </summary>
        public string Moyenne
        {
            get { return _moyenne; }
            set { _moyenne = value; }
        }

        /// <summary>
        /// Nombre d'absences de l'élève
        /// </summary>
        public string NbAbsences
        {
            get { return _nbAbsences; }
            set { _nbAbsences = value; }
        }

        #endregion
    }
}
