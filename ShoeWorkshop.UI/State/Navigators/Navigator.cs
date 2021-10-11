using ShoeWorkshop.UI.Commands;
using ShoeWorkshop.UI.Models;
using ShoeWorkshop.UI.ViewModels;
using ShoeWorkshop.UI.ViewModels.Factories;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoeWorkshop.UI.State
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _baseViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _baseViewModel;
            set
            {
                _baseViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangeCurrentViewModelCommand { get; set; }
        public Navigator(IShoeWorkshopAbstractFactory workshopAbstractFactory)
        {
            ChangeCurrentViewModelCommand = new ChangeCurrentViewModelCommand(this, workshopAbstractFactory);
        }
    }
}
