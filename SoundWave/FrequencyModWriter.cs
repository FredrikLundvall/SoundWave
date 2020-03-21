using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class FrequencyModWriter
    {
        protected readonly FrequencyMod fFrequencyMod;
        protected readonly SoundWriter fSoundWriter;

        public FrequencyModWriter(FrequencyMod aFrequencyMod, SoundTime aSampleStepDuration)
        {
            fFrequencyMod = aFrequencyMod;
            fSoundWriter = new SoundWriter(Track.NullTrack, fFrequencyMod.Sound, aSampleStepDuration);
        }
        public SamplePhase GetPhaseChange(SamplePhase aCurrentSamplePhase, SoundTime aSampleStepPosition, SamplePhase aParentPhaseChange)
        {
            SampleValue sampleValue = fSoundWriter.GetSampleValueForOneStep(aSampleStepPosition, aParentPhaseChange);
            return new SamplePhase(aCurrentSamplePhase.PhaseAsRadians + fFrequencyMod.MaxPhase.PhaseAsRadians * sampleValue.GetValueAsDouble());
        }
    }
}