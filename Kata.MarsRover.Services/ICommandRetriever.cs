using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Services
{
    public interface ICommandRetriever
    {
        IEnumerable<CommandMR> GetList();
    }
}