using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class ArrangeElements
    {

        public void ArrangeElement(int[] arr)
        {
            
            var lst = new List<String>();
            foreach (var elem in arr)
            {
                lst.Add(Convert.ToString(elem));
            }

            lst = lst.OrderByDescending(k => k).ToList();
            var str = String.Join(null, lst);
            Console.WriteLine(str);
        }

        public void Run()
        {
            ArrangeElement(new[] { 54, 546, 548, 60 });
        }
    }
}
