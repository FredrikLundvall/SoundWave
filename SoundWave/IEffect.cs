using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public interface IEffect
    {
        SampleValue GetEffectChange(SampleValue aCurrentSampleValue, SamplePhase CurrentPhase, SoundTime aSampleStepPosition, SoundTime aCurrentPosition, SoundTime aDuration);
    }
}
