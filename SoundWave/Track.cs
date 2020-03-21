using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class Track : BaseSound
    {
        //public readonly SamplePhase SamplePhaseChange;
        protected readonly List<Sound> fSoundList = new List<Sound>();
        public SoundTime LastPosition { get; private set; }

        public Track(SoundTime aPosition, SampleValue aAmplitude) : base(aPosition, aAmplitude)
        {
            //SamplePhaseChange = aSamplePhaseChange;
            LastPosition = Position;
        }
        public void AddSound(Sound aSound)
        {
            SoundTime endSoundPosition = Position.StepForward(aSound.Position.StepForward(aSound.Duration));
            if(LastPosition < endSoundPosition)
                LastPosition = endSoundPosition;
            fSoundList.Add(aSound);
        }
        public TrackWriter GetTrackWriter(SoundTime aSampleStepDuration)
        {
            TrackWriter trackWriter = new TrackWriter(this, aSampleStepDuration);
            foreach (Sound sound in fSoundList)
            {
                trackWriter.AddSoundWriter(new SoundWriter(this, sound, aSampleStepDuration));
            }
            return trackWriter;
        }
        public static Track NullTrack = new Track(new SoundTime(0), new SampleValue(1));
    }
}
