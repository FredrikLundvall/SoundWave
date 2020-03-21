using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public struct SoundPitch
    {
        public readonly double PitchAsHz;
        public SoundPitch(double aPitch)
        {
            PitchAsHz = aPitch;
        }
        public double PitchAsWaveLengthSeconds => 1 / PitchAsHz;
        public int PitchAsIntHz => (int)PitchAsHz;

        public override bool Equals(object obj)
        {
            if (!(obj is SoundPitch))
                return false;

            return ((SoundPitch)obj).PitchAsHz == this.PitchAsHz;
        }
        public override int GetHashCode()
        {
            return this.PitchAsHz.GetHashCode();
        }
    }
}
