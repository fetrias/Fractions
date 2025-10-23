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

                SimplifyAndPrintFraction(numerator, denominator);
            }
            else
            {
                Console.WriteLine("Нужны целые числа!");
            }
        }

        Console.WriteLine("Работа программы завершена.");
    }

    static void SimplifyAndPrintFraction(int numerator, int denominator)
    {
        int originalNumerator = numerator;
        int originalDenominator = denominator;

        int gcd = FindGCD(Math.Abs(numerator), Math.Abs(denominator));

        int simplifiedNumerator = numerator / gcd;
        int simplifiedDenominator = denominator / gcd;

        if (simplifiedDenominator < 0)
        {
            simplifiedNumerator = -simplifiedNumerator;
            simplifiedDenominator = -simplifiedDenominator;
        }

        Console.WriteLine($"Исходная дробь: {originalNumerator} / {originalDenominator}");

        if (simplifiedDenominator == 1)
        {
            Console.WriteLine($"Результат: {simplifiedNumerator}");
        }
        else
        {
            Console.WriteLine($"Результат: {simplifiedNumerator} / {simplifiedDenominator}");
        }
    }

    static int FindGCD(int a, int b)
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