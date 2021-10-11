using Microsoft.Extensions.DependencyInjection;
using ShoeWorkshop.Database;
using ShoeWorkshop.Domain;
using ShoeWorkshop.Domain.Models;
using ShoeWorkshop.Domain.Services;
using ShoeWorkshop.UI.State;
using ShoeWorkshop.UI.ViewModels;
using ShoeWorkshop.UI.ViewModels.Factories;
using System;
using System.Windows;

namespace ShoeWorkshop.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = ConfigureDIContainer();
            var window = serviceCollection.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider ConfigureDIContainer()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ShoeWorkshopDbContextFactory>();
            serviceCollection.AddSingleton<IDataService<Customer>, GenericDataService<Customer>>();
            serviceCollection.AddSingleton<IDataService<Worker>, GenericDataService<Worker>>();
            serviceCollection.AddSingleton<IDataService<Repair>, GenericDataService<Repair>>();
            serviceCollection.AddSingleton<ICustomerService, CustomerService>();
            serviceCollection.AddSingleton<IRepairService, RepairService>();
            serviceCollection.AddSingleton<IWorkerService, WorkerService>();


            serviceCollection.AddScoped<MainViewModel>();
            serviceCollection.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            serviceCollection.AddScoped<INavigator, Navigator>();
            serviceCollection.AddSingleton<IShoeWorkshopAbstractFactory, ShoeWorkshopAbstractFactory>();
            serviceCollection.AddSingleton<IShoeWorkshopFactory<MainDataViewModel>, MainDataViewModelFactory>();
            serviceCollection.AddSingleton<IShoeWorkshopFactory<RepairsOperatingViewModel>, RepairViewModelFactory>();
            serviceCollection.AddSingleton<IShoeWorkshopFactory<CustomersOperatingViewModel>, CustomerViewModelFactory>();
            serviceCollection.AddSingleton<IShoeWorkshopFactory<WorkersOperatingViewModel>, WorkerViewModelFactory>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
