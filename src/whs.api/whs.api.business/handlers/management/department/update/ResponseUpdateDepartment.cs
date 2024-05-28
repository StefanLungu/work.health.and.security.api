using whs.api.business.models.common;

namespace whs.api.business.handlers;

public class ResponseUpdateDepartment
{
	public required ResponseStatusCode StatusCode { get; init; }
	public string[]? Errors { get; init; }

	public static ResponseUpdateDepartment Invalid(params string[] errors) => new ResponseUpdateDepartment() { StatusCode = ResponseStatusCode.INVALID, Errors = errors };
	public static ResponseUpdateDepartment Failed(params string[] errors) => new ResponseUpdateDepartment() { StatusCode = ResponseStatusCode.FAILED, Errors = errors };
	public static ResponseUpdateDepartment NotFound(params string[] errors) => new ResponseUpdateDepartment() { StatusCode = ResponseStatusCode.FAILED, Errors = errors };
	public static ResponseUpdateDepartment Success() => new ResponseUpdateDepartment() { StatusCode = ResponseStatusCode.SUCCESS };
}
