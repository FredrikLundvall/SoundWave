using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public interface IOutputablePhase
    {
        Output CalcOutput(double aMomentInSeconds, double aSampleStepDuration, double aCurrentPhase);
    }
}
