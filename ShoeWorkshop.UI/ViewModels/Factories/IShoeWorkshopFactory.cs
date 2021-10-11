using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public interface IShoeWorkshopFactory<T> where T : BaseViewModel
    {
        T CreateViewModel();
    }
}
