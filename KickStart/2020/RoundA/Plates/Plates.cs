using System;
using System.Collections.Generic;
using System.Text;

namespace KickStart._2020.RoundA.Plates
{
    /*
     * N Stacks
     * K Plates
     * each Plate got beauty value
     * P Plates for dinner
     */
    static class Plates
    {
        public static void Solve()
        {
            var input = GetInput();
            for (int i = 0; i < input.Item1; i++)
            {
                int caseNumber = i + 1;
                Console.Out.WriteLine($"Case #{caseNumber}: {GetMaxBeautyValue(input.Item2[i], input.Item3[i])}");
            }
        }

        private static Tuple<int, int[], List<List<int>>[]> GetInput()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            int[] plates = new int[t];
            List<List<int>>[] beautyValueLists = new List<List<int>>[t];

            for (int i = 0; i < t; i++)
            {
                string[] conditions = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(conditions[0]);
                int k = Convert.ToInt32(conditions[1]);
                int p = Convert.ToInt32(conditions[2]);

                List<List<int>> beautyValues = new List<List<int>>();
                for (int j = 0; j < n; j++)
                {
                    beautyValues.Add(new List<int>());
                    foreach (string beautyValue in Console.ReadLine().Split(' '))
                    {
                        beautyValues[j].Add(Convert.ToInt32(beautyValue));
                    }
                }
                plates[i] = p;
                beautyValueLists[i] = beautyValues;
            }
            return Tuple.Create(t, plates, beautyValueLists);
        }

        private static int GetMaxBeautyValue(int plates, List<List<int>> beautyValues)
        {
            int maxBeautyValue = 0;
            int[] currentValue = new int[beautyValues.Count];// ToBase(beautyValues[0].Count, plates);
            while (PossiblePlateCombination(ref currentValue, beautyValues[0].Count, plates))
            {
                int tempBeuatyValue = 0;
                for (int i = 0; i < beautyValues.Count; i++)
                {
                    for (int j = 0; j < currentValue[i]; j++)
                    {
                        tempBeuatyValue += beautyValues[i][j];
                    }
                }
                if (tempBeuatyValue > maxBeautyValue)
                    maxBeautyValue = tempBeuatyValue;
            }
            return maxBeautyValue;
        }

        public static bool PossiblePlateCombination(ref int[] value, int stackSize, int numberOfPlates)
        {
            int position = 0;
            bool overflow;
            var modulo = stackSize + 1;
            do
            {
                int digit = value[position];
                int newDigit = ++digit % modulo;
                value[position] = newDigit;
                if (newDigit < digit)
                {
                    overflow = true;
                    position++;
                    if (position > (value.Length - 1))
                        return false;
                }
                else
                {
                    overflow = false;
                }
            }
            while (overflow);

            int tempChecksum = 0;
            foreach (int val in value)
            {
                tempChecksum += val;
            }

            if (tempChecksum != numberOfPlates)
                return PossiblePlateCombination(ref value, stackSize, numberOfPlates);

            return true;
        }
    }
}
