
using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace algorithms
{
    public enum SolutionTypes
    {
        Iterative, Recurisve, Unknown
    }
    public static class Utilities {
        public static void PrintArray(int[] arr) {

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(" ");
        
        
        }

        public static String GetBitString(int x)
        {
            return Convert.ToString(x, 2).PadLeft(32, '0');
        }

        /// <summary>
        /// Takes string of integer separated by whitespace and returns an array of integer
        /// Writes error for any exceptions encountered and returns null if that is the case.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int[] PraseToIntArray(String data)
        {
            try
            {
                return data.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Int32.Parse(x)).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("parseToInt: " + ex.StackTrace);
                return null;
            }

        }

        public static void PrintArray(bool[,] data)
        {
            int n = data.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(data[i,j] + " ");
                }
                Console.WriteLine("");

            }
        }

       

    }
}