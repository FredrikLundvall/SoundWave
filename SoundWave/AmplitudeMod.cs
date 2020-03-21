using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave
{
    public class AmplitudeMod
    {
        public readonly Sound Sound;
        public readonly SampleValue MinAmplitude;

        public AmplitudeMod(Sound aSound, SampleValue aMinAmplitude)
        {
            Sound = aSound;
            if (Math.Abs(aMinAmplitude.GetValueAsDouble()) < 1)
            {
                MinAmplitude = aMinAmplitude;
            }
            else
            {
                MinAmplitude = new SampleValue(1);
            }
        }
    }
}
