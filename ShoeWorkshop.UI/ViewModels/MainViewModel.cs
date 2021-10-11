using ShoeWorkshop.UI.State;

namespace ShoeWorkshop.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; }
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.ChangeCurrentViewModelCommand.Execute(ViewType.MainData);
        }
    }
}
