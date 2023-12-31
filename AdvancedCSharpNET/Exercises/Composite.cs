﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Exercises
{

    public interface IValueContainer : IEnumerable<int>
    {
    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {
    }

    public static class ExtensionMethods
    {
        public static int Sum(this IEnumerable<IValueContainer> containers)
        {
            int result = 0;
            foreach (var container in containers)
            {
                foreach (var i in container)
                    result += i;
            }
            return result;
        }
    }
}
