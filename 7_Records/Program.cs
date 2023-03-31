namespace _7_Records
{
    // Records представляют новый ссылочный тип, который появился в C#9.
    // Ключевая особенность records состоит в том, что они могут представлять
    // неизменяемый (immutable) тип, который по умолчанию обладает рядом
    // дополнительных возможностей по сравнению с классами и структурами.

    // Для определения records используется ключевое слово record.
    // Если определяется класс record, то ключевое слово class можно
    // неиспользовать при определении типа:

    public record Person
    {
        public string Name { get; set; }
        public Person(string name) => Name = name;
    }

    public record class Person1
    {
        public string Name { get; init; } // модификатор init
        public Person1(string name) => Name = name;
        public void myMethod(int x)
        {
            Console.WriteLine( x * x);
        }
    }

    // При определении структуры record при объявлении типа надо использовать ключевое слово struct:
    public record struct Person2
    {
        public string Name { get; set; }
        public Person2(string name) => Name = name;
    }

    internal class Program
    {
        // Хотя типы record предназначены для создания неизменяемых типов,
        // однако одно только применение ключевого слова record не гарантирует неизменяемость объектов record. 
        static void Main(string[] args)
        {
            var person = new Person("Tom");
            person.Name = "Bob";
            Console.WriteLine(person.Name); // Bob - данные изменились
                                            // Чтобы сделать его действительно неизменяемым,
                                            // для свойств вместо обычных сеттеров надо использовать модификатор init.
            var person1 = new Person1("Tom");
            //person1.Name = "Bob"; // ! ошибка - свойство изменить нельзя
            Console.WriteLine(person1.Name); // Bob - данные изменились
            person1.myMethod(1);

            // Позиционные records
            var person3 = new Person3("Tom", 37);
            Console.WriteLine(person3); //по умолчанию реализован метод ToString(), который выводит состояние объекта в отформатированном виде
            // person3.Name = "Nick"; Свойства класса record, которые устанавливаются через параметры конструктора,
            // по умолчанию будут иметь модификатор init.

            // Однако для позиционных структур record свойства будут иметь стандартные сеттеры,
            // которые позволят изменять значения свойств:
            var person4 = new Person4("Tom", 37);
            person4.Name = "Bob";
            Console.WriteLine(person4.Name); // Bob - значение изменилось

            // Чтобы для подобных свойств структуры record использовался модификатор init
            // вместо обычных сеттеров, такую структуру надо определить с ключевым словом readonly:
            var person5 = new Person5("Tom", 37);
            //person5.Name = "Bob";    // ! Ошибка - значение свойства нельзя изменить
        }
    }
    // Позиционные records
    record Person3(string Name, int Age);

    // Позиционные структуы records
    public record struct Person4(string Name, int Age);

    // Позиционные структуы records с ключевым словом readonly:
    public readonly record struct Person5(string Name, int Age);

    // Как и обычные классы record-классы могут наследоваться:
    public record Person6(string Name, int Age);
    public record Employee(string Name, int Age, string Company) : Person6(Name, Age);

}


//Записи (справочник по C#)
// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/record
