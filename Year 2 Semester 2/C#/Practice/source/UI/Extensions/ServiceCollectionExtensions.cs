using Microsoft.Extensions.DependencyInjection;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

namespace UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IAuditLogService, AuditLogService>();

            return services;
        }
    }
}
