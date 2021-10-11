using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels.Factories
{
    public class CustomerViewModelFactory : IShoeWorkshopFactory<CustomersOperatingViewModel>
    {
        private readonly ICustomerService _customerService;

        public CustomerViewModelFactory(ICustomerService customerService) => _customerService = customerService;

        public CustomersOperatingViewModel CreateViewModel()
        {
            return new CustomersOperatingViewModel(_customerService);
        }
    }
}
