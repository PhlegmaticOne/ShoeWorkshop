using ShoeWorkshop.UI.State;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public interface IShoeWorkshopAbstractFactory
    {
        BaseViewModel CreateViewModel(ViewType type);
    }
}
