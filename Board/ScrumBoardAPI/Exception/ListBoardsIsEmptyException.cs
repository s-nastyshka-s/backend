namespace ScrumBoardAPI.Exception;

public class ListBoardsIsEmptyException : System.Exception
{
    public ListBoardsIsEmptyException() : base("Список досок пуст")
    {
    }
}
