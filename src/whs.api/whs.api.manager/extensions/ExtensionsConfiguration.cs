namespace whs.api.manager.extensions;

public static class ExtensionsConfiguration
{
    public static T GetRequiredValue<T>(this IConfiguration configuration, string key)
    {
        T? value = configuration.GetValue<T>(key);

        if (value is null)
        {
            throw new Exception($"No value is set for property {key}");
        }

        return value;
    }
}
