using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    /// <summary>
    /// Length of the longest valid substring
    /// Given a string consisting of opening and closing parenthesis, find length of the longest valid parenthesis substring.
    /// 
    /// Examples:
    /// 
    /// Input : ((()
    /// Output : 2
    /// Explanation : ()
    /// </summary>
    public class LongestValidSubstring
    {

        public void Run()
        {

            var str = "()(()))))";
            FindMaxLen(str); 
            FindMaxLen("((()()");
        }

        private void FindMaxLen(string str)
        {
            var stack = new Stack();
            var count = 0; 
            foreach (var s in str)
            {
                if (s == '(')
                {
                    stack.Push(1);
                }
                else if (s == ')' && stack.Count > 0)
                {
                    stack.Pop();
                    count++;
                }
            }
            Console.WriteLine($"Number of Valid SubString: {count*2}");
        }
    }
}
