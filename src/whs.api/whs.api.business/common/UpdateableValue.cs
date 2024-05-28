namespace whs.api.business.common;

public class UpdateableValue<T>
{
	public T? Value { get; init; }
	public required bool HasValue { get; init; }

    public UpdateableValue()
    {
		Value = default;
		HasValue = false;
    }
}
