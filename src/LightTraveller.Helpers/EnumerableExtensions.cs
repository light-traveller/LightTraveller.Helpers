namespace LightTraveller.Helpers;

public static class EnumerableExtensions
{
    public static bool None<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => !collection.Any(predicate);

    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        if (collection is List<T> list)
        {
            list.ForEach(action);
            return;
        }

        foreach (var item in collection)
        {
            action(item);
        }
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection is null || !collection.Any();
}
