using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public class WorkerViewModelFactory : IShoeWorkshopFactory<WorkersOperatingViewModel>
    {
        private readonly IWorkerService _workerService;

        public WorkerViewModelFactory(IWorkerService workerService) => _workerService = workerService;

        public WorkersOperatingViewModel CreateViewModel() => new WorkersOperatingViewModel(_workerService);
    }
}
