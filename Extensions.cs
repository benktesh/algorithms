using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.ExtensionMethods
{
    public static class Extensions
    {
        public static T Peek<T>(this MyStack<T> stack)
        {
            var currentTop = stack.Pop();
            stack.Push(currentTop);
            return currentTop;
        }
    }
}
