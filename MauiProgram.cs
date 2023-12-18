using EmployeeManager.Contracts.IService;
using EmployeeManager.Contracts.Service;
using EmployeeManager.Models;
using EmployeeManager.ViewModels;
using EmployeeManager.Views;
using Microsoft.Extensions.Logging;

namespace EmployeeManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //Other Services
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

            //Views 
            builder.Services.AddSingleton<EmployeeList>();
            builder.Services.AddSingleton<AddUpdateEmployee>();

            //ViewModels 
            builder.Services.AddSingleton<EmployeeListViewModel>();
            builder.Services.AddSingleton<AddUpdateEmployeeViewModel>();

            return builder.Build();
        }
    }
}
