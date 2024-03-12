namespace Zadanie_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<int> valuesList = new List<Int32>() { 1, 2, 3, 4, 5 };
        }

        public static double CountAverage(List<int> values)
        {
            return values.Average();
        }

        public static int CountMax(List<int> values)
        {
            return values.Max();
        }
    }
}