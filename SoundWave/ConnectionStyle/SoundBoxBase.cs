using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public abstract class SoundBoxBase
    {
        abstract public double OutputValue(double aMomentInSeconds);
        public IOutputable GetValueOutputable()
        {
            return new SoundBoxBaseOutputValue(this);
        }
    }
}
