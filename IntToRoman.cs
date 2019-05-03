using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class IntToRoman
    {
        Dictionary<int,String> map = new Dictionary<int, string>();

        public void CreateMap()
        {
            if (map.Count > 0)
            {
                return;
            }
            map.Add(1, "I");
            map.Add(2, "II");
            map.Add(3, "III");
            map.Add(4, "IV");
            map.Add(5, "V");
            map.Add(6, "VI");
            map.Add(7, "VII");
            map.Add(8, "VIII");
            map.Add(9, "IX");
            map.Add(10, "X");
            map.Add(50, "L");
            map.Add(100, "C");
            map.Add(500, "D");
            map.Add(1000, "M");

        }
        public string GetRoman(int num)
        {
            CreateMap();
            var roman = "";
            if (num <= 10)
            {
                return map[num];
            }
            Stack<String> stk = new Stack<string>();
            int count = 1;
            while (num % (count*10) > 0)
            {
                var remainder = num % (10*count);
                count++;
                num = num / 10 *  (10 * count);
            }
            
            return roman;
        }
        public void Run()
        {
            int num = 3;
            Console.WriteLine($"{num} => {GetRoman(num)}");

        }

        
    }
}
