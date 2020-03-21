using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class SawtoothWave : IWave, IWaveWriter
    {
        public static IWave WaveSingleton = new SawtoothWave();
        public IWaveWriter GetWaveWriter()
        {
            return this;
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            double phase = (atPhase.PhaseAsRadians + Math.PI) % SamplePhase.PI2;
            return new SampleValue( (phase - Math.PI) / Math.PI);
        }
    }
}
