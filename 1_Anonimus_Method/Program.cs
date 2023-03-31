namespace _1_Anonimus_Method
{
    // Иногда основанием для существования метода служит то обстоятельство, 
    // что он должен быть вызван только один раз посредством делегата. 
    // В подобных случаях можно воспользоваться анонимной функцией, чтобы не создавать отдельный метод.
    // Анонимная функция, по существу, представляет собой безымянный кодовый блок, 
    // передаваемый конструктору делегата. 
    // Преимущество анонимной функции состоит, в частности, в ее простоте. 
    // Благодаря ей отпадает необходимость объявлять отдельный метод, 
    // единственное назначение которого состоит в том, что он передается делегату.
    internal class Program
    {
        delegate double MathAct(double x, double y); // объявляем тип делегата
        delegate void message();


        //=========================================================
        //-------------- Анонимный метод --------------------------
        //=========================================================
        static MathAct Sum = delegate (double a, double b)
        {
            return a + b;
        };

        //=========================================================
        //-------------- Лямбда выражение -------------------------
        //=========================================================
        static MathAct Diff = (double a, double b) =>
        {
            return a - b;
        };

        static MathAct Diff1 = (double a, double b) => a - b; // Одиночное лямбда-выражение
        static message GetMessage = () => Console.WriteLine("Лямбда-выражение"); // Еще одно одиночное лямбда-выражение


        //=========================================================
        //-------------- Традиционная функция ---------------------
        //=========================================================
        static MathAct Multi = Mult;
        static double Mult(double a, double b)
        {
            return a * b;
        }

        //=========================================================
        //-------------- Определение тела выражения ---------------
        // https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition
        //=========================================================
        static double Div(double a, double b) => a / b;

        static void Main(string[] args)
        {
            Console.WriteLine("Sum of numbers: " + Sum(3, 4));
            Console.WriteLine("Diff of numbers: " + Diff(3, 4));
            Console.WriteLine("Mult of numbers: " + Multi.Invoke(3, 4));            
            Console.WriteLine("Div of numbers: " + Div(3, 4));
            //Thread.Sleep(1000);
            GetMessage();
        }
    }
}