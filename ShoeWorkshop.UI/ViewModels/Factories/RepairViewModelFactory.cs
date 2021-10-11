using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public class RepairViewModelFactory : IShoeWorkshopFactory<RepairsOperatingViewModel>
    {
        private readonly IRepairService _repairService;

        public RepairViewModelFactory(IRepairService repairService) => _repairService = repairService;

        public RepairsOperatingViewModel CreateViewModel() => new RepairsOperatingViewModel(_repairService);
    }
}
