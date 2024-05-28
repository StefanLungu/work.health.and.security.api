using whs.api.business.models.common;

namespace whs.api.business.common;

public class BaseResponse
{
	public required ResponseStatusCode StatusCode { get; init; }
	public string[]? Errors { get; init; }

	public static BaseResponse Invalid(params string[] errors) => new BaseResponse() { StatusCode = ResponseStatusCode.INVALID, Errors = errors };
	public static BaseResponse Failed(params string[] errors) => new BaseResponse() { StatusCode = ResponseStatusCode.FAILED, Errors = errors };
	public static BaseResponse Success() => new BaseResponse() { StatusCode = ResponseStatusCode.SUCCESS };
}
