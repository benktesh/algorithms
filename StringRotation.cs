using System;

namespace algorithms
{
    public class StringRotation
    {
        public bool IsRotated(String str1, String str2)
        {
            var temp = str1 + str1;
            return temp.Contains(str2);
        }

        public void Run()
        {

            string str1 = "geeks";
            string str2 = "eksge";

            Console.Write($"Is {str2} a rotatio of {str1}? ");
            Console.WriteLine(IsRotated(str1, str2) ? "Yes" : "No");
        }
    }
}