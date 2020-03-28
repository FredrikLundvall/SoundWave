using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundWave.ConnectionStyle;

namespace TestSoundWave
{
    [TestClass]
    public class TestSoundBoxWave
    {
        [TestMethod]
        public void TestStaticFrequency()
        {
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0m);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0m);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.5m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(1m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(1.5m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(2m));
        }
    }
}
