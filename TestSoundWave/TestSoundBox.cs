using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundWave.ConnectionStyle;

namespace TestSoundBox
{
    [TestClass]
    public class TestSoundBox
    {
        [TestMethod]
        public void TestStaticFrequency1Hz()
        {
            SoundBoxWave wave = new SoundBoxWave(0, 2, 0);
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(0, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(1, 0.00002), wave.CalcOutput(0.25, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(0.5, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.00002), wave.CalcOutput(0.75, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(1, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(1, 0.00002), wave.CalcOutput(1.25, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(1.5, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.00002), wave.CalcOutput(1.75, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(2, 0.00002, 0));
        }
        [TestMethod]
        public void TestStaticFrequency50Hz()
        {
            SoundBoxWave wave = new SoundBoxWave(0, 2, 0);
            SoundBoxFrequency frequency = new SoundBoxFrequency(50.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0.001), wave.CalcOutput(0, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(1, 0.001), wave.CalcOutput(0.005, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.001), wave.CalcOutput(0.01, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.001), wave.CalcOutput(0.015, 0.00002,  0.75));
            Assert.AreEqual<Output>(new Output(0, 0.001), wave.CalcOutput(0.02, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(1, 0.001), wave.CalcOutput(0.025, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.001), wave.CalcOutput(0.03, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.001), wave.CalcOutput(0.035, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.001), wave.CalcOutput(0.04, 0.00002, 0));
        }
        [TestMethod]
        public void TestStaticFrequency1HzAmplitude10()
        {
            SoundBoxWave wave = new SoundBoxWave(0, 2, 0);
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(10.0);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(0, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(10, 0.00002), wave.CalcOutput(0.25, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(0.5, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-10, 0.00002), wave.CalcOutput(0.75, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(1, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(10, 0.00002), wave.CalcOutput(1.25, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(1.5, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-10, 0.00002), wave.CalcOutput(1.75, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(2, 0.00002, 0));
        }
        [TestMethod]
        public void TestFrequencyModulation1HzDiff1HzOn2Hz()
        {
            SoundBoxWave waveFM = new SoundBoxWave(0, 1, 0);
            SoundBoxFrequency frequencyFM = new SoundBoxFrequency(1.0);
            SoundBoxAmplitude amplitudeFM = new SoundBoxAmplitude(1.0);
            waveFM.FrequencyInput(frequencyFM.SignalOutput());
            waveFM.AmplitudeInput(amplitudeFM.SignalOutput());
            SoundBoxWave wave = new SoundBoxWave(0, 1, 0);
            SoundBoxFrequency frequency = new SoundBoxFrequency(2.0, 1);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            frequency.FrequencyFMInput(waveFM.SignalOutput());
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0, 0.00004), wave.CalcOutput(0, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(1, 0.00004), wave.CalcOutput(0.125, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.00006), wave.CalcOutput(0.25, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.00004), wave.CalcOutput(0.375, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.00004), wave.CalcOutput(0.5, 0.00002, 0));
            Assert.AreEqual<Output>(new Output(1, 0.00004), wave.CalcOutput(0.625, 0.00002, 0.25));
            Assert.AreEqual<Output>(new Output(0, 0.00002), wave.CalcOutput(0.75, 0.00002, 0.5));
            Assert.AreEqual<Output>(new Output(-1, 0.00004), wave.CalcOutput(0.875, 0.00002, 0.75));
            Assert.AreEqual<Output>(new Output(0, 0.00004), wave.CalcOutput(1, 0.00002, 0));
        }
    }
}
