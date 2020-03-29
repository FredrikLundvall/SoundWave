using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using raminrahimzada;

namespace SoundWave.ConnectionStyle
{
    public class Output : IEquatable<Output>
    {
        public readonly decimal? Value;
        public readonly decimal? Phase;
        public Output(decimal? aValue, decimal? aPhase)
        {
            Value = aValue;
            Phase = aPhase;
        }

        public static decimal? SumPhase(decimal? aLeft, decimal? aRight)
        {
            if (aLeft == null && aRight == null)
                return null;
            if (aLeft != null && aRight == null)
                return aLeft;
            if (aRight != null && aLeft == null)
                return aRight;
            decimal aLeftd = (decimal)aLeft;
            decimal aRightd = (decimal)aRight;
            decimal diffMid = Math.Max(aLeftd, aRightd) - Math.Min(aLeftd, aRightd);
            decimal diffOverlap = 1 - Math.Max(aLeftd, aRightd) + Math.Min(aLeftd, aRightd);
            decimal newPhase;
            if (diffMid < diffOverlap)
                newPhase = Math.Min(aLeftd, aRightd) + diffMid / 2;
            else
                newPhase = Math.Max(aLeftd, aRightd) + diffOverlap / 2;
            return newPhase % 1.0m;
        }

        public static decimal? SumAmplitude(decimal? aLeft, decimal? aRight)
        {
            if (aLeft == null && aRight == null)
                return null;
            else
                return (aLeft ?? 0) + (aRight ?? 0);
        }

        //public static decimal? SumFrequency(decimal? aLeft, decimal? aRight)
        //{
        //    if (aLeft == null && aRight == null)
        //        return null;
        //    if (aLeft != null)
        //        return aLeft;
        //    if (aRight != null)
        //        return aRight;
        //    return ((aLeft ?? 0) + (aRight ?? 0))  / 2.0;
        //}

        //public static decimal? ConvertToAmplifier(decimal? aValue)
        //{
        //    if (aValue == null)
        //        return null;
        //    if(aValue < 0)
        //        return aValue / 2.0;
        //    else
        //        return (1 + aValue) / 2.0;
        //}
        public static decimal? ConvertFrequencyToPhasePosition(decimal aMomentInSeconds, decimal? aFrequency)
        {
            if (aFrequency == null || aFrequency <= 0)
                return null;
            if (aFrequency <= 0)
                return 0m;
            //return nfmod(aMomentInSeconds / (1 / (aFrequency ?? 1)), 1.0m);
            return (aMomentInSeconds / (1/(aFrequency ?? 1))) % 1.0m;
        }
        public static decimal? ConvertFrequencyToPhaseChange(decimal? aFrequency)
        {
            if (aFrequency == null || aFrequency <= 0)
                return null;
            if (aFrequency <= 0)
                return 0m;
            return 1 / (aFrequency ?? 1);
        }
        //public static decimal? RecalcPhase(decimal? aValue, decimal? aPhase)
        //{
        //    if (aValue == null)
        //        return null;
        //    if (aPhase == null)
        //        return null;
        //    return aPhase + (aValue * aPhase);
        //}
        public static Output operator +(Output aLeft, Output aRight)
        {
            return new Output(SumAmplitude(aLeft.Value, aRight.Value), SumPhase(aLeft.Phase, aRight.Phase));
        }

        public static bool operator ==(Output output1, Output output2)
        {
            return output1.Equals(output2);
        }

        public static bool operator !=(Output output1, Output output2)
        {
            return !(output1 == output2);
        }

        public static Output MultiplyAmplitude(Output aOutput, decimal? aAmplitude)
        {
            return new Output(aOutput.Value * aAmplitude, aOutput.Phase);
        }

        static public decimal nfmod(decimal a, decimal b)
        {
            return a - b * Math.Floor(a / b);
        }

        public override string ToString()
        {
            return String.Format("Value: {0:f6}, Phase: {1:f6}", Value, Phase);
            ;
        }

        public override bool Equals(object obj)
        {
            return obj is Output && Equals((Output)obj);
        }

        public bool Equals(Output other)
        {
            return EqualityComparer<decimal?>.Default.Equals(Decimal.Round(Value ?? 0, 10), Decimal.Round(other.Value ?? 0, 0)) &&
                   EqualityComparer<decimal?>.Default.Equals(Decimal.Round(Phase ?? 0, 10), Decimal.Round(other.Phase ?? 0,10));
        }

        public override int GetHashCode()
        {
            var hashCode = 981352850;
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal?>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + EqualityComparer<decimal?>.Default.GetHashCode(Phase);
            return hashCode;
        }
    }
}
