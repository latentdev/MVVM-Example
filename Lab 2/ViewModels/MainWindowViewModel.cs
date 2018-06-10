using System;
using System.Windows.Input;

namespace Lab_2.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            LoadAllFonts();

            SearchTerm = "";

            //hook up commands
            ShutdownCommand = new DelegateCommand(o => Shutdown());
        }

        #region Commands

        public ICommand ShutdownCommand { get; private set; }

        #endregion

        #region Backing Fields

        private FontListViewModel fontListViewModel;

        private FontListViewModel fullFontListViewModel;

        private ViewModelBase currentFontViewModel;

        private String searchTerm;

        private bool filterFavorite;

        private bool filterComment;

        #endregion

        #region Properties

        public FontListViewModel FontListViewModel
        {
            get { return fontListViewModel; }
            set
            {
                fontListViewModel = value;
                this.OnPropertyChanged(nameof(FontListViewModel));
            }
        }

        public ViewModelBase CurrentFontViewModel
        {
            get { return currentFontViewModel; }
            set
            {
                currentFontViewModel = value;
                this.OnPropertyChanged(nameof(CurrentFontViewModel));
            }
        }

        public String SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                FilterFonts();
                OnPropertyChanged(nameof(SearchTerm));
            }
        }

        public bool FilterFavorite
        {
            get => filterFavorite;
            set
            {
                filterFavorite = value;
                FilterFonts();
                OnPropertyChanged(nameof(FilterFavorite));
            }
        }

        public bool FilterComment
        {
            get => filterComment;
            set
            {
                filterComment = value;
                FilterFonts();
                OnPropertyChanged(nameof(FilterComment));
            }
        }

        #endregion

        private void FilterFonts()
        {
            FontListViewModel.Model = fullFontListViewModel.Model.Filter(SearchTerm, FilterFavorite, FilterComment);
        }

        private void LoadAllFonts()
        {
            FontListViewModel = new FontListViewModel(FontFactory.GetFontsFromFile());
            fullFontListViewModel = new FontListViewModel(FontFactory.GetFontsFromFile());
        }

        private void Shutdown()
        {
            Json.SerializeToFile(AppDomain.CurrentDomain.BaseDirectory, fullFontListViewModel.Model.Filter());
        }
    }
}
