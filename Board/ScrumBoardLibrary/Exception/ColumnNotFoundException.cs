﻿namespace ScrumBoard.Exception;

public class ColumnNotFoundException : System.Exception
{
    public ColumnNotFoundException() : base("Колонка не найдена")
    {
    }
}
