using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerUp
{
    /// <summary>
    ///     Class for Collection method extensions
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        ///     Removes a collection of elements from a collection.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#removerange" />
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="lst">Collection to be updated.</param>
        /// <param name="removeList">Collection of elements to remove.</param>
        public static void RemoveRange<T>(this ICollection<T> lst, IEnumerable<T> removeList)
        {
            if (lst.Any() && removeList.IsNotNull())
                foreach (var item in removeList)
                    if (lst.Contains(item))
                        lst.Remove(item);
        }

        /// <summary>
        ///     Performs a deep copy
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#clone" />
        /// <typeparam name="T">ICloneable elements of the collection</typeparam>
        /// <param name="listToClone">Collection to be cloned</param>
        /// <returns>A collection copy</returns>
        public static IEnumerable<T> Clone<T>(this ICollection<T> listToClone) where T : ICloneable
        {
            if (listToClone.IsNull())
                return null;
            return listToClone.Select(item => (T) item.Clone()).ToList();
        }


        /// <summary>
        ///     Returns the last index of a collection.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#getlastindex" />
        /// <typeparam name="T">Type of elements</typeparam>
        /// <param name="obj">A Collection</param>
        /// <returns>The last index</returns>
        public static int GetLastIndex<T>(this IEnumerable<T> obj)
        {
            if (obj.Any())
                return obj.Count() - 1;
            throw new ArgumentException("The collection must not be empty.");
        }
    }
}