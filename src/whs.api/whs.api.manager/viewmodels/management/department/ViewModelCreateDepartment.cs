namespace whs.api.manager.viewmodels.management.department;

public class ViewModelCreateDepartment
{
    public required Guid UniqueId { get; init; }
    public Guid? ParentId { get; init; }
    public required string Name { get; init; }
}
