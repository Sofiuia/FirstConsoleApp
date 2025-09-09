using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Друге завдання C# ===");

        //Арифметичні операції
        int a = 10;
        double b = 2.5;
        Console.WriteLine($"Додавання: {a} + {b} = {a + b}");
        Console.WriteLine($"Множення: {a} * {b} = {a * b}");

        //Логічні оператори
        bool result = (a > 5) && (b < 3);
        Console.WriteLine($"Логічний вираз (a > 5 && b < 3): {result}");

        // Умовні оператори
        if (a > 5)
            Console.WriteLine("a більше за 5");
        else if (a == 5)
            Console.WriteLine("a дорівнює 5");
        else
            Console.WriteLine("a менше за 5");

        switch (a)
        {
            case 10: Console.WriteLine("a дорівнює 10"); break;
            default: Console.WriteLine("Інше значення"); break;
        }

        //Цикли з масивом
        int[] numbers = { 1, 2, 3, 4, 5 };

        Console.WriteLine("Цикл for:");
        for (int i = 0; i < numbers.Length; i++)
            Console.Write(numbers[i] + " ");

        Console.WriteLine("\nЦикл foreach:");
        foreach (int num in numbers)
            Console.Write(num + " ");

        Console.WriteLine("\nЦикл while:");
        int j = 0;
        while (j < numbers.Length)
        {
            Console.Write(numbers[j] + " ");
            j++;
        }

        Console.WriteLine("\nЦикл do...while:");
        int k = 0;
        do
        {
            Console.Write(numbers[k] + " ");
            k++;
        } while (k < numbers.Length);

        // Використання списку
        List<string> names = new List<string> { "Софія", "Іван", "Марія" };
        Console.WriteLine("\nСписок і цикл foreach:");
        foreach (string name in names)
            Console.WriteLine(name);

        // Виклик класу
        MyClass obj = new MyClass("Hello!");
        obj.PublicMethod();
    }
}

