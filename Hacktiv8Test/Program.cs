using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacktiv8Test
{
    class Program
    {
        public Program()
        {
            int[] test11 = SecondGreatLow(new int[] { 7, 7, 12, 98, 106 });
            int[] test12 = SecondGreatLow(new int[] { 7, 106 });
            int[] test13 = SecondGreatLow(new int[] { 7, 7 });
            int[] test14 = SecondGreatLow(new int[] { 10, 8, 9, 11, 20, 17, 15 });

            int test21 = MultiplicativePersistence(39);
            int test22 = MultiplicativePersistence(42);

            int test31 = MeanMode(new int[] { 5, 3, 3, 3, 1 });
        }
        private int[] SecondGreatLow(int[] numbers)
        {
            if (numbers.Length < 2)
                throw new ArgumentException();

            numbers = numbers.OrderBy(x => x).ToArray();
            int max = numbers[numbers.Length - 1];
            int min = numbers[0];

            // Assume we have two numbers
            int secondMax = max;
            int secondMin = min;

            // Find the next minimum
            for (int index = 1; index < numbers.Length - 1; index++)
            {
                if (secondMin < numbers[index] && numbers[index] != max)
                {
                    secondMin = numbers[index];
                    break;
                }
            }

            for (int index = numbers.Length - 1; index > 0; index--)
            {
                if (secondMax > numbers[index] && numbers[index] != min)
                {
                    secondMax = numbers[index];
                    break;
                }
            }

            return new int[] { secondMin, secondMax };
        }

        private int MultiplicativePersistence(int number)
        {
            string word = number.ToString();
            if (word.Length > 1)
            {
                char[] letters = word.ToCharArray();
                int result = int.Parse(letters[0].ToString());
                for (int index = 1; index < letters.Length; index++)
                    result *= int.Parse(letters[index].ToString());

                string wordResult = result.ToString();
                return wordResult.Length > 1 ?
                    MultiplicativePersistence(result) + 1 :
                    MultiplicativePersistence(result);
            }

            return 1;
        }

        private static int TRUE = 1;
        private static int FALSE = 0;
        private int MeanMode(int[] numbers)
        {
            int mean = (int)numbers.Average();

            int modeIndex = 0;
            int modeCount = numbers.Count(x => x == numbers[modeIndex]);
            for (int index = 0; index < numbers.Length; index++)
            {
                int temp = numbers.Count(x => x == numbers[index]);
                if (temp > modeCount)
                {
                    modeIndex = index;
                    modeCount = numbers[modeIndex];
                }
            }

            return mean == numbers[modeIndex] ? TRUE : FALSE;
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
