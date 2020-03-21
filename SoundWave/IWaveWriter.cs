using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public interface IWaveWriter
    {
        SampleValue GetSampleValue(SamplePhase atPhase);
    }
}
