﻿using System.Collections;
using System.Collections.Generic;

namespace MongoTool.Core.ExtensionMethods
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this IList collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}