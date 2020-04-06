using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace KickStart._2020.RoundA.Allocation
{
    static class Allocation
    {
        public static void Solve()
        {
            var input = GetInput();
            for (int i = 0; i < input.Item1; i++)
            {
                int caseNumber = i + 1;
                Console.Out.WriteLine($"Case #{caseNumber}: {GetMaxNumberOfHouses(input.Item2[i], input.Item3[i])}");
            }
        }

        private static Tuple<int, int[], List<int>[]> GetInput()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int[] budgets = new int[t];
            List<int>[] houseLists = new List<int>[t];

            for (int i = 0; i < t; i++)
            {
                string[] conditions = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(conditions[0]);
                int b = Convert.ToInt32(conditions[1]);

                List<int> houses = new List<int>();
                foreach (string house in Console.ReadLine().Split(' '))
                {
                    houses.Add(Convert.ToInt32(house));
                }
                houses.Sort();

                budgets[i] = b;
                houseLists[i] = houses;
            }
            return Tuple.Create(t, budgets, houseLists);
        }

        private static int GetMaxNumberOfHouses(int budget, List<int> sortedHouses)
        {
            int currentValue = 0;
            int i = 0;

            foreach(int house in sortedHouses)
            {
                currentValue += house;
                if (currentValue <= budget)
                {
                    i++;
                }
                else
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
