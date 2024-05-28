using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using whs.api.business.common;
using whs.api.entities.management;
using whs.api.repository.abstractions.management;

namespace whs.api.business.handlers;

public class HandlerCreateDepartment(
	ILogger<HandlerCreateDepartment> logger,
	IDepartmentsRepository departmentsRepository,
	IValidator<RequestCreateDepartment> requestValidator) : IRequestHandler<RequestCreateDepartment, ResponseCreateDepartment>
{
	private readonly ILogger<HandlerCreateDepartment> _logger = logger;
	private readonly IDepartmentsRepository _departmentsRepository = departmentsRepository;
	private readonly IValidator<RequestCreateDepartment> _requestValidator = requestValidator;

	private const string CONSUMER_NAME = nameof(HandlerCreateDepartment);

	public async Task<ResponseCreateDepartment> Handle(RequestCreateDepartment request, CancellationToken cancellationToken)
	{
		_logger.LogInformation("{consumerName}: Received '{requestName}'", CONSUMER_NAME, nameof(RequestCreateDepartment));

		_logger.LogDebug("{consumerName}: Validating '{requestName}'", CONSUMER_NAME, nameof(RequestCreateDepartment));

		ValidationResult validationResult = await _requestValidator.ValidateAsync(request);

		if (!validationResult.IsValid)
		{
			string[] errors = validationResult.Errors.GetErrors().ToArray();
			_logger.LogError("{consumerName}: Validation errors: {errors}", CONSUMER_NAME, errors);
			return ResponseCreateDepartment.Invalid(errors);
		}

		_logger.LogDebug("{consumerName}: Creating '{entityName}' from '{requestName}'", CONSUMER_NAME, nameof(Department), nameof(ResponseCreateDepartment));

		Department department = new()
		{
			UniqueId = request.UniqueId,
			Name = request.Name,
			IsActive = true
		};

		department.IncrementalPath = $"{department.UniqueId}";

		if (request.ParentId is not null)
		{
			department.Parent = await _departmentsRepository.GetByIdAsync(request.ParentId.Value);
			department.IncrementalPath = $"{department.Parent!.IncrementalPath}|{department.UniqueId}";
		}

		await _departmentsRepository.CreateAsync(department);
		_logger.LogInformation("{consumerName}: Department '{depName}' with unique id '{depId}' inserted successfully", CONSUMER_NAME, department.Name, department.UniqueId);

		return ResponseCreateDepartment.Success();
	}
}
