using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;
using Kata.MarsRover.Common.Extensions;
using System.Reflection;

namespace Kata.MarsRover.Services
{
    public class CommandRetriever : ICommandRetriever
    {
        public IEnumerable<CommandMR> GetList()
        {
            var cmds = new List<CommandMR>();

            var location = Assembly.GetExecutingAssembly().Location;
            var lineCommands = File.ReadAllLines(Path.Combine(location, "path.txt"));
            foreach (var item in lineCommands)
            {
                if(item is null)
                    continue;

                var m = EnumExtensions.StringToEnum<Movement>(item[0]!.ToString());
                var r = EnumExtensions.StringToEnum<Rotation>(item[1]!.ToString());
                cmds.Add(new CommandMR(m, r));
            }
            return cmds;
        }
    }
}
