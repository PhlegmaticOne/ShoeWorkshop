using ShoeWorkshop.UI.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeWorkshop.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; } = new Navigator();
        public MainViewModel()
        {
            Navigator.ChangeCurrentViewModelCommand.Execute(ViewType.MainData);
        }
    }
}
