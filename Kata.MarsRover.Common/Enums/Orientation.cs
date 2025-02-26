using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.MarsRover.Common.Enums
{
    public enum Orientation
    {
        [Description("North")]
        N,
        [Description("South")]
        S,
        [Description("East")]
        E,
        [Description("West")]
        W
    }
}
