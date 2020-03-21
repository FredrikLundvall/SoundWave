using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class SineWave : IWave, IWaveWriter
    {
        public static IWave WaveSingleton = new SineWave();
        public IWaveWriter GetWaveWriter()
        {
            return this;
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            return new SampleValue( Math.Sin(atPhase.PhaseAsRadians));
        }
    }
}
