using System;
using System.Collections.Generic;
using System.Text;

namespace KickStart._2020.RoundA.Workout
{
    public static class Workout
    {
        public static void Solve()
        {
            var input = GetInput();
            Console.WriteLine(input);
        }

        private static Tuple<int, int[], int[][]> GetInput()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int[] additionalSessions = new int[t];
            int[][] minutesLists = new int[t][];

            for (int i = 0; i < t; i++)
            {
                string[] conditions = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(conditions[0]);
                int k = Convert.ToInt32(conditions[1]);

                int[] minutes = new int[n];
                var tempInput = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    minutes[j] = Convert.ToInt32(tempInput[j]);
                }
                additionalSessions[i] = k;
                minutesLists[i] = minutes;
            }
            return Tuple.Create(t, additionalSessions, minutesLists);
        }
    }
}
