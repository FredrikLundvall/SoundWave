using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using raminrahimzada;

namespace SoundWave.ConnectionStyle
{
    public class ModifierAddValue : IOutputable
    {
        protected readonly List<IOutputable> fValueOutputListeners = new List<IOutputable>();
        protected readonly Output fAddToOutput;
        public ModifierAddValue(Output aAddToOutput)
        {
            fAddToOutput = aAddToOutput;
        }
        public void ValueInput(IOutputable aValueOutputable)
        {
            fValueOutputListeners.Add(aValueOutputable);
        }
        public Output CalcOutput(decimal aMomentInSeconds)
        {
            Output modifiedValue = fAddToOutput;
            foreach (var valueOutput in fValueOutputListeners)
            {
                modifiedValue = modifiedValue + valueOutput.CalcOutput(aMomentInSeconds);
            }
            return modifiedValue;
        }
        public IOutputable SignalOutput()
        {
            return this;
        }
    }
}
