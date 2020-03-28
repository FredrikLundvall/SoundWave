﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using raminrahimzada;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxWave: IOutputable
    {
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
        public Output CalcOutput(decimal aMomentInSeconds)
        {
            Output valueFrequency = new Output(null, null);
            foreach (var frequencyOutput in fFrequencyOutputListeners)
            {
                valueFrequency = valueFrequency + frequencyOutput.CalcOutput(aMomentInSeconds);
            }
            Output valueAmplitude = new Output(null, null);
            foreach (var amplitudeOutput in fAmplitudeOutputListeners)
            {
                valueAmplitude = valueAmplitude + amplitudeOutput.CalcOutput(aMomentInSeconds);
            }
            decimal? phase = Output.ConvertFrequencyToPhase(aMomentInSeconds, valueFrequency.Value);
            Output returnValue = new Output((DecimalMath.Sin(((phase ?? 0m)) * DecimalMath.PIx2) * (valueAmplitude.Value ?? 1)), phase);
            return returnValue;
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
