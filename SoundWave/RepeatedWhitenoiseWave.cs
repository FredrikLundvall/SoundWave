using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class RepeatedWhitenoiseWave : IWave, IWaveWriter
    {
        private static readonly Random Rand1 = new Random(0);
        private static readonly Random Rand2 = new Random(1000);
        private static readonly Double[] RandValue = new Double[64000];
        private readonly int fStartPos; //personalize
        static RepeatedWhitenoiseWave()
        {
            for(int i = 0; i < RandValue.Length; i++)
            {
                RandValue[i] = Rand1.NextDouble() + Rand2.NextDouble() - 1;
            }
        }
        public RepeatedWhitenoiseWave()
        {
            fStartPos = Rand1.Next();
        }
        public IWaveWriter GetWaveWriter()
        {
            return new RepeatedWhitenoiseWave();
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            var pos = (int)Math.Floor(((atPhase.PhaseAsRadians % SamplePhase.PI256) / SamplePhase.PI256) * RandValue.Length) + fStartPos;
            return new SampleValue(RandValue[pos % RandValue.Length]);
        }
    }
}
