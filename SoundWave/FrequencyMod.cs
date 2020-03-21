using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class FrequencyMod
    {
        public readonly Sound Sound;
        public readonly SamplePhase MaxPhase;

        public FrequencyMod(Sound aSoundFm, SamplePhase aMaxPhaseFm)
        {
            Sound = aSoundFm;
            MaxPhase = aMaxPhaseFm;
        }
    }
}

