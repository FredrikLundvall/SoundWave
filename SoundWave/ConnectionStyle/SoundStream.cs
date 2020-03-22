﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SoundWave.ConnectionStyle
{
    public class SoundStream : MemoryStream
    {
        protected readonly int fSampleRateHz;
        protected readonly int fSampleBits = 16;
        protected readonly int fSampleChannels = 1;
        protected readonly Dictionary<int, List<IOutputable>> fValueOutputListeners;
        public SoundStream(double aDurationSeconds, int aSampleRateHz, int aSampleBits = 16, int aSampleChannels = 1) : base(new byte[(int)Math.Ceiling(aDurationSeconds * aSampleRateHz) * (aSampleBits / 8) * aSampleChannels], true)
        {
            fSampleRateHz = aSampleRateHz;
            fSampleBits = aSampleBits;
            fSampleChannels = aSampleChannels;
            fValueOutputListeners = new Dictionary<int, List<IOutputable>>(fSampleChannels);
            for (int channel = 1; channel <= fSampleChannels; channel++)
            {
                fValueOutputListeners[channel] = new List<IOutputable>();
            }
        }
        public void WriteAll()
        {
            this.Position = 0;
            double sampleStepDuration = GetTimeForOneSample();
            int numberOfSamples = (int)this.Length / ((fSampleBits / 8) * fSampleChannels);
            for (int channel = 1; channel <= fSampleChannels; channel++)
            {
                double momentInSeconds = 0;
                for (long i = 0; i < numberOfSamples; i++)
                {
                    double value = 0;
                    foreach (var valueOutput in fValueOutputListeners[channel])
                    {
                        value += valueOutput.Output(momentInSeconds);
                    }
                    this.Write(value);
                    momentInSeconds += sampleStepDuration;
                }
            }
        }
        public void Write(double aValue)
        {
            Write(ConvertToBytes(aValue), 0, fSampleBits / 8);
        }
        public byte[] ConvertToBytes(double aValue)
        {
            double limitedValue = Math.Min(Math.Max(aValue, -1.0), 1.0);
            byte[] bytes;
            if (fSampleBits == 8)
            {
                bytes = new byte[1];
                byte intValue = (limitedValue >= 0) ? (byte)(127 + limitedValue * 128) : (byte)(128 + (limitedValue * 127));
                bytes[0] = intValue;
            }
            else if (fSampleBits == 16)
            {
                Int16 intValue = (limitedValue >= 0) ? (Int16)(limitedValue * Int16.MaxValue) : (Int16)(-limitedValue * Int16.MinValue);
                bytes = BitConverter.GetBytes(intValue);
            }
            else if (fSampleBits == 32)
            {
                Int32 intValue = (limitedValue >= 0) ? (Int32)(limitedValue * Int32.MaxValue) : (Int32)(-limitedValue * Int32.MinValue);
                bytes = BitConverter.GetBytes(intValue);
            }
            else if (fSampleBits == 64)
            {
                Int64 intValue = (limitedValue >= 0) ? (Int64)(limitedValue * Int64.MaxValue) : (Int64)(-limitedValue * Int64.MinValue);
                bytes = BitConverter.GetBytes(intValue);
            }
            else
                throw new ArgumentOutOfRangeException("Bits have to be 8, 16, 32, 64");
            return bytes;
        }
        public double GetTimeForOneSample()
        {
            return 1.0 / fSampleRateHz;
        }
        public void AddValueOutputableForChannel(int aChannel, IOutputable aValueOuputable)
        {
            if (aChannel < 1 || aChannel > fSampleChannels)
                throw new ArgumentOutOfRangeException("aChannel");
            fValueOutputListeners[aChannel].Add(aValueOuputable);
        }
    }
}