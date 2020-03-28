using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public interface IOutputable
    {
        Output CalcOutput(decimal aMomentInSeconds);
        IOutputable SignalOutput();
    }
}
