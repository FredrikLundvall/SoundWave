using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class Output : IEquatable<Output>
    {
        public readonly double? Value;
        public readonly double? PhaseChange;
        public Output(double? aValue, double? aPhaseChange)
        {
            Value = aValue;
            PhaseChange = aPhaseChange;
        }

        //public static double? SumPhase(double? aLeft, double? aRight)
        //{
        //    if (aLeft == null && aRight == null)
        //        return null;
        //    if (aLeft != null && aRight == null)
        //        return aLeft;
        //    if (aRight != null && aLeft == null)
        //        return aRight;
        //    double aLeftd = (double)aLeft;
        //    double aRightd = (double)aRight;
        //    double diffMid = Math.Max(aLeftd, aRightd) - Math.Min(aLeftd, aRightd);
        //    double diffOverlap = 1 - Math.Max(aLeftd, aRightd) + Math.Min(aLeftd, aRightd);
        //    double newPhase;
        //    if (diffMid < diffOverlap)
        //        newPhase = Math.Min(aLeftd, aRightd) + diffMid / 2;
        //    else
        //        newPhase = Math.Max(aLeftd, aRightd) + diffOverlap / 2;
        //    return newPhase % 1.0;
        //}
        public static double? SumPhaseChange(double? aLeft, double? aRight)
        {
            if (aLeft == null && aRight == null)
                return null;
            else
                return ((aLeft ?? 0) + (aRight ?? 0)) % 1.0;
        }

        public static double? SumAmplitude(double? aLeft, double? aRight)
        {
            if (aLeft == null && aRight == null)
                return null;
            else
                return (aLeft ?? 0) + (aRight ?? 0);
        }

        //public static double? SumFrequency(double? aLeft, double? aRight)
        //{
        //    if (aLeft == null && aRight == null)
        //        return null;
        //    if (aLeft != null)
        //        return aLeft;
        //    if (aRight != null)
        //        return aRight;
        //    return ((aLeft ?? 0) + (aRight ?? 0))  / 2.0;
        //}

        //public static double? ConvertToAmplifier(double? aValue)
        //{
        //    if (aValue == null)
        //        return null;
        //    if(aValue < 0)
        //        return aValue / 2.0;
        //    else
        //        return (1 + aValue) / 2.0;
        //}
        //public static double? ConvertFrequencyToPhasePosition(double aMomentInSeconds, double? aFrequency)
        //{
        //    if (aFrequency == null || aFrequency <= 0)
        //        return null;
        //    if (aFrequency <= 0)
        //        return 0;
        //    //return nfmod(aMomentInSeconds / (1 / (aFrequency ?? 1)), 1.0m);
        //    return (aMomentInSeconds / (1/(aFrequency ?? 1))) % 1.0;
        //}
        public static double ConvertFrequencyToPhaseChange(double aSampleStepDuration, double aFrequency)
        {
            if (aFrequency <= 0)
                return 0;
            return (aSampleStepDuration * aFrequency);// % 1.0;
        }
        //public static double? RecalcPhase(double? aValue, double? aPhase)
        //{
        //    if (aValue == null)
        //        return null;
        //    if (aPhase == null)
        //        return null;
        //    return aPhase + (aValue * aPhase);
        //}
        public static Output operator +(Output aLeft, Output aRight)
        {
            return new Output(SumAmplitude(aLeft.Value, aRight.Value), SumPhaseChange(aLeft.PhaseChange, aRight.PhaseChange));
        }

        public static bool operator ==(Output output1, Output output2)
        {
            return output1.Equals(output2);
        }

        public static bool operator !=(Output output1, Output output2)
        {
            return !(output1 == output2);
        }

        public static Output MultiplyAmplitude(Output aOutput, double? aAmplitude)
        {
            var returnValue = new Output((aOutput.Value ?? 1.0) * aAmplitude, aOutput.PhaseChange);
            return returnValue;
        }

        static public double nfmod(double a, double b)
        {
            return a - b * Math.Floor(a / b);
        }

        public override string ToString()
        {
            return String.Format("Value: {0:f6}, Phase: {1:f6}", Value, PhaseChange);
            ;
        }

        public override bool Equals(object obj)
        {
            return obj is Output && Equals((Output)obj);
        }

        public bool Equals(Output other)
        {
            return EqualityComparer<double?>.Default.Equals(Math.Round(Value ?? 0, 10), Math.Round(other.Value ?? 0, 0)) &&
                   EqualityComparer<double?>.Default.Equals(Math.Round(PhaseChange ?? 0, 10), Math.Round(other.PhaseChange ?? 0,10));
        }

        public override int GetHashCode()
        {
            var hashCode = 981352850;
            hashCode = hashCode * -1521134295 + EqualityComparer<double?>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + EqualityComparer<double?>.Default.GetHashCode(PhaseChange);
            return hashCode;
        }
    }
}
