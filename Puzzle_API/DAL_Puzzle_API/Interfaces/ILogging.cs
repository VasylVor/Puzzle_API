namespace DAL_Puzzle_API.Interfaces
{
    public interface ILogging
    {
        public void SaveError(string methodName, string message, string stackTrace, string innerException, string requestValue = null);
    }
}
