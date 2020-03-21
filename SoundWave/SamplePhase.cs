using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public struct SamplePhase
    {
        public const double PI256 = Math.PI * 256;
        public const double PI128 = Math.PI * 128;
        public const double PI64 = Math.PI * 64;
        public const double PI32 = Math.PI * 32;
        public const double PI16 = Math.PI * 16;
        public const double PI8 = Math.PI * 8;
        public const double PI4 = Math.PI * 4;
        public const double PI2 = Math.PI * 2;
        public const double PIDIV2 = Math.PI / 2;
        public readonly double PhaseAsRadians; //As radians

        public SamplePhase(double aPhase)
        {
            PhaseAsRadians = nfmod(aPhase, PI2);
        }
        static public Double nfmod(Double a, Double b)
        {
            return a - b * Math.Floor(a / b);
        }

        public SamplePhase AddPhaseTogether(SamplePhase phaseChange)
        {
            return new SamplePhase(PhaseAsRadians + phaseChange.PhaseAsRadians);
        }

        static public SamplePhase CreatePhaseChange(SoundTime sampleStepDuration, SoundPitch pitchFrequency)
        {
            return new SamplePhase(sampleStepDuration.TimeAsSeconds / pitchFrequency.PitchAsWaveLengthSeconds * PI2);
        }

        //static private double CalcPhaseChange(Int64 sampleTicks, Int64 frequencyHz)
        //{
        //    double sampleTicksForOnePhase = 10000000L / frequencyHz;
        //    return sampleTicks / sampleTicksForOnePhase;
        //}

        //public SamplePhase(Int64 phase)
        //{
        //    _phase = phase;
        //}

        //public SamplePhase(Double phase)
        //{
        //    if (phase > 1)
        //        phase = phase - (Int64)phase;
        //    _phase = (Int64)(phase * Int64.MaxValue);
        //}

        //public SamplePhase(TimeSpan atTime, Int32 frequencyMilliHz)
        //{
        //    _phase = CalcPhaseChange(atTime.Ticks, frequencyMilliHz);
        //}

        //public void IncPhase(SamplePhase phaseChange)
        //{
        //    _phase += phaseChange.GetPhaseAsTicks();
        //    if (_phase < 0)
        //        _phase -= Int64.MinValue;
        //}

        //public void DecPhase(SamplePhase phaseChange)
        //{
        //    _phase -= phaseChange.GetPhaseAsTicks();
        //    //if (_phase < 0)
        //    //    _phase -= Int64.MinValue;
        //}

        //public Int64 GetPhaseAsTicks()
        //{
        //    return _phase;
        //}

        //public Double GetPhaseAsRadians()
        //{
        //    return 2 * Math.PI * GetPhaseAsDouble();
        //}

        //public Double GetPhaseAsDouble()
        //{
        //    return (_phase / (Double)Int64.MaxValue);
        //}

        //static private Int64 CalcPhaseChange(Int64 sampleTicks, Int64 frequencyMilliHz)
        //{
        //    Int64 sampleTicksForOnePhase = 10000000000L / frequencyMilliHz;
        //    return (Int64)Math.Round(((sampleTicks % sampleTicksForOnePhase) / (double)sampleTicksForOnePhase)  * Int64.MaxValue);
        //}

        //static public SamplePhase CreatePhaseChange(Int64 sampleTicks, Int64 frequencyMilliHz)
        //{
        //    return new SamplePhase(CalcPhaseChange(sampleTicks,frequencyMilliHz));
        //}

        //static public SamplePhase CreatePhaseChange(SoundTime soundTime, SoundPitch frequencyMilliHz)
        //{
        //    return new SamplePhase(CalcPhaseChange(soundTime.PositionAsInt64, frequencyMilliHz.PitchAsInt64));
        //}
    }
}
