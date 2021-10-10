using ShoeWorkshop.UI.State;
using ShoeWorkshop.UI.ViewModels;
using System;
using System.Windows.Input;

namespace ShoeWorkshop.UI.Commands
{
    public class ChangeCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly INavigator _navigator;

        public ChangeCurrentViewModelCommand(INavigator navigator) => _navigator = navigator;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            if(parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = viewType switch
                {
                    ViewType.Repair => new RepairsOperatingViewModel(),
                    ViewType.Worker => new WorkersOperatingViewModel(),
                    ViewType.Customer => new CustomersOperatingViewModel(),
                    _ => new MainDataViewModel()
                };
            }
        }
    }
}
