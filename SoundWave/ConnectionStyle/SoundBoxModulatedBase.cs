using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    abstract public class SoundBoxModulatedBase: SoundBoxBase
    {
        protected readonly List<IOutputable> fAmplitudeOutputListeners = new List<IOutputable>();
        public void AddAmplitudeOutputable(IOutputable aAmplitudeOutputable)
        {
            fAmplitudeOutputListeners.Add(aAmplitudeOutputable);
        }
        protected readonly List<IOutputable> fFrequencyOutputListeners = new List<IOutputable>();
        public void AddFrequencyOutputable(IOutputable aFrequencyOutputable)
        {
            fFrequencyOutputListeners.Add(aFrequencyOutputable);
        }
    }
}
