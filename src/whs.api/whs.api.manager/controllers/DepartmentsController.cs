using MediatR;
using Microsoft.AspNetCore.Mvc;
using whs.api.business.handlers;
using whs.api.business.models.common;
using whs.api.entities.management;
using whs.api.manager.mappers;
using whs.api.manager.viewmodels;
using whs.api.manager.viewmodels.management.department;

namespace whs.api.manager.controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController(
	ILogger<DepartmentsController> logger,
	IMediator mediator) : Controller
{
	private readonly ILogger<DepartmentsController> _logger = logger;
	private readonly IMediator _mediator = mediator;

	private const string LOG_PREFIX = nameof(DepartmentsController);

	[HttpPost("[action]")]
	[ProducesResponseType((typeof(BaseViewModelResponse)), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Create([FromBody] ViewModelCreateDepartment viewModel)
	{
		if (viewModel is null)
		{
			_logger.LogError("{logPrefix}: Received invalid '{viewModelName}' model", LOG_PREFIX, nameof(ViewModelCreateDepartment));
			return BadRequest($"Received invalid '{nameof(ViewModelCreateDepartment)}' model");
		}

		RequestCreateDepartment request = viewModel.MapToRequestCreateDepartment();

		_logger.LogInformation("{logPrefix}: Sending '{requestName}' to mediator handler", LOG_PREFIX, nameof(RequestCreateDepartment));
		ResponseCreateDepartment response = await _mediator.Send(request);

		if (response is null || response.StatusCode is ResponseStatusCode.FAILED)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
		}

		if (response.StatusCode is ResponseStatusCode.INVALID)
		{
			return StatusCode(StatusCodes.Status400BadRequest, "Invalid request");
		}

		return Ok(new BaseViewModelResponse());
	}

	[HttpPut("update/{departmentId:guid}")]
	[ProducesResponseType((typeof(BaseViewModelResponse)), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<IActionResult> Update(Guid departmentId, [FromBody] ViewModelUpdateDepartment viewModel)
	{
		if (departmentId != viewModel?.UniqueId)
		{
			_logger.LogError("{logPrefix}: Department unique id missmatch", LOG_PREFIX);
			return BadRequest("Department unique id missmatch");
		}

		RequestUpdateDepartment request = viewModel.MapToRequestUpdateDepartment();

		_logger.LogInformation("{logPrefix}: Sending '{requestName}' to mediator handler", LOG_PREFIX, nameof(RequestUpdateDepartment));
		ResponseUpdateDepartment response = await _mediator.Send(request);

		if (response is null || response.StatusCode is ResponseStatusCode.FAILED)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
		}

		if (response.StatusCode is ResponseStatusCode.INVALID)
		{
			return StatusCode(StatusCodes.Status400BadRequest, "Invalid request");
		}

		return Ok(new BaseViewModelResponse());
	}

}
