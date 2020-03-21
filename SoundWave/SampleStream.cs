using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoundWave
{
    public class SampleStream : MemoryStream
    {
        readonly SoundPitch fSampleRateHz;
        readonly int fSampleBits = 16;
        readonly int fSampleChannels = 1;
        Dictionary<int, List<Track>> fTrackList;
        public SampleStream(SoundTime durationSeconds, SoundPitch sampleRateHz, int sampleBits = 16, int sampleChannels = 1) : base(new byte[(int) Math.Ceiling(durationSeconds.TimeAsSeconds) * sampleRateHz.PitchAsIntHz * (sampleBits / 8) * sampleChannels], true)
        {
            fSampleRateHz = sampleRateHz;
            fSampleBits = sampleBits;
            fSampleChannels = sampleChannels;
            fTrackList = new Dictionary<int, List<Track>>(2);
            for (int channel = 1; channel <= fSampleChannels; channel++)
            {
                fTrackList[channel] = new List<Track>();
            }
        }
        //Before start writing, collect TrackWriters for every sound (initiate the length of one step, reset envelopes, pitches etc.)
        protected List<TrackWriter> GetTrackWriterList(int aChannel, SoundTime aSampleStepDuration)
        {
            List<TrackWriter> trackWriterList = new List<TrackWriter>();
            foreach (var track in fTrackList[aChannel])
            {
                trackWriterList.Add(track.GetTrackWriter(aSampleStepDuration));
            }
            return trackWriterList;
        }
        public void WriteAll()
        {
            this.Position = 0;
            SoundTime sampleStepDuration = GetTimeForOneSample();
            int numberOfSamples = (int)this.Length / ((fSampleBits / 8) * fSampleChannels);
            for (int channel = 1; channel <= fSampleChannels; channel++)
            {
                List<TrackWriter> trackWriterList = GetTrackWriterList(channel, sampleStepDuration);
                SoundTime sampleStepPosition = new SoundTime(0);
                Dictionary<long, SampleValue> bufferList = new Dictionary<long, SampleValue>(numberOfSamples);
                double highestValue = 1.0;
                for (long i = 0; i < numberOfSamples; i++)
                {
                    SampleValue sampleValue = new SampleValue(0);
                    foreach (var trackWriter in trackWriterList)
                    {
                        sampleValue.AddTogether(trackWriter.GetSampleValueForOneStep(sampleStepPosition));
                    }
                    bufferList[i] = sampleValue;
                    highestValue = Math.Max(highestValue, Math.Abs(sampleValue.GetValueAsDouble()));
                    sampleStepPosition = sampleStepPosition.StepForward(sampleStepDuration);
                }
                for (long i = 0; i < numberOfSamples; i++)
                {
                    this.Position = i * (fSampleBits / 8) * fSampleChannels + (channel - 1) * (fSampleBits / 8);
                    this.Write(bufferList[i], 1 / highestValue);
                }
            }
            this.Position = 0;
        }
        public void Write(SampleValue aSample, double volumeAdjust)
        {
            Write(aSample.ConvertToBytes(fSampleBits, volumeAdjust), 0, fSampleBits / 8);
        }
        public SoundTime GetTimeForOneSample()
        {
            return new SoundTime(fSampleRateHz.PitchAsWaveLengthSeconds);
        }     
        public void AddTrackForChannel(int aChannel, Track aSoundList, double aVolume)
        {
            if (aChannel < 1 || aChannel > fSampleChannels)
                throw new ArgumentOutOfRangeException("aChannel");
            fTrackList[aChannel].Add(aSoundList);
        }
    }
}
