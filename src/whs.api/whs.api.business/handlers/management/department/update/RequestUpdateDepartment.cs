using MediatR;
using whs.api.business.common;

namespace whs.api.business.handlers;

public class RequestUpdateDepartment : IRequest<ResponseUpdateDepartment>
{
	public required Guid UniqueId { get; init; }
	public required UpdateableValue<string> Name { get; init; }
}
