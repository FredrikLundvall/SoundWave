using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public struct SamplePosition
    {
        public readonly long SampleStreamPositon;
        public readonly int SampleRateHz;
        public SamplePosition(long aSampleStreamPositon, int aSampleRateHz)
        {
            SampleStreamPositon = aSampleStreamPositon;
            SampleRateHz = aSampleRateHz;
        }
    }
}
