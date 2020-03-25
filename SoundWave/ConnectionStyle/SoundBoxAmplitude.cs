using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxAmplitude : SoundBoxBase
    {
        protected readonly double fAmplitude;
        public SoundBoxAmplitude(double aAmplitude)
        {
            fAmplitude = aAmplitude;
        }
        override public Output OutputValue(double aMomentInSeconds)
        {
            return new Output(fAmplitude, null, null);
        }
    }

}
