using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class SoundMix
    {
        public readonly Sound Sound;
        public readonly SampleValue Amplitude;

        public SoundMix(Sound aSound, SampleValue aAmplitude)
        {
            Sound = aSound;
            Amplitude = aAmplitude;
        }
    }
}
