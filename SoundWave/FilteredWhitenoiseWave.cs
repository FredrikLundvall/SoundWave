using System;
using System.Collections.Generic;

namespace SoundWave
{
    public class FilteredWhitenoiseWave : IWave, IWaveWriter
    {
        private static readonly Random Rand1 = new Random(0);
        private static readonly Random Rand2 = new Random(1000);
        protected readonly List<SampleValue> fCachedValues = new List<SampleValue>(50);
        protected readonly List<double> fMultiplierValues = new List<double>(50);
        protected readonly double fAlpha;
        protected readonly int fNumberOfValues;
        public FilteredWhitenoiseWave(double aAlpha = 1, int aNumberOfValues = 5)
        {
            if (aAlpha < 0 || aAlpha > 2)
            {
                throw new ArgumentOutOfRangeException("Invalid pink noise alpha = " + aAlpha);
            }
            if (aNumberOfValues < 1 || aNumberOfValues > 1000)
            {
                throw new ArgumentOutOfRangeException("Invalid pink noise number of values = " + aNumberOfValues);
            }
            fAlpha = aAlpha;
            fNumberOfValues = aNumberOfValues;
            double a = 1;
            for (int i = 0; i < fNumberOfValues; i++)
            {
                a = (i - aAlpha / 2) * a / (i + 1);
                fMultiplierValues.Add(a);
                fCachedValues.Add(GetRandomValue());
            }
        }
        public IWaveWriter GetWaveWriter()
        {
            return new FilteredWhitenoiseWave(fAlpha, fNumberOfValues);
        }
        public SampleValue GetSampleValue(SamplePhase atPhase)
        {
            double nextValue = GetRandomValue().GetValueAsDouble();
            for (int i = 0; i < fNumberOfValues; i++)
            {
                nextValue -= fMultiplierValues[i] * fCachedValues[fNumberOfValues - i - 1].GetValueAsDouble();
            }            
            fCachedValues.RemoveAt(0);
            fCachedValues.Add(new SampleValue(nextValue));
            return fCachedValues[fNumberOfValues - 1];
        }
        static SampleValue GetRandomValue()
        {
            return new SampleValue(Rand1.NextDouble() + Rand2.NextDouble() - 1);
        }
    }
}
