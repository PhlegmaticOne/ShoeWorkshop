using ShoeWorkshop.Domain.Services;

namespace ShoeWorkshop.UI.ViewModels
{
    public class CustomersOperatingViewModel : BaseViewModel
    {
        private readonly ICustomerService _customerService;

        public CustomersOperatingViewModel(ICustomerService customerService) => _customerService = customerService;
    }
}
