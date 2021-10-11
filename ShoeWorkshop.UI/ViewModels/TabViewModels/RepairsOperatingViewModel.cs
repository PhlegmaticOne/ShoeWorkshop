using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels
{
    public class RepairsOperatingViewModel : BaseViewModel
    {
        private readonly IRepairService _repairService;

        public RepairsOperatingViewModel(IRepairService repairService) => _repairService = repairService;
    }
}
