using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class TrackWriter
    {
        protected readonly List<SoundWriter> fSoundWriterList = new List<SoundWriter>();
        protected readonly SoundTime fSampleStepDuration;
        protected SamplePhase fCurrentPhase;
        protected readonly Track fTrack;
        protected readonly AmplitudeModWriter fTrackAmplitudeModWriter;
        protected readonly FrequencyModWriter fTrackFrequencyModWriter;
        protected readonly SamplePhase EmptySamplePhase = new SamplePhase(0);
        
        public TrackWriter(Track aTrack, SoundTime aSampleStepDuration)
        {
            fTrack = aTrack;
            fSampleStepDuration = aSampleStepDuration;
            fCurrentPhase = new SamplePhase(0);
            if (fTrack.AmplitudeMod != null)
            {
                fTrackAmplitudeModWriter = new AmplitudeModWriter(fTrack.AmplitudeMod, fSampleStepDuration);
            }
            if (fTrack.FrequencyMod != null)
            {
                fTrackFrequencyModWriter = new FrequencyModWriter(fTrack.FrequencyMod, fSampleStepDuration);
            }
        }
        public void AddSoundWriter(SoundWriter aSoundWriter)
        {
            fSoundWriterList.Add(aSoundWriter);
        }
        public SampleValue GetSampleValueForOneStep(SoundTime aSampleStepPosition)
        {
            SampleValue sampleValue = new SampleValue(0.0);
            foreach (var soundWriter in fSoundWriterList)
            {
                sampleValue.AddTogether(soundWriter.GetSampleValueForOneStep(aSampleStepPosition, fCurrentPhase));
            }
            sampleValue = GetAmplitudeChangeFromModulation(sampleValue, aSampleStepPosition, fCurrentPhase);
            sampleValue = fTrack.SoundEffect.GetEffectChange(
                sampleValue,
                fCurrentPhase,
                aSampleStepPosition,
                fTrack.Position,
                fTrack.Position.DurationFromEndPosition(fTrack.LastPosition)
            );
            fCurrentPhase = GetPhaseChangeFromModulation(fCurrentPhase, aSampleStepPosition);
            return sampleValue;
        }
        private SampleValue GetAmplitudeChangeFromModulation(SampleValue aCurrentSampleValue, SoundTime aSampleStepPosition, SamplePhase aParentPhaseChange)
        {
            SampleValue changedSampleValue = aCurrentSampleValue;
            if (fTrackAmplitudeModWriter != null)
            {
                changedSampleValue = fTrackAmplitudeModWriter.GetAmplitudeChange(changedSampleValue, aSampleStepPosition.RelativToStartPosition(fTrack.Position), aParentPhaseChange);
            }
            return new SampleValue(changedSampleValue.GetValueAsDouble() * fTrack.Amplitude.GetValueAsDouble());
        }
        private SamplePhase GetPhaseChangeFromModulation(SamplePhase aCurrentSamplePhase, SoundTime aSampleStepPosition)
        {
            SamplePhase changedSamplePhase = aCurrentSamplePhase;
            if (fTrackFrequencyModWriter != null)
            {
                changedSamplePhase = fTrackFrequencyModWriter.GetPhaseChange(changedSamplePhase, aSampleStepPosition.RelativToStartPosition(fTrack.Position), EmptySamplePhase);
            }
            return changedSamplePhase;
        }
    }
}
