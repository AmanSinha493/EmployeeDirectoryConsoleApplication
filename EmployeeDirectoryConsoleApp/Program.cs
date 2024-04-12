using Employee_Directory_Console_App.Interaction.InputHandler;
using Employee_Directory_Console_App.Interaction.InputHandler.Interfaces;
using Employee_Directory_Console_App.Interaction.View;
using Employee_Directory_Console_App.Interaction.View.Interfaces;
using Employee_Directory_Console_App.Interaction.View.Menu;
using Employee_Directory_Console_App.ServiceHandler;
using Employee_Directory_Console_App.ServiceHandler.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repository;
using Repository.IRepository;
using Services;
using Services.Interfaces;
using Validations.Interfaces;

namespace EmployeeDirectoryConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = BuildServiceProvider();
            var mainMenuHandler = serviceProvider.GetRequiredService<MainMenuHandler>();
            mainMenuHandler.HandleCommands();
        }

        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<Role>, RoleRepository>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IRoleView, RoleView>();
            services.AddScoped<IEmployeeView, EmployeeView>();
            services.AddScoped<IServiceHandler<Employee>, EmployeeServiceHandler>();
            services.AddScoped<IServiceHandler<Role>, RoleServiceHandler>();
            services.AddScoped<IEmployeeInputHandler, EmployeeInputHandler>();
            services.AddScoped<IValidation, Validations.Validation>();
            services.AddScoped<IRoleInputHandler, RoleInputHandler>();
            services.AddScoped<MainMenu>();
            services.AddScoped<MainMenuHandler>();
            return services.BuildServiceProvider();
        }
    }
}
