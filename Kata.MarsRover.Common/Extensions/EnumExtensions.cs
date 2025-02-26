namespace Kata.MarsRover.Common.Extensions
{
    public static class EnumExtensions
    {
        public static T? StringToEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
