using ShoeWorkshop.UI.State;
using ShoeWorkshop.UI.ViewModels;
using ShoeWorkshop.UI.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace ShoeWorkshop.UI.Commands
{
    public class ChangeCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly INavigator _navigator;
        private readonly IShoeWorkshopAbstractFactory _factory;

        public ChangeCurrentViewModelCommand(INavigator navigator, IShoeWorkshopAbstractFactory factory)
        {
            _navigator = navigator;
            _factory = factory;
        }

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            if(parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _factory.CreateViewModel(viewType);
            }
        }
    }
}
