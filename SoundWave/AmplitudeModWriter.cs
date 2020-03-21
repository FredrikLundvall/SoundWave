using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class AmplitudeModWriter
    {
        protected readonly AmplitudeMod fAmplitudeMod;
        protected readonly SoundWriter fSoundWriter;

        public AmplitudeModWriter(AmplitudeMod aAmplitudeMod, SoundTime aSampleStepDuration)
        {
            fAmplitudeMod = aAmplitudeMod;
            fSoundWriter = new SoundWriter(Track.NullTrack, fAmplitudeMod.Sound, aSampleStepDuration);
        }
        public SampleValue GetAmplitudeChange(SampleValue aSampleValue, SoundTime aSampleStepPosition, SamplePhase aParentPhaseChange)
        {
            SampleValue amplitudeChanged = aSampleValue;
            double minAmplitudeDouble = Math.Abs(fAmplitudeMod.MinAmplitude.GetValueAsDouble());
            SampleValue sampleValueMod = fSoundWriter.GetSampleValueForOneStep(aSampleStepPosition, aParentPhaseChange);
            double ampMultiplier = Math.Abs(sampleValueMod.GetValueAsDouble()) * (1 - minAmplitudeDouble) + minAmplitudeDouble;
            amplitudeChanged = new SampleValue(aSampleValue.GetValueAsDouble() * ampMultiplier);
            return amplitudeChanged;
        }

    }
}
