using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class OutputablePhaseInstance : IOutputable
    {
        protected readonly IOutputablePhase fOutputablePhase;
        protected double fStartPhase = 0;
        protected double fCurrentPhase = 0;
        protected double fLastMomentInSeconds = 0;
        public OutputablePhaseInstance(IOutputablePhase aOutputablePhase, double aStartPhase)
        {
            fOutputablePhase = aOutputablePhase;
            fStartPhase = aStartPhase;
            fCurrentPhase = fStartPhase;
            fLastMomentInSeconds = double.MaxValue;
        }
        public Output CalcOutput(double aMomentInSeconds, double aSampleStepDuration)
        {
            if(aMomentInSeconds < fLastMomentInSeconds)
                fCurrentPhase = fStartPhase;
            fLastMomentInSeconds = aMomentInSeconds;
            Output returnValue =  fOutputablePhase.CalcOutput(aMomentInSeconds, aSampleStepDuration, fCurrentPhase);
            fCurrentPhase += (returnValue.PhaseChange ?? 0);
            return returnValue;
        }
    }
}
