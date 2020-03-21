using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public struct SoundTime : IComparable<SoundTime>
    {
        public readonly double TimeAsSeconds;
        //public readonly Int64 PositionAsInt64;
        public SoundTime(double aTimeAsSeconds)
        {
            TimeAsSeconds = aTimeAsSeconds;
        }
        //public SoundTime(Int64 aPositionAsInt64)
        //{
        //    PositionAsInt64 = aPositionAsInt64;
        //}
        //public static SoundTime MinValue()
        //{
        //    return new SoundTime(Int64.MinValue);
        //}
        //public static SoundTime MaxValue()
        //{
        //    return new SoundTime(Int64.MaxValue);
        //}
        public SoundTime StepForward(SoundTime aStepDuration)
        {
            return new SoundTime(TimeAsSeconds + aStepDuration.TimeAsSeconds);
        }
        public SoundTime DurationFromEndPosition(SoundTime aEndPosition)
        {
            return new SoundTime(aEndPosition.TimeAsSeconds - TimeAsSeconds);
        }
        public SoundTime RelativToStartPosition(SoundTime aStartPosition)
        {
            return new SoundTime(TimeAsSeconds - aStartPosition.TimeAsSeconds);
        }
        public bool Equals(SoundTime other)
        {
            return Equals(other, this);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is SoundTime))
                return false;
            return ((SoundTime) obj).TimeAsSeconds == this.TimeAsSeconds;
        }
        public override int GetHashCode()
        {
            return this.TimeAsSeconds.GetHashCode();
        }
        private static int Compare(SoundTime s1, SoundTime s2)
        {
            if (s1.TimeAsSeconds == s2.TimeAsSeconds)
                return 0;
            else if (s1.TimeAsSeconds < s2.TimeAsSeconds)
                return -1;
            else
                return 1;
        }
        public int CompareTo(SoundTime other)
        {
            return Compare(this, other);
        }
        public static bool operator <(SoundTime s1, SoundTime s2)
        {
            return Compare(s1, s2) < 0;
        }
        public static bool operator <=(SoundTime s1, SoundTime s2)
        {
            return Compare(s1, s2) <= 0;
        }
        public static bool operator >(SoundTime s1, SoundTime s2)
        {
            return Compare(s1, s2) > 0;
        }
        public static bool operator >=(SoundTime s1, SoundTime s2)
        {
            return Compare(s1, s2) >= 0;
        }
        public static bool operator ==(SoundTime s1, SoundTime s2)
        {
            return s1.Equals(s2);
        }
        public static bool operator !=(SoundTime s1, SoundTime s2)
        {
            return !s1.Equals(s2);
        }
    }
}
