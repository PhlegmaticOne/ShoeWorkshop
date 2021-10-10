using ShoeWorkshop.UI.ViewModels;
using System.Windows.Input;

namespace ShoeWorkshop.UI.State
{
    public enum ViewType
    {
        MainData,
        Repair,
        Worker,
        Customer
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand ChangeCurrentViewModelCommand { get; }
    }
}
