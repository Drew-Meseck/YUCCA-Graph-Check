using System;

namespace YUCCACheck
{
    class Program
    {
        /// <summary>
        /// Author: Drew Meseck
        /// Homework #4
        /// Professor Owrang
        /// Algorithms and Data Structures
        /// </summary>
        /// 
        static void Main()
        {
            //Input Graph that we will check if YUCCA. (Rows are "From" and Columns are "To" for directed graph)
            //Read "From A to F" for example for [0,5]
            //IMPORTANT: Adjacency matricies are by definition square (Columns = Rows)
            //Currently B makes the graph a valid YUCCA
            //                  A  B  C  D  E  F
            int[,] matrix = { { 0, 0, 1, 1, 1, 1 }, //A
                              { 1, 0, 1, 1, 1, 1 }, //B
                              { 0, 0, 0, 1, 0, 0 }, //C
                              { 1, 0, 0, 0, 1, 0 }, //D
                              { 0, 0, 0, 0, 0, 0 }, //E
                              { 0, 0, 0, 0, 1, 0 }, //F
                            };
            bool result = Is_YUCCA(matrix);

            Console.WriteLine($"Is the Matrix Given a YUCCA? : {result}");


        }

        public static bool Is_YUCCA(int[,] M) //The actual algorithm
        {
            for(int i = 0; i < (M.Length / Math.Sqrt((double)M.Length)) ; i++) //M.Length gives area of matrix, so dividing by the square give you the length of 1 row or column
            {
                bool in_flag = true;
                int out_count = 0;
                for(int j = 0; j < (M.Length / Math.Sqrt((double)M.Length)); j++)
                {
                    if (M[j, i] == 1)
                    {
                        in_flag = false;
                        continue;
                    }
                }
                
                if(in_flag == true)
                {
                    for(int f = 0; f < (M.Length / Math.Sqrt((double)M.Length)); f++)
                    {
                        if (M[i, f] == 1)
                            out_count++;
                    }
                    if(out_count == (M.Length / Math.Sqrt((double)M.Length)) - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
