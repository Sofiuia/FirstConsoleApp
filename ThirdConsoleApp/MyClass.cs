using System;

public class MyClass : MyAbstract, IRegular, IGeneric<string>
{
    // Поле
    private string message;
    // Властивість
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    // Конструктор без параметрів
    public MyClass()
    {
        message = "Привіт";
    }
    // Конструктор з параметром
    public MyClass(string msg)
    {
        message = msg;
    }
    // Публічний метод
    public void PublicMethod()
    {
        Console.WriteLine($"Публічний метод: {message}");
        PrivateMethod();
    }
    // Приватний метод
    private void PrivateMethod()
    {
        Console.WriteLine("Приватний метод ");
    }
    // Реалізація абстрактного методу
    public override void AbstractMethod()
    {
        Console.WriteLine("Реалізація абстрактного методу.");
    }
    // Реалізація IMyInterface
    public void DoDoDo()
    {
        Console.WriteLine("IMyInterface метод викликано.");
    }
    // Реалізація IGeneric
    public string Process(string item)
    {
        return item.ToUpper();
    }
    public string Proces(string input)
{
    return input.ToUpper();
}

}
