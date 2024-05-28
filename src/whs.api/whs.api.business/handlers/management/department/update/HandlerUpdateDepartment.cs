using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using whs.api.business.common;
using whs.api.entities.management;
using whs.api.repository.abstractions.management;

namespace whs.api.business.handlers;

public class HandlerUpdateDepartment(
	ILogger<HandlerUpdateDepartment> logger,
	IDepartmentsRepository departmentsRepository,
	IValidator<RequestUpdateDepartment> requestValidator) : IRequestHandler<RequestUpdateDepartment, ResponseUpdateDepartment>
{
	private readonly ILogger<HandlerUpdateDepartment> _logger = logger;
	private readonly IDepartmentsRepository _departmentsRepository = departmentsRepository;
	private readonly IValidator<RequestUpdateDepartment> _requestValidator = requestValidator;

	private const string HANDLER_NAME = nameof(HandlerUpdateDepartment);

	public async Task<ResponseUpdateDepartment> Handle(RequestUpdateDepartment request, CancellationToken cancellationToken)
	{
		_logger.LogInformation("{handlerName}: Received '{requestName}'", HANDLER_NAME, nameof(RequestUpdateDepartment));

		_logger.LogDebug("{handlerName}: Validating '{requestName}'", HANDLER_NAME, nameof(RequestUpdateDepartment));
		ValidationResult validationResult = await _requestValidator.ValidateAsync(request);

		if (!validationResult.IsValid)
		{
			string[] errors = validationResult.Errors.GetErrors().ToArray();
			_logger.LogDebug("{handlerName}: {errors}", HANDLER_NAME, errors);
			return ResponseUpdateDepartment.Invalid();
		}

		Department? department = await _departmentsRepository.GetByIdAsync(request.UniqueId);

        if (department is null)
        {
			_logger.LogError("{handlerName}: Could not retrieve department with unique id {departmentId}", HANDLER_NAME, request.UniqueId);
			return ResponseUpdateDepartment.NotFound();
        }

		if (request.Name.HasValue)
		{
			if (await _departmentsRepository.ExistsByNameAndParent(request.Name.Value!, department.UniqueId, department.Parent?.UniqueId))
			{
				_logger.LogError("{handlerName}: Department '{depName}' already exist", HANDLER_NAME, request.Name.Value);
				return ResponseUpdateDepartment.Invalid();
			}
			department.Name = request.Name.Value;
		}

		await _departmentsRepository.UpdateAsync(department);

		_logger.LogInformation("{handlerName}: Department '{depName}' updated successfully", HANDLER_NAME, department.Name);

		return ResponseUpdateDepartment.Success();
    }
}
