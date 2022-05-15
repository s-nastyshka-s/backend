namespace ScrumBoard.Exception
{
    public class ColumnsOverflowLimitException : System.Exception
    {
        public ColumnsOverflowLimitException() : base("Превышение лимита колонок")
        {
        }
    }
}
