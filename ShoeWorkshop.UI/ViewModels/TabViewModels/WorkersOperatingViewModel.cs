using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels
{
    public class WorkersOperatingViewModel : BaseViewModel 
    {
        private readonly IWorkerService _workerService;

        public WorkersOperatingViewModel(IWorkerService workerService) => _workerService = workerService;
    }
}
