using System.Collections.Generic;
using System.Linq;

namespace PowerUp
{
    public static class CollectionExtensions
    {
        public static void RemoveRange<T>(this ICollection<T> lst, IEnumerable<T> removeList)
        {
            foreach (var item in removeList)
            {
                if (lst.Contains(item))
                    lst.Remove(item);
            }
        }

        public static int GetLastIndex<T>(this IEnumerable<T> obj)
        {
            return obj.Count() - 1;
        }
    }
}