using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class BaseSound
    {
        public readonly SoundTime Position;
        public readonly SampleValue Amplitude;
        public AmplitudeMod AmplitudeMod { get; private set; }
        public FrequencyMod FrequencyMod { get; private set; }
        public IEffect SoundEffect { get; private set; }

        public BaseSound(SoundTime aPosition, SampleValue aAmplitude)
        {
            Position = aPosition;
            Amplitude = aAmplitude;
            AmplitudeMod = null;
            FrequencyMod = null;
            SoundEffect = NullEffect.EffectSingleton;
        }
        public void ConnectFrequencyModulation(FrequencyMod aFrequencyModulation)
        {
            FrequencyMod = aFrequencyModulation;
        }
        public void ConnectAmplitudeModulation(AmplitudeMod aAmplitudeModulation)
        {
            AmplitudeMod = aAmplitudeModulation;
        }
        public void ConnectSoundEffect(IEffect aSoundEffect)
        {
            SoundEffect = aSoundEffect;
        }
    }
}
