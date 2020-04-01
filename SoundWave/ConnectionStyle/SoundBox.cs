using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBox: IOutputable
    {
        protected readonly List<IOutputable> fValueOutputListeners = new List<IOutputable>();
        protected readonly List<IOutputable> fAmplitudeOutputListeners = new List<IOutputable>();
        protected readonly List<IOutputable> fFrequencyOutputListeners = new List<IOutputable>();
        public void AmplitudeInput(IOutputable aAmplitudeOutputable)
        {
            fAmplitudeOutputListeners.Add(aAmplitudeOutputable);
        }
        public void FrequencyInput(IOutputable aFrequencyOutputable)
        {
            fFrequencyOutputListeners.Add(aFrequencyOutputable);
        }
        public void SignalInput(IOutputable aValueOutputable)
        {
            fValueOutputListeners.Add(aValueOutputable);
        }
        virtual public Output CalcOutput(double aMomentInSeconds, double aSampleStepDuration)
        {
            Output valueFrequency = new Output(null, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency += frequencyOutput.CalcOutput(aMomentInSeconds, aSampleStepDuration);
            }
            Output value = new Output(null, null);
            foreach (var valueOutput in fValueOutputListeners)
            {
                value += valueOutput.CalcOutput(aMomentInSeconds, aSampleStepDuration);
            }
            Output valueAmplitude = new Output(null, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude += amplitudeOutput.CalcOutput(aMomentInSeconds, aSampleStepDuration);
            }
            return Output.MultiplyAmplitude(value, valueAmplitude.Value) + new Output(null, valueFrequency.PhaseChange);
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
