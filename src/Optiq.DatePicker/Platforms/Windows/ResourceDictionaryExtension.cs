namespace Optiq.DatePicker.Platforms;

public static class ResourceDictionaryExtension
{
    public static void RemoveKeys(this Microsoft.UI.Xaml.ResourceDictionary resources, IEnumerable<string> keys)
    {
        foreach (string key in keys)
        {
            resources.Remove(key);
        }
    }

    public static void SetValueForAllKey(this Microsoft.UI.Xaml.ResourceDictionary resources, IEnumerable<string> keys, object? value)
    {
        foreach (string key in keys)
        {
            resources[key] = value;
        }
    }

}