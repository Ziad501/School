using Application.Interfaces.Generic;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public static class BaseValidator
{
    public static IRuleBuilderOptions<T, Guid> IsValidId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().WithMessage("Id is required").NotEqual(Guid.Empty).WithMessage("Invalid Id format");
    }
    public static IRuleBuilderOptions<T, Guid> DepartmentMustExist<T>(
            this IRuleBuilder<T, Guid> ruleBuilder, IGenericRepository<Department> departmentRepository)
    {
        return ruleBuilder
            .MustAsync(async (departmentId, cancellationToken) =>
            {
                var department = await departmentRepository.GetByIdAsync(departmentId, cancellationToken);
                return department != null;
            })
            .WithMessage("The specified department does not exist.");
    }
}