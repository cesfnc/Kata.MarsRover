namespace Kata.MarsRover.Common.Exceptions
{
    public abstract class ApplicationBaseException : Exception
    {
        public new object? Data { get; set; }

        protected ApplicationBaseException(string message) : base(message)
        {
        }

        protected ApplicationBaseException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
