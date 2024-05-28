using whs.api.business.models.common;

namespace whs.api.business.handlers;

public class ResponseCreateDepartment
{
	public required ResponseStatusCode StatusCode { get; init; }
	public string[]? Errors { get; init; }

	public static ResponseCreateDepartment Invalid(params string[] errors) => new ResponseCreateDepartment() { StatusCode = ResponseStatusCode.INVALID, Errors = errors };
	public static ResponseCreateDepartment Failed(params string[] errors) => new ResponseCreateDepartment() { StatusCode = ResponseStatusCode.FAILED, Errors = errors };
	public static ResponseCreateDepartment Success() => new ResponseCreateDepartment() { StatusCode = ResponseStatusCode.SUCCESS };
}
