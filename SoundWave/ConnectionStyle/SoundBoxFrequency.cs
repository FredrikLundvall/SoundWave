using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequency : IOutputable, IConnectable
    {
        protected readonly double fFrequency;
        protected readonly double fFrequencyFMSpan;
        protected readonly List<IOutputable> fFrequencyFMOutputListeners = new List<IOutputable>();
        public SoundBoxFrequency(double aFrequency, double aFrequencyFMSpan = 0)
        {
            fFrequency = aFrequency;
            fFrequencyFMSpan = aFrequencyFMSpan;
        }
        public void FrequencyFMInput(IOutputable aFrequencyOutputable)
        {
            fFrequencyFMOutputListeners.Add(aFrequencyOutputable);
        }
        public Output CalcOutput(double aMomentInSeconds, double aSampleStepDuration)
        {
            Output valueFMFrequency = new Output(null, null);
            foreach (var frequencyFMOutput in fFrequencyFMOutputListeners)
            {
                valueFMFrequency += frequencyFMOutput.CalcOutput(aMomentInSeconds, aSampleStepDuration);
            }
            //valueFMFrequency.Value är null
            //valueFMFrequency.PhaseChange är samma hela tiden
            //Borde valueFMFrequency.Value ha ett värde?
            Output returnValue = new Output(null, Output.ConvertFrequencyToPhaseChange(aSampleStepDuration, fFrequency + (fFrequencyFMSpan * valueFMFrequency.Value ?? 0)) + (valueFMFrequency.PhaseChange ?? 0));
            return returnValue;
        }

        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
