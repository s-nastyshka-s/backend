namespace Calculator;

class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            ShowMenu();

            int operation;
            decimal operand1;
            decimal operand2;

            decimal result;
            try
            {
                operation = Convert.ToInt32(Console.ReadLine());

                if (operation < 1 || operation > 5)
                {
                    throw new Exception("Неверный номер операции");
                }

                Console.WriteLine("Введите первый операнд");
                operand1 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Введите второй операнд");
                operand2 = Convert.ToDecimal(Console.ReadLine());

                result = Calculate(operation, operand1, operand2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                PressAnyKey();
                continue;
            }

            Console.WriteLine("Результат: " + result);
            PressAnyKey();
        }
    }

    private static decimal Addition(decimal operand1, decimal operand2)
    {
        return operand1 + operand2;
    }

    private static decimal Subtraction(decimal operand1, decimal operand2)
    {
        return operand1 - operand2;
    }

    private static decimal Multiplication(decimal operand1, decimal operand2)
    {
        return operand1 * operand2;
    }

    private static decimal Division(decimal operand1, decimal operand2)
    {
        if (operand2 == 0)
        {
            throw new DivideByZeroException();
        }
        return operand1 / operand2;
    }

    private static void PressAnyKey()
    {
        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");
    }

    private static decimal Calculate(int operation, decimal operand1, decimal operand2)
    {
        switch (operation)
        {
            case 1:
                return Addition(operand1, operand2);
            case 2:
                return Subtraction(operand1, operand2);
            case 3:
                return Multiplication(operand1, operand2);
            case 4:
                return Division(operand1, operand2);
            default:
                throw new Exception("Неверный номер операции");
        }
    }
}
