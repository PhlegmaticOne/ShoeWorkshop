using ShoeWorkshop.UI.State;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public class ShoeWorkshopAbstractFactory : IShoeWorkshopAbstractFactory
    {
        private readonly IShoeWorkshopFactory<MainDataViewModel> _mainDataVMFactory;
        private readonly IShoeWorkshopFactory<RepairsOperatingViewModel> _repairVMFactory;
        private readonly IShoeWorkshopFactory<CustomersOperatingViewModel> _customerVMFactory;
        private readonly IShoeWorkshopFactory<WorkersOperatingViewModel> _workerVMFactory;

        public ShoeWorkshopAbstractFactory(IShoeWorkshopFactory<MainDataViewModel> mainDataVMFactory,
                                           IShoeWorkshopFactory<RepairsOperatingViewModel> repairVMFactory,
                                           IShoeWorkshopFactory<CustomersOperatingViewModel> customerVMFactory,
                                           IShoeWorkshopFactory<WorkersOperatingViewModel> workerVMFactory) =>
                                           (_mainDataVMFactory, _repairVMFactory, _customerVMFactory, _workerVMFactory) =
                                           (mainDataVMFactory, repairVMFactory, customerVMFactory, workerVMFactory);

        public BaseViewModel CreateViewModel(ViewType type) => type switch
        {
            ViewType.Repair => _repairVMFactory.CreateViewModel(),
            ViewType.Worker => _workerVMFactory.CreateViewModel(),
            ViewType.Customer => _customerVMFactory.CreateViewModel(),
            _ => _mainDataVMFactory.CreateViewModel()
        };
    }
}
