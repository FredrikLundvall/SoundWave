using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxWave: IConnectable, IOutputablePhase
    {
        protected readonly List<IOutputable> fAmplitudeOutputListeners = new List<IOutputable>();
        protected readonly List<IOutputable> fFrequencyOutputListeners = new List<IOutputable>();
        protected readonly double fStartSecond;
        protected readonly double fDurationSecond;
        protected readonly double fStartPhase;
        public SoundBoxWave(double aStartSecond, double aDurationSecond, double aStartPhase)
        {
            fStartSecond = aStartSecond;
            fDurationSecond = aDurationSecond;
            fStartPhase = aStartPhase;
        }
        public void AmplitudeInput(IOutputable aAmplitudeOutputable)
        {
            fAmplitudeOutputListeners.Add(aAmplitudeOutputable);
        }
        public void FrequencyInput(IOutputable aFrequencyOutputable)
        {
            fFrequencyOutputListeners.Add(aFrequencyOutputable);
        }
        public Output CalcOutput(double aMomentInSeconds, double aSampleStepDuration, double aPhase)
        {
            if (aMomentInSeconds < fStartSecond || aMomentInSeconds > (fStartSecond + fDurationSecond))
                return new Output(null, null);
            Output valueFrequency = new Output(null, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency = valueFrequency + frequencyOutput.CalcOutput(aMomentInSeconds, aSampleStepDuration);
            }
            Output valueAmplitude = new Output(null, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude = valueAmplitude + amplitudeOutput.CalcOutput(aMomentInSeconds, aSampleStepDuration);
            }
            Output returnValue = new Output(Math.Sin(aPhase * SamplePhase.PI2) * (valueAmplitude.Value ?? 1), valueFrequency.PhaseChange);
            return returnValue;
        }
        public IOutputable SignalOutput()
        {
            return new OutputablePhaseInstance(this, fStartPhase);
        }
    }
}
