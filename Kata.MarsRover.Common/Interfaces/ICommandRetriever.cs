using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Common.Interfaces
{
    public interface ICommandRetriever
    {
        IEnumerable<CommandMR> GetList();
    }
}