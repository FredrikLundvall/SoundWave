using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public struct MixType
    {
        public readonly MixKind CalcMixKind;
        public readonly double MixRatio;
        public MixType(MixKind aCalcMixKind, double aMixRatio)
        {
            CalcMixKind = aCalcMixKind;
            MixRatio = aMixRatio;
        }
    }
}
