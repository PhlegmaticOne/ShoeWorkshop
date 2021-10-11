using ShoeWorkshop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeWorkshop.UI.ViewModels
{
    public class MainDataViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkerService _workerService;
        private readonly IRepairService _repairService;

        public MainDataViewModel(ICustomerService customerService,
                                 IWorkerService workerService,
                                 IRepairService repairService) =>
                                 (_customerService, _workerService, _repairService) =
                                 (customerService, workerService, repairService);
    }
}
