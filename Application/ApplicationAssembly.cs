using Application.Features.Students.Queries.Handlers;
using Application.Validators.StudentValidation;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationAssembly
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentsQueryHandler).Assembly));
            services.AddMapster();
            services.AddValidatorsFromAssemblyContaining<StudentCreateDtoValidator>();
            return services;
        }
    }
}
