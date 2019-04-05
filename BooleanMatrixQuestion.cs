using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    /// <summary>
    /// Given a boolean matrix mat[M][N] of size M X N, modify it such that if a matrix cell mat[i][j] is 1 (or true) then make all the cells of ith row and jth column as 1.
    /// Example 1
    /// The matrix
    /// 1 0
    /// 0 0
    /// should be changed to following
    /// 1 1
    /// 1 0
    /// </summary>
    public class BooleanMatrixQuestion
    {
        public void ModifyMatrix(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            HashSet<int> rowFlags = new HashSet<int>();
            HashSet<int> colFlags = new HashSet<int>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (!rowFlags.Contains(i))
                        {
                            rowFlags.Add(i);
                        }

                        if (!colFlags.Contains(j))
                        {
                            colFlags.Add(j);
                        }
                    }
                }

            }

            for (int i = 0; i < row; i++)
            {
                bool rf = rowFlags.Contains(i);
                for (int j = 0; j < col; j++)
                {
                    bool cf = colFlags.Contains(j);
                    if ( rf || cf)
                    {
                        matrix[i, j] = 1; 
                    }
                }

            }
        }
        public void Run()
        {
            int[,] matrix = {
                {1, 0, 0, 1},
                {0, 0, 1, 0},
                {0, 0, 0, 0}
            };

            ModifyMatrix(matrix);
        }
    }
}
