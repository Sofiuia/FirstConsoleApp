using System;
using System.Collections.Generic;

public class ExpressionCalculator
{
    private static int Precedence(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }

    private static double ApplyOp(char op, double b, double a)
    {
        switch (op)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/':
                if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                return a / b;
            default: return 0;
        }
    }

    public static double Evaluate(string expression)
    {
        expression = expression.Replace(" ", "");
        var values = new Stack<double>();
        var ops = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (char.IsDigit(expression[i]))
            {
                string sBuf = "";
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    sBuf += expression[i++];
                }
                values.Push(double.Parse(sBuf));
                i--;
            }
            else if (expression[i] == '(')
            {
                ops.Push(expression[i]);
            }
            else if (expression[i] == ')')
            {
                while (ops.Peek() != '(')
                {
                    values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                }
                ops.Pop();
            }
            else
            {
                while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(expression[i]))
                {
                    values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                }
                ops.Push(expression[i]);
            }
        }

        while (ops.Count > 0)
        {
            values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
        }

        return values.Pop();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть вираз (наприклад: 5 + 3 * 2):");
        string expression = Console.ReadLine();

        try
        {
            double result = Evaluate(expression);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка у виразі: " + ex.Message);
        }
    }
}