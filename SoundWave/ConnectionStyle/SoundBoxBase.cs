using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public abstract class SoundBoxBase : IOutputable
    {
        abstract public Output Output(double aMomentInSeconds);
        public IOutputable GetValueOutSignal()
        {
            return this;
        }
    }
}
