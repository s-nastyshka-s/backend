namespace ScrumBoardAPI.Exception;

public class BoardNotFoundException : System.Exception
{
    public BoardNotFoundException() : base("Доска не найдена")
    {
    }
}
