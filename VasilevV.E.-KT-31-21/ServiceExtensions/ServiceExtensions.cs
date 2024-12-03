using VasilevV.E._KT_31_21.Interfaces.DisciplinesInterfaces;
using VasilevV.E._KT_31_21.Interfaces.StudentsInterfaces;
using System.Runtime.CompilerServices;
namespace VasilevV.E._KT_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this  IServiceCollection services)
        {
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
