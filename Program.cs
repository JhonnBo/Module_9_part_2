namespace Extension_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = "Hello World".CharCount('o');
            Console.WriteLine("Hello, World! contain o: " + count + " times");

            count = "Hello World".CharCount('l');
            Console.WriteLine("Hello, World! contain l: " + count + " times");

            MyMath myMath = new MyMath();
            myMath.Square(5);
            Console.WriteLine("Проверка на четность: " + myMath.MyMathEven(5));

        }
    }

    static class Extentions
    {
        public static int  CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
        public static bool MyMathEven(this MyMath myMath, int x) => x % 2 == 0;
        
    }

    sealed class MyMath
    {
        public void Square(int x)
        {
            Console.WriteLine($"Square {x} is {x * x}");
        }
    }
    // class MyClass : MyMath { } // Нельзя! Запрещено!
}