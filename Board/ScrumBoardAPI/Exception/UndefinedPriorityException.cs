﻿namespace ScrumBoardAPI.Exception;

public class UndefinedPriorityException : System.Exception
{
    public UndefinedPriorityException() : base("Неопределенный приоритет")
    {
    }
}
