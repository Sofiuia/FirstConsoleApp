using System;

public class MyClass
{
    // Field
    private string message;

    //Property
    public int Number { get; set; }

    //Конструктор без параметрів
    public MyClass()
    {
        message = "Привіт";
    }

    // Конструктор з параметрами
    public MyClass(string msg)
    {
        message = msg;
    }

    //Публічний метод
    public void PublicMethod()
    {
        Console.WriteLine("Публічний метод викликано!");
        PrivateMethod(); // Викликає приватний метод
    }

    // 🔹 Приватний метод
    private void PrivateMethod()
    {
        Console.WriteLine("Приватний метод працює. Повідомлення: " + message);
    }
}
