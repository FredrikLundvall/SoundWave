using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class NullEffect : IEffect
    {
        public SampleValue GetEffectChange(SampleValue aCurrentSampleValue, SamplePhase CurrentPhase, SoundTime aSampleStepPosition, SoundTime aCurrentPosition, SoundTime aDuration)
        {
            return aCurrentSampleValue;
        }
        public static IEffect EffectSingleton = new NullEffect();
    }
}
