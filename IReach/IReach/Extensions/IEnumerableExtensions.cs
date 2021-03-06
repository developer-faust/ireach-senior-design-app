﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IReach.Extensions
{
    public static class IEnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> items)
        {
            var result = new ObservableCollection<T>();
            result.AddRange(items);
            return result;
        }
    }

}
