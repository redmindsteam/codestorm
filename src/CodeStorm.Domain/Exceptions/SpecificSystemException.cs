namespace CodeStorm.Domain.Exceptions
{
    public class SpecificSystemException : Exception
    {
        public string Point { get; }

        public SpecificSystemException(string point, string message, Exception exception)
            : base(message, exception)
        {
            Point = point;
        }
    }
}
