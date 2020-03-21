using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class TriangleWave : IWave, IWaveWriter
    {
        public static IWave WaveSingleton = new TriangleWave();
        public IWaveWriter GetWaveWriter()
        {
            return this;
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            //double phase = atPhase.PhaseAsRadians % SamplePhase.PI2;
            //return new SampleValue( (phase - Math.PI) / Math.PI);
            return new SampleValue((2 / Math.PI) * Math.Asin(Math.Sin(atPhase.PhaseAsRadians)));
        }
    }
}
