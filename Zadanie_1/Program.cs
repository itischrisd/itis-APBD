namespace Zadanie_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<int> valuesList = new List<Int32>() { 1, 2, 3, 4, 5 };

            Console.WriteLine($"Average is: {CountAverage(valuesList)}");
            Console.WriteLine($"Max value is: {CountMax(valuesList)}");
        }

        private static double CountAverage(List<int> values)
        {
            var sum2 = 0;
            foreach (var value in values)
            {
                sum2 += value;
            }

            return (double)sum2 / values.Count;
        }

        private static int CountMax(List<int> values)
        {
            var max = int.MinValue;
            foreach (var value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }
    }
}