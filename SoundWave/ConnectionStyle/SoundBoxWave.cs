using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxWave: IOutputable
    {
        protected readonly List<IOutputable> fAmplitudeOutputListeners = new List<IOutputable>();
        protected readonly List<IOutputable> fFrequencyOutputListeners = new List<IOutputable>();
        protected double fPhase = 0;
        public void AmplitudeInput(IOutputable aAmplitudeOutputable)
        {
            fAmplitudeOutputListeners.Add(aAmplitudeOutputable);
        }
        public void FrequencyInput(IOutputable aFrequencyOutputable)
        {
            fFrequencyOutputListeners.Add(aFrequencyOutputable);
        }
        public Output CalcOutput(double aMomentInSeconds, double aSampleStepDuration)
        {
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
            Output returnValue = new Output(Math.Sin(fPhase * SamplePhase.PI2) * (valueAmplitude.Value ?? 1), valueFrequency.PhaseChange);
            fPhase += (valueFrequency.PhaseChange ?? 0);
            return returnValue;
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
