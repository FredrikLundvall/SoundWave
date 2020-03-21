using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class EchoEffect : IEffect
    {
        private static readonly List<SampleValue> fCachedValues = new List<SampleValue>(6400);
        protected readonly double fStrength;
        protected readonly int fNumberOfValues;
        public EchoEffect(double aStrength = 1, int aNumberOfValues = 5000)
        {
            fStrength = aStrength;
            fNumberOfValues = aNumberOfValues;
            for (int i = 0; i < fNumberOfValues; i++)
            {
                fCachedValues.Add(new SampleValue(0));
            }
        }
        public SampleValue GetEffectChange(SampleValue aCurrentSampleValue, SamplePhase CurrentPhase, SoundTime aSampleStepPosition, SoundTime aCurrentPosition, SoundTime aDuration)
        {
            SampleValue mixedValue = new SampleValue(fCachedValues[0].GetValueAsDouble() * fStrength + aCurrentSampleValue.GetValueAsDouble());
            fCachedValues.RemoveAt(0);
            fCachedValues.Add(mixedValue);
            return mixedValue;
        }
    }
}
