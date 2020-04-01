using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundWave.ConnectionStyle;

namespace TestSoundWave
{
    [TestClass]
    public class TestSoundBoxWave
    {
        [TestMethod]
        public void TestStaticFrequency1Hz()
        {
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0m));
            Assert.AreEqual<Output>(new Output(1, 0.25), wave.CalcOutput(0.25));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.75), wave.CalcOutput(0.75));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(1));
            Assert.AreEqual<Output>(new Output(1, 0.25), wave.CalcOutput(1.25));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(1.5));
            Assert.AreEqual<Output>(new Output(-1, 0.75), wave.CalcOutput(1.75));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(2));
        }
        [TestMethod]
        public void TestStaticFrequency50Hz()
        {
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(50.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0));
            Assert.AreEqual<Output>(new Output(1, 0.25), wave.CalcOutput(0.005));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(0.01));
            Assert.AreEqual<Output>(new Output(-1, 0.75), wave.CalcOutput(0.015));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0.02));
            Assert.AreEqual<Output>(new Output(1, 0.25), wave.CalcOutput(0.025));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(0.03));
            Assert.AreEqual<Output>(new Output(-1, 0.75), wave.CalcOutput(0.035));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0.04));
        }
        [TestMethod]
        public void TestStaticFrequency1HzAmplitude10()
        {
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(10.0);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0));
            Assert.AreEqual<Output>(new Output(10, 0.25), wave.CalcOutput(0.25));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(0.5));
            Assert.AreEqual<Output>(new Output(-10, 0.75), wave.CalcOutput(0.75));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(1));
            Assert.AreEqual<Output>(new Output(10, 0.25), wave.CalcOutput(1.25));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(1.5));
            Assert.AreEqual<Output>(new Output(-10, 0.75), wave.CalcOutput(1.75));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(2));
        }
        [TestMethod]
        public void TestFrequencyModulation1HzDiff1HzOn2Hz()
        {
            SoundBoxWave waveFM = new SoundBoxWave();
            SoundBoxFrequency frequencyFM = new SoundBoxFrequency(1.0);
            SoundBoxAmplitude amplitudeFM = new SoundBoxAmplitude(1.0);
            waveFM.FrequencyInput(frequencyFM.SignalOutput());
            waveFM.AmplitudeInput(amplitudeFM.SignalOutput());
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(2.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            wave.FrequencyInput(waveFM.SignalOutput());
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0));
            //Assert.AreEqual<Output>(new Output(1, 0.25), wave.CalcOutput(0.25));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(0.25));
            //Assert.AreEqual<Output>(new Output(-1, 0.75), wave.CalcOutput(0.75));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(0.5));
            //Assert.AreEqual<Output>(new Output(1, 0.25), wave.CalcOutput(1.25));
            Assert.AreEqual<Output>(new Output(0, 0.5), wave.CalcOutput(0.75));
            //Assert.AreEqual<Output>(new Output(-1, 0.75), wave.CalcOutput(1.75));
            Assert.AreEqual<Output>(new Output(0, 0), wave.CalcOutput(2));
        }
    }
}
