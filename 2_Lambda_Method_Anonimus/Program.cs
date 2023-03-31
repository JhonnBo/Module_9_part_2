namespace _2_Lambda_Method_Anonimus
{
    delegate bool MyCh(int x);
    delegate double MyKvKub(int x);
    delegate int MinMax(int[] x);
    internal class Program
    {
        static MyCh Ch = delegate (int x) // анонимный метод
        {
            return x % 2 == 0;
        };

        static MyCh Ch1 = x => x % 2 == 0; // Лямбда выражение

        static MyKvKub Kv = delegate (int x) // анонимный метод
        {
            return x * x;
        };

        static MyKvKub Kv1 = x => x * x; // Лямбда выражение

        static MyKvKub Kub = delegate (int x) // анонимный метод
        {
            return x * x * x;
        };

        static MyKvKub Kub1 = x => x * x * x; // Лямбда выражение

        static MinMax MyMax = x => // Лямбда выражение
        {            
            int m = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (m < x[i]) m = x[i];
            }
            return m;
        };

        static Func<int[], int> MyMax2 = (x) =>
        {
            int m = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (m < x[i]) m = x[i];
            }
            return m;
        };


        static Predicate<int> Even = (x) => x % 2 == 0;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка на четность: " + Ch(4));
            Console.WriteLine("Проверка на четность: " + Ch1(5));
            Console.WriteLine("Квадрат числа: " + Kv(5));
            Console.WriteLine("Квадрат числа: " + Kv1(6));
            Console.WriteLine("Куб числа: " + Kub(5));
            Console.WriteLine("Куб числа: " + Kub1(6));

            int[] x = { 5, 6, 4, 8, -1, 1, 7 };
            Console.WriteLine("Макс массива: " + MyMax(x));
            Console.WriteLine("Макс массива: " + MyMax2(x));

            Console.WriteLine("Проверка на четность через предикат: " + Even(4));

            var MyMin = (int[] x) => {
                int m = x[0];
                for (int i = 1; i < x.Length; i++)
                {
                    if (m > x[i]) m = x[i];
                }
                return m;
            };

            Console.WriteLine("Мин массива: " + MyMin(x));

        }
    }
}
