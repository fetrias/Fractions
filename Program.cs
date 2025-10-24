using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Для выхода введите done");

        while (true)
        {
            Console.Write("Введите числитель: ");
            string numeratorInput = Console.ReadLine();

            if (numeratorInput?.ToLower() == "done")
                break;

            Console.Write("Введите знаменатель: ");
            string denominatorInput = Console.ReadLine();

            if (denominatorInput?.ToLower() == "done")
                break;

            if (int.TryParse(numeratorInput, out int numerator) &&
                int.TryParse(denominatorInput, out int denominator))
            {
                if (denominator == 0)
                {
                    Console.WriteLine("Знаменатель не может быть равен 0!");
                    continue;
                }

                FractionSimplifier(numerator, denominator);
            }
            else
            {
                Console.WriteLine("Нужны целые числа!");
            }
        }
    }

    static void FractionSimplifier(int numerator, int denominator)
    {
        int firstNumerator = numerator;
        int firstDenominator = denominator;

        int nod = FindNOD(Math.Abs(numerator), Math.Abs(denominator));

        int finalNumerator = numerator / nod;
        int finalDenominator = denominator / nod;

        if (finalDenominator < 0)
        {
            finalNumerator = -finalNumerator;
            finalDenominator = -finalDenominator;
        }

        if (finalDenominator == 1)
        {
            Console.WriteLine($"Результат: {finalNumerator}");
        }
        else
        {
            Console.WriteLine($"Результат: {finalNumerator} / {finalDenominator}");
        }
    }

    static int FindNOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}