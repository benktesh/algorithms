using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    //Matrix representing landforms. '0's represent water. Find size of ponds (i.e., connected cells makes up size). Disconnected cells with '0' values makes pond
    public class PondSize
    {

        public IList<int> ComputePondSize(int[][] land)
        {
            var pondSizes = new List<int>(); 
            if (land == null)
                return pondSizes;
            int row = land.Length;
            int col = land[0].Length;

            for(int r = 0; r < row; r++)
            {
                for (int c= 0; c < col; c++)
                {
                    if(land[r][c] == 0) //this is the pond
                    {
                        int size = ComputeSize(land, r, c);
                        pondSizes.Add(size);
                    }
                }
            }

            return pondSizes;
        }

        public int ComputeSize(int[][] land, int row, int col)
        {
            //index bound check, visited or not-water check to return 0
            if(row < 0 || col < 0 || land == null || row >= land.Length || col >= land[row].Length || land[row][col] != 0 )
            {
                return 0;
            }

            int size = 1;// the first cell is pond so size is 1.
            land[row][col] = -1; //mark this cell visited

            //we will check the 8 neighbors
            for(int dr = -1; dr <= 1; dr++)
            {
                for(int dc = -1; dc <= 1; dc++)
                {
                    size += ComputeSize(land, row + dr, col + dc);
                }
            }
            return size;
        }

        public void RunMe()
        {

            int[][] land = new int[][] {

            new int[] { 0, 2, 1, 0 },
            new int[] { 0, 1, 0, 1 },
            new int[] { 1, 1, 0, 1 },
            new int[] { 0, 1, 0, 1 },

            };

            Console.WriteLine(land.Length);

            var data = ComputePondSize(land);

        }
    }
}
