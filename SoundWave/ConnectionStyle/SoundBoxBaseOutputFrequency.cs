using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxBaseOutputFrequency : IOutputable
    {
        protected readonly SoundBoxBase fSoundBox;
        public SoundBoxBaseOutputFrequency(SoundBoxBase aSoundBox) : base()
        {
            fSoundBox = aSoundBox;
        }
        public Output Output(double aMomentInSeconds)
        {
            return fSoundBox.OutputFrequency(aMomentInSeconds);
        }
    }
}
