using WpfApp.ViewModel.Common;

namespace WpfApp.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region Variables

        private ListeEleveViewModel _listeEleveViewModel = null;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public HomeViewModel()
        {
            _listeEleveViewModel = new ListeEleveViewModel();
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit le ListeProduitViewModel
        /// </summary>
        public ListeEleveViewModel ListeEleveViewModel
        {
            get { return _listeEleveViewModel; }
            set { _listeEleveViewModel = value; }
        }

        #endregion
    }
}
