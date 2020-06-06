using BusinessLayer;
using Model.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp.ViewModel.Common;

namespace WpfApp.ViewModel
{
    /// <summary>
    /// ViewModel permettant de gérer une liste de DetailEleveViewModel
    /// Hérite de BaseViewModel
    /// </summary>
    public class ListeEleveViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<DetailEleveViewModel> _eleves = null;
        private DetailEleveViewModel _selectedEleve;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListeEleveViewModel()
        {
            _eleves = new ObservableCollection<DetailEleveViewModel>();
            foreach (Eleve e in BusinessManager.Instance.GetAllEleve())
            {
                _eleves.Add(new DetailEleveViewModel(e));
            }

            if (_eleves != null && _eleves.Count > 0)
            {
                _selectedEleve = _eleves.ElementAt(0);
            }
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit une collection de DetailEleveViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailEleveViewModel> Eleves
        {
            get { return _eleves; }
            set
            {
                _eleves = value;
                OnPropertyChanged("Eleves");
            }
        }

        /// <summary>
        /// Obtient ou défini l'élève en cours de sélection dans la liste de DetailEleveViewModel
        /// </summary>
        public DetailEleveViewModel SelectedEleve
        {
            get { return _selectedEleve; }
            set
            {
                _selectedEleve = value;
                OnPropertyChanged("SelectedEleve");
            }
        }

        #endregion
    }
}
