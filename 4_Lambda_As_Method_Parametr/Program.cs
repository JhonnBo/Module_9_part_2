namespace _4_Lambda_As_Method_Parametr
{
    internal class Program
    {
        //delegate bool IsEqual(int x);
        static void Main(string[] args)
        {
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // найдем сумму чисел больше 5
            int result = Sum(integers, x => x > 5);
            Console.WriteLine("Сумма чисел больше 5: " + result);

            // найдем сумму четных чисел используя блочный лямбда
            result = Sum(integers, x =>   // result = Sum(integers, x => x % 2 == 0);
            {
                if (x % 2 == 0) return true;
                else return false;
            }
            );

            Console.WriteLine("Сумма чётных чисел: " + result);
        }

        //private static int Sum(int[] numbers, IsEqual func)
        private static int Sum(int[] numbers, Predicate<int> func)
        {
            int result = 0;
            foreach (int i in numbers)
            {
                if (func(i))
                    result += i;
            }
            return result;
        }
    }
}