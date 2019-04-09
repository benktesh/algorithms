
using System;
using System.Linq;
using System.Text;

namespace algorithms
{
    public enum SolutionTypes
    {
        Iterative, Recurisve, Unknown
    }

    public enum Color
    {
        WHITE, GREY, BLACK
    }
    public static class Utilities {


        public static void PrintArray(int[] arr) {

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine(" ");
        
        
        }

        public static String GetBitString(Int32 x)
        {
            return Convert.ToString(x, 2).PadLeft(32, '0');
        }

        public static String GetBitString(long x)
        {
            return Convert.ToString(x, 2).PadLeft(32, '0');
        }

        public static void PrintBitString(int x, string label = null)
        {
            if (!string.IsNullOrEmpty(label))
            {
                Console.WriteLine(label);
            }
            Console.WriteLine(GetBitString(x));
        }

        public static void PrintBitString(long x, String label=null)
        {
            if (!string.IsNullOrEmpty(label))
            {
                Console.WriteLine(label);
            }
            Console.WriteLine(GetBitString(x));
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
                return data.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
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

        public static void PrintArray(int[,] data)
        {
            int n = data.GetLength(0);
            int c = data.GetLength(1);

            int padLength = 6;

            
            var rowHeader = "".PadRight(padLength, ' ') + "|";
            Console.Write(rowHeader);
            int count = rowHeader.Length;
            for (int j = 0; j < c; j++)
            {
                var colIndex = j.ToString().PadRight(padLength, ' ');
                count += colIndex.Length;
                Console.Write(colIndex);
            }
            Console.WriteLine();
            Console.WriteLine(new String('-', count));
            for (int i = 0; i < n; i++)
            {
                Console.Write(i.ToString().PadRight(padLength, ' ') + "|");
                for (int j = 0; j < c; j++)
                {
                    Console.Write(data[i, j].ToString().PadRight(padLength, ' '));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public static void PrintArray(int[,] data, String[] xHeader, String[] yHeader)
        {
            int n = data.GetLength(0);
            int c = data.GetLength(1);

            int padLength = 6;


            var rowHeader = "".PadRight(padLength, ' ') + "|";
            Console.Write(rowHeader);
            int count = rowHeader.Length;
            for (int j = 0; j < c; j++)
            {
                var colIndex = yHeader[j].ToString().PadRight(padLength, ' ');
                count += colIndex.Length;
                Console.Write(colIndex);
            }
            Console.WriteLine();
            Console.WriteLine(new String('-', count));
            for (int i = 0; i < n; i++)
            {
                Console.Write(xHeader[i].ToString().PadRight(padLength, ' ') + "|");
                for (int j = 0; j < c; j++)
                {
                    Console.Write(data[i, j].ToString().PadRight(padLength, ' '));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public static void PrintArray(String[] data, String header = null)
        {
            if (header != null)
            {
                Console.WriteLine(header);
            }

            Console.WriteLine(string.Join(' ', data));
        }
    }
}