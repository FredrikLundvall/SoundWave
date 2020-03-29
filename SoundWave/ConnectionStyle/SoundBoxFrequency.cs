using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using raminrahimzada;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxFrequency : IOutputable
    {
        protected readonly decimal fFrequency;
        protected readonly decimal fFrequencyFMSpan;
        protected readonly List<IOutputable> fFrequencyFMOutputListeners = new List<IOutputable>();
        public SoundBoxFrequency(decimal aFrequency, decimal aFrequencyFMSpan = 0)
        {
            fFrequency = aFrequency;
            fFrequencyFMSpan = aFrequencyFMSpan;
        }
        public void FrequencyFMInput(IOutputable aFrequencyOutputable)
        {
            fFrequencyFMOutputListeners.Add(aFrequencyOutputable);
        }
        public Output CalcOutput(decimal aMomentInSeconds)
        {
            Output valueFMFrequency = new Output(null, null);
            foreach (var frequencyFMOutput in fFrequencyFMOutputListeners)
            {
                valueFMFrequency += frequencyFMOutput.CalcOutput(aMomentInSeconds);
            }
            decimal phaseSpan = 0m; 
            if((valueFMFrequency.Value ?? 0) != 0 && fFrequencyFMSpan != 0)
                phaseSpan = ((fFrequencyFMSpan != 0m) ? fFrequencyFMSpan / DecimalMath.PIx4 : 0m) * (valueFMFrequency.Value ?? 0);
            return new Output(fFrequency + (fFrequencyFMSpan * valueFMFrequency.Value), Output.ConvertFrequencyToPhasePosition(aMomentInSeconds, fFrequency) + phaseSpan);
        }

        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
