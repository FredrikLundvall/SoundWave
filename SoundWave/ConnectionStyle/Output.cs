using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class Output
    {
        public readonly double Amplitude;
        public readonly double? Frequency;
        public readonly double? Phase;
        public Output(double aAmplitude, double? aPhase)
        {
            Amplitude = aAmplitude;
            Phase = aPhase;
        }

        public static double? SumPhase(double? aLeft, double? aRight)
        {
            if (aLeft == null && aRight == null)
                return null;
            if (aLeft != null)
                return aLeft;
            if (aRight != null)
                return aRight;
            double aLeftd = (double)aLeft;
            double aRightd = (double)aRight;
            double diffMid = Math.Max(aLeftd, aRightd) - Math.Min(aLeftd, aRightd);
            double diffOverlap = 1 - Math.Max(aLeftd, aRightd) + Math.Min(aLeftd, aRightd);
            double newPhase;
            if (diffMid < diffOverlap)
                newPhase = Math.Min(aLeftd, aRightd) + diffMid / 2;
            else
                newPhase = Math.Max(aLeftd, aRightd) + diffOverlap / 2;
            return newPhase % 1.0;
        }

        public static double SumAmplitude(double aLeft, double aRight)
        {
            return aLeft + aRight;
        }

        public static double SumFrequncy(double aLeft, double aRight)
        {
            return (aLeft + aRight)  / 2.0;
        }

        public static Output operator +(Output aLeft, Output aRight)
        {
            return new Output(SumAmplitude(aLeft.Amplitude, aRight.Amplitude), SumPhase(aLeft.Phase, aRight.Phase));
        }

        public static Output operator *(Output aLeft, double aRight)
        {
            return new Output(aLeft.Amplitude * aRight, aLeft.Phase);
        }

    }
}
