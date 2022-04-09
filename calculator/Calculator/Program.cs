using System;
using System.Text.RegularExpressions;

const string Annotation = "Выберете из списка операцию, которой хотите воспользоваться:\n +    -   Сложение,\n -    -   Вычитание,\n *    -   Умножение,\n /    -   Деление.";
const string SymbolError = "Ошибка: некорректный ввод операции, выберите из списка.";
const string EnterNum1 = "Введите первое число (Если число не целое, то дробную часть нужно указать через запятую).";
const string EnterNum2 = "Введите второе число (Если число не целое, то дробную часть нужно указать через запятую).";
const string DoubleError = "Введены недопустимые значения, ожидались значения типа Double";
const string OperationAgain = "Введите R чтобы попробовать снова."; 
const string OperationNext = "Введите R для ещё одного вычисления.";
string[] Operations = { "+", "-", "*", "/" };

Restart: //
Console.WriteLine(Annotation);
string? Symbol = Console.ReadLine();
if (!Operations.Contains(Symbol))
{
    Console.WriteLine(SymbolError);
    Console.WriteLine(OperationAgain);
    if (Console.ReadLine() == "R")
    {
        Console.Clear();
        goto Restart;
    }
    else
    {
        System.Environment.Exit(1);
    }
};

Console.WriteLine(EnterNum1);
string? Num1 = Console.ReadLine();

Console.WriteLine(EnterNum2);
string? Num2 = Console.ReadLine();

Regex regex = new Regex(@"^(-{0,1}\d{1,}\,{0,1}\d*)$");
if (!regex.IsMatch(Num1) || !regex.IsMatch(Num2))
{
    Console.WriteLine(DoubleError);
    Console.WriteLine(OperationAgain);
    if (Console.ReadLine() == "R")
    {
        Console.Clear();
        goto Restart;
    }
    else
    {
        System.Environment.Exit(1);
    }
}

double Double2 = double.Parse(Num2);
double Double1 = double.Parse(Num1);

double result = 0;
if (Symbol == "+")
{
    result = Double1 + Double2;
}

if (Symbol == "-")
{
    result = Double1 - Double2;
}

if (Symbol == "*")
{
    result = Double1 * Double2;
}

if (Symbol == "/")
{
    result = Double1 / Double2;
}


Console.WriteLine("Результат: " + Double1 + Symbol + Double2 + "=" + result);
Console.WriteLine(OperationNext);
if (Console.ReadLine() == "R")
{
    Console.Clear();
    goto Restart;
}
