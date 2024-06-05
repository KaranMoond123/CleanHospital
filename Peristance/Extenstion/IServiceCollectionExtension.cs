using Application.Interfaces.GenericRepositories;
using Application.Interfaces.Repositories.Documents;
using Application.Interfaces.Repositories.Staffs;
using Application.Interfaces.Repositories.Students;
using Application.Interfaces.UnitOfWorkRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Peristance.DataContext;
using Peristance.Extenstion.Documents;
using Peristance.Extenstion.Repositories;
using Peristance.Extenstion.Repositories.Staffs;
using Peristance.Extenstion.Repositories.Students;

namespace Peristance.Extenstion;

public static class IServiceCollectionExtension
{
    public static void AddPeristanceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepository();
    }
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionsString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationdbContext>(options =>
        options.UseSqlServer(connectionsString,
        builder => builder.MigrationsAssembly(typeof(ApplicationdbContext).Assembly.FullName)));
    }
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient(typeof(IGenericRepositary<>), typeof(GenricRepository<>))
            .AddTransient<IStudentRepositary, StudentRepositary>()
            .AddTransient<IDocumentRepositary, DocumentRepositary>()
            .AddTransient<IStafffRepositary, StaffRepositary>()
            .AddHttpContextAccessor();

    }
}
