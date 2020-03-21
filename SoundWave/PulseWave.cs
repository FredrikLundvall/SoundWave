using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class PulseWave : IWave, IWaveWriter
    {
        public static IWave WaveSingleton = new PulseWave();
        public IWaveWriter GetWaveWriter()
        {
            return this;
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            double phase = atPhase.PhaseAsRadians % SamplePhase.PI2;
            return new SampleValue(phase < Math.PI ? 1 : -1);
        }
    }
}
