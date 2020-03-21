using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class Sound : BaseSound
    {
        public readonly IWave WaveType;
        public readonly SoundPitch Pitch;
        public readonly SoundTime Duration;

        public Sound(SoundTime aPosition, SoundTime aDuration, SampleValue aAmplitude, SoundPitch aPitch, IWave aWaveType) : base(aPosition, aAmplitude)
        {
            Pitch = aPitch;
            Duration = aDuration;
            WaveType = aWaveType;
        }
    }
}
