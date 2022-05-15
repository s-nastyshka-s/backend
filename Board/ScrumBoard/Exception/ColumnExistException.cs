namespace ScrumBoard.Exception
{
    public class TaskExistException : System.Exception
    {
        public TaskExistException() : base("Задача существует")
        {
        }
    }
}
