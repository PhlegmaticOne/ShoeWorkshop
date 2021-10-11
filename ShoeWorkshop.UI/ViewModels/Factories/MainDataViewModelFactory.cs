using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public class MainDataViewModelFactory : IShoeWorkshopFactory<MainDataViewModel>
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkerService _workerService;
        private readonly IRepairService _repairService;

        public MainDataViewModelFactory(ICustomerService customerService,
                                        IWorkerService workerService,
                                        IRepairService repairService) =>
                                        (_customerService, _workerService, _repairService) =
                                        (customerService, workerService, repairService);

        public MainDataViewModel CreateViewModel() => new MainDataViewModel(_customerService, _workerService, _repairService);
    }
}
