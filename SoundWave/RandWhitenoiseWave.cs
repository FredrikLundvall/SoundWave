using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class RandWhitenoiseWave : IWave, IWaveWriter
    {
        private static readonly Random Rand1 = new Random(0);
        private static readonly Random Rand2 = new Random(1000);
        public static IWave WaveSingleton = new RandWhitenoiseWave();
        public IWaveWriter GetWaveWriter()
        {
            return this;
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            //var rand = new Random((int)Math.Floor(((atPhase.PhaseAsRadians % SamplePhase.PI2) / SamplePhase.PI2) * int.MaxValue));
            return new SampleValue(Rand1.NextDouble() + Rand2.NextDouble() - 1);
        }
    }
}
