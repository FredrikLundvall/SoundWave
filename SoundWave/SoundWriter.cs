using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class SoundWriter
    {
        protected readonly Sound fSound;
        protected readonly AmplitudeModWriter fAmplitudeModWriter;
        protected readonly FrequencyModWriter fFrequencyModWriter;
        protected readonly SoundTime fSampleStepDuration;
        protected SamplePhase fCurrentPhase;
        protected readonly Track fTrack;
        protected readonly IWaveWriter fWaveTypeWriter;
        //public SamplePhase ParentCurrentPhaseChange { get; private set; }

        public SoundWriter(Track aTrack, Sound aSound, SoundTime aSampleStepDuration)
        {
            fTrack = aTrack;
            fSound = aSound;
            fSampleStepDuration = aSampleStepDuration;
            fCurrentPhase = new SamplePhase(0);
            if (fSound.AmplitudeMod != null)
            {
                fAmplitudeModWriter = new AmplitudeModWriter(fSound.AmplitudeMod, fSampleStepDuration);
            }
            if (fSound.FrequencyMod != null)
            {
                fFrequencyModWriter = new FrequencyModWriter(fSound.FrequencyMod, fSampleStepDuration);
            }
            fWaveTypeWriter = fSound.WaveType.GetWaveWriter();
        }
        public SampleValue GetSampleValueForOneStep(SoundTime aSampleStepPosition, SamplePhase aParentPhaseChange)
        {
            //ParentCurrentPhaseChange = aParentPhaseChange;
            SampleValue sampleValueFromSound = new SampleValue(0.0);
            SoundTime positionInTrack = fSound.Position.StepForward(fTrack.Position);
            if (aSampleStepPosition >= positionInTrack & aSampleStepPosition <= positionInTrack.StepForward(fSound.Duration))
            {
                sampleValueFromSound = fWaveTypeWriter.GetSampleValue(fCurrentPhase);
                sampleValueFromSound = GetAmplitudeChangeFromModulation(sampleValueFromSound, aSampleStepPosition, aParentPhaseChange);
                sampleValueFromSound = fSound.SoundEffect.GetEffectChange( 
                    new SampleValue(sampleValueFromSound.GetValueAsDouble() * fSound.Amplitude.GetValueAsDouble()),
                    fCurrentPhase,
                    aSampleStepPosition,
                    positionInTrack,
                    fSound.Duration
                    );
                SamplePhase phaseChangeFromSound = SamplePhase.CreatePhaseChange(fSampleStepDuration, fSound.Pitch);
                fCurrentPhase = fCurrentPhase.AddPhaseTogether(phaseChangeFromSound);
                fCurrentPhase = GetPhaseChangeFromModulation(fCurrentPhase, aSampleStepPosition, aParentPhaseChange);
            }
            return sampleValueFromSound;
        }
        private SampleValue GetAmplitudeChangeFromModulation(SampleValue aCurrentSampleValue, SoundTime aSampleStepPosition, SamplePhase aParentPhaseChange)
        {
            SampleValue changedSampleValue = aCurrentSampleValue;
            if(fAmplitudeModWriter != null)
            {
                changedSampleValue = fAmplitudeModWriter.GetAmplitudeChange(changedSampleValue, aSampleStepPosition.RelativToStartPosition(fSound.Position), aParentPhaseChange);
            }
            return new SampleValue(changedSampleValue.GetValueAsDouble() * fSound.Amplitude.GetValueAsDouble());
        }
        private SamplePhase GetPhaseChangeFromModulation(SamplePhase aCurrentSamplePhase, SoundTime aSampleStepPosition, SamplePhase aParentPhaseChange)
        {
            SamplePhase changedSamplePhase = aCurrentSamplePhase;
            if (fFrequencyModWriter != null)
            {
                changedSamplePhase = fFrequencyModWriter.GetPhaseChange(changedSamplePhase, aSampleStepPosition.RelativToStartPosition(fSound.Position), aParentPhaseChange);
            }
            return changedSamplePhase;
        }
    }
}
