using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoundWave
{
    public struct SampleValue
    {
        private Double fValue;

        public SampleValue(Double aValue)
        {
            fValue = aValue;
        }

        public Double GetValueAsDouble()
        {
            return fValue;
        }

        //public void MixTogether(SampleValue aSample, Double aAmount)
        //{
        //    fValue = (1 - aAmount) * fValue + aSample.GetValueAsDouble() * aAmount;
        //}

        public void AddTogether(SampleValue aSample)
        {
            fValue = fValue + aSample.GetValueAsDouble();
            //fValue = DampenValue(fValue) + DampenValue(aSample.GetValueAsDouble());
        }

        public double DampenValue(double aValue)
        {
            if (aValue > 0)
                return aValue - Math.Pow(Math.Abs(aValue), 2) * 0.1;
            else
                return aValue + Math.Pow(Math.Abs(aValue), 2) * 0.1;
        }

        public byte[] ConvertToBytes(int aBits, double aRecordingVolumeAdjust)
        {
            double limitedValue = Math.Min(Math.Max(fValue * aRecordingVolumeAdjust, -1.0), 1.0);
            byte[] bytes;
            if (aBits == 8)
            {
                bytes = new byte[1];
                byte intValue = (limitedValue >= 0) ? (byte)(127 + limitedValue * 128) : (byte)(128 + (limitedValue * 127));
                bytes[0] = intValue;
            }
            else if (aBits == 16)
            {
                Int16 intValue = (limitedValue >= 0) ? (Int16)(limitedValue * Int16.MaxValue) : (Int16)(-limitedValue * Int16.MinValue);
                bytes = BitConverter.GetBytes(intValue);
            }
            else if (aBits == 32)
            {
                Int32 intValue = (limitedValue >= 0) ? (Int32)(limitedValue * Int32.MaxValue) : (Int32)(-limitedValue * Int32.MinValue);
                bytes = BitConverter.GetBytes(intValue);
            }
            else if (aBits == 64)
            {
                Int64 intValue = (limitedValue >= 0) ? (Int64)(limitedValue * Int64.MaxValue) : (Int64)(-limitedValue * Int64.MinValue);
                bytes = BitConverter.GetBytes(intValue);
            }
            else
                throw new ArgumentOutOfRangeException("Bits have to be 8, 16, 32, 64");
            return bytes;
        }

        public override string ToString()
        {
            return fValue.ToString("F6");
        }
    }
}
