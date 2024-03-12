namespace Zadanie_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<int> valuesList = new List<Int32>() { 1, 2, 3, 4, 5 };

            Console.WriteLine($"Average is: {CountAverage(valuesList)}");
        }

        private static double CountAverage(List<int> values)
        {
            var sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }

            return (double)sum / values.Count;
        }

        public static int CountMax(List<int> values)
        {
            return values.Max();
        }
    }
}