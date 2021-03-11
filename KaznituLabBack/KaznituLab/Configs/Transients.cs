using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Persistence;
using KaznituLab.Repositories;
using KaznituLab.Repositories.Interfaces;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services;
using KaznituLab.Services.DictionaryService;
using KaznituLab.Services.Employee;
using KaznituLab.Services.Email;
using KaznituLab.Services.Interfaces;
using KaznituLab.Services.Interfaces.Dictionary;
using KaznituLab.Services.Interfaces.Employee;
using KaznituLab.Services.Interfaces.Email;
using Microsoft.Extensions.DependencyInjection;

namespace KaznituLab.Configs
{
    public static class Transients
    {
        public static IServiceCollection AddTransients(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IDictionaryService , DictionaryService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ILaboratoryService, LaboratoryService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IWorkService, WorkService>();
            services.AddTransient<IEmailSendService, EmailSendService>();



            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILaboratoryRepository, LaboratoryRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IWorkRepository, WorkRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
