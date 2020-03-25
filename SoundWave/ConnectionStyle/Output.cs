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
        public Output(double aAmplitude, double? aPhase, double? aFrequency)
        {
            Amplitude = aAmplitude;
            Phase = aPhase;
            Frequency = aFrequency;
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

        public static double? SumFrequency(double? aLeft, double? aRight)
        {
            if (aLeft == null && aRight == null)
                return null;
            if (aLeft != null)
                return aLeft;
            if (aRight != null)
                return aRight;
            return ((aLeft ?? 0) + (aRight ?? 0))  / 2.0;
        }

        public static Output operator +(Output aLeft, Output aRight)
        {
            return new Output(SumAmplitude(aLeft.Amplitude, aRight.Amplitude), SumPhase(aLeft.Phase, aRight.Phase), SumFrequency(aLeft.Frequency, aRight.Frequency));
        }

        public static Output MultiplyAmplitude(Output aOutput, double aAmplitude)
        {
            return new Output(aOutput.Amplitude * aAmplitude, aOutput.Phase, aOutput.Frequency);
        }

    }
}
