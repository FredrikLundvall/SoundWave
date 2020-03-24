using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWave.ConnectionStyle
{
    public class SoundBoxBaseOutputValue: IOutputable
    {
        protected readonly SoundBoxBase fSoundBox;
        public SoundBoxBaseOutputValue(SoundBoxBase aSoundBox) : base()
        {
            fSoundBox = aSoundBox;
        }
        public Output Output(double aMomentInSeconds)
        {
            return fSoundBox.OutputValue(aMomentInSeconds);
        }
    }
}
