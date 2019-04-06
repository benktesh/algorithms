using System;
using System.Collections.Generic;
using System.Text;


namespace algorithms
{
       
    public class ActiveInActiveCell
        {
        //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        private int[] CellCompete(int[] states, int days)
        {
            // INSERT YOUR CODE HERE

            int l = states.Length;

            int[] temp = new int[l];


            for (int d = 0; d < days; d++)
            {
                //handle first 
                // Console.WriteLine(string.Join(' ', states) +  " Day before " + d);
                if (states[1] == 1)
                {
                    temp[0] = 1;
                }
                else
                {
                    temp[0] = 0;
                }


                //handle last cell
                if (states[l - 2] == 1)
                {
                    temp[l - 1] = 1;
                }
                else
                {
                    temp[l - 1] = 0;
                }

                for (int i = 1; i < l - 1; i++)
                {

                    if (states[i - 1] != states[i + 1])
                    {
                        temp[i] = 1;
                    }
                    else
                    {
                        temp[i] = 0;
                    }
                }

                //for(int t= 0; t < l; t++){
                //    states[t] = temp[t];
                //    }
                
                Array.Copy(temp, states, l);
                
            }

            return states;
        }

        public void Run()
        {
            int[] arr = {1, 1, 1, 0, 1, 1, 1, 1};
            var states = CellCompete(arr, 2);
            Console.WriteLine(string.Join(' ', states));
        }
    }
}
