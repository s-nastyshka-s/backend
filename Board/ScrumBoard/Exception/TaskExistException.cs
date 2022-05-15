namespace ScrumBoard.Exception
{
    public class ColumnExistException : System.Exception
    {
        public ColumnExistException() : base("Колонка существует")
        {
        }
    }
}
