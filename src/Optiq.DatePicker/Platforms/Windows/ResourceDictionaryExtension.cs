namespace Optiq.DatePicker.Platforms.Windows;

internal static class ResourceDictionaryExtension
{
    internal static void RemoveKeys(this Microsoft.UI.Xaml.ResourceDictionary resources, IEnumerable<string> keys)
    {
        foreach (string key in keys)
        {
            resources.Remove(key);
        }
    }

    internal static void SetValueForAllKey(this Microsoft.UI.Xaml.ResourceDictionary resources, IEnumerable<string> keys, object? value)
    {
        foreach (string key in keys)
        {
            resources[key] = value;
        }
    }
}