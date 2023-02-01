using LightTraveller.Guards;

namespace LightTraveller.Helpers;

public static class EnumerableExtensions
{
    /// <summary>
    /// Determine if none of the elements of a collection satisfy a condition.
    /// </summary>
    /// <typeparam name="T">Type of the elements of the collection.</typeparam>
    /// <param name="collection">The collection whose elements should be checked.</param>
    /// <param name="predicate">A function to test each element of the collection.</param>
    /// <returns><see cref="true"/> if the collection does not contain any elements that satisfy the condition; otherwise, <see cref="false"/>.</returns>
    public static bool None<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => !collection.Any(predicate);

    /// <summary>
    /// Performs the specified action on each element of the collection.
    /// </summary>
    /// <typeparam name="T">Type of the elements of the collection.</typeparam>
    /// <param name="collection">The collection whose elements are passed to the specified action.</param>
    /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the collection.</param>
    /// <remarks>If the collection is a <see cref="List{T}"/>, the specified action will be passed to <see cref="List{T}.ForEach(Action{T})"/> method.</remarks>
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        _ = Guard.Null(action);

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

    /// <summary>
    /// Determines whether an <see cref="IEnumerable{T}"/> is null or an empty collection.
    /// </summary>
    /// <typeparam name="T">type of the elements of the collection.</typeparam>
    /// <param name="collection">The <see cref="IEnumerable{T}"/> to check.</param>
    /// <returns><see cref="true"/> if the collection is null or has no elements; otherwise, <see cref="false"/>.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection is null || !collection.Any();
}
