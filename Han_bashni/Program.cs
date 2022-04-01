using System.Collections;

namespace MyApp
{
    class Program
    {
        //рекурсивная метод перестановки кольца с башни from на башню to
        //свободная башня free
        //n число колец для перестановки
        static void Swaping(int n, Stack from, Stack to, Stack free)
        {
            if (n != 0)
            {
                Swaping(n - 1, from, free, to);
                to.Push(from.Pop());
                Swaping(n - 1, free, to, from);
            }
        }
        static void Main(string[] args)
        {
            //Считываем какое количество колец использовать
            Console.WriteLine("Введите число колец на левой башне");
            int n;
            if (!Int32.TryParse(Console.ReadLine(), out (n)))
            {
                Console.WriteLine("Введенное число содержит не допустимые символы");
                return;
            }

            //частные случаи
            if (n < 1)
            {
                Console.WriteLine("Число колец не может быть меньше или равно 0");
                return;
            }
            //объявляем три башни
            Stack left = new Stack();
            Stack midl = new Stack();
            Stack right = new Stack();

            //заполняем левую башню кольцами
            for (int i = n; i > 0; i--)
            {
                left.Push(i);
            }
            Console.WriteLine("На какую башню переложить кольца \n(по умолчанию перемещение на среднюю башню)\n\vmidl or right ?");

            //даем выбрать на какую башню переместить кольца
            if (Console.ReadLine() == "midl")
            {
                Console.WriteLine("Левая Средняя Правая");
                Swaping(n, left, midl, right);
                //выводим кольца со средней башни
                while (midl.Count != 0)
                {
                    Console.WriteLine("      " + midl.Pop());
                }
                Console.WriteLine("Успешно перемещены кольца с левой башни на среднюю");
            }
            else
            {
                Console.WriteLine("Левая Средняя Правая");
                Swaping(n, left, right, midl);
                //выводим кольца с правой башни
                while (right.Count != 0)
                {
                    Console.WriteLine("              " + right.Pop());
                }
                Console.WriteLine("Успешно перемещены кольца с левой башни на правую");
            }
            Console.ReadLine();
        }
    }
}
