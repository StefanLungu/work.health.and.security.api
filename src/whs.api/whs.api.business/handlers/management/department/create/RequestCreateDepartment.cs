using MediatR;

namespace whs.api.business.handlers;

public class RequestCreateDepartment : IRequest<ResponseCreateDepartment>
{
	public required Guid UniqueId { get; init; }
	public Guid? ParentId { get; init; }
	public required string Name { get; init; }
}
