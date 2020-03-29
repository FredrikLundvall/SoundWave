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
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0m);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0m);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0m));
            Assert.AreEqual<Output>(new Output(1m, 0.25m), wave.CalcOutput(0.25m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.5m));
            Assert.AreEqual<Output>(new Output(-1m, 0.75m), wave.CalcOutput(0.75m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(1m));
            Assert.AreEqual<Output>(new Output(1m, 0.25m), wave.CalcOutput(1.25m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(1.5m));
            Assert.AreEqual<Output>(new Output(-1m, 0.75m), wave.CalcOutput(1.75m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(2m));
        }
        [TestMethod]
        public void TestStaticFrequency50Hz()
        {
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(50.0m);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0m);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0m));
            Assert.AreEqual<Output>(new Output(1m, 0.25m), wave.CalcOutput(0.005m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.01m));
            Assert.AreEqual<Output>(new Output(-1m, 0.75m), wave.CalcOutput(0.015m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0.02m));
            Assert.AreEqual<Output>(new Output(1m, 0.25m), wave.CalcOutput(0.025m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.03m));
            Assert.AreEqual<Output>(new Output(-1m, 0.75m), wave.CalcOutput(0.035m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0.04m));
        }
        [TestMethod]
        public void TestStaticFrequency1HzAmplitude10()
        {
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(1.0m);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(10.0m);
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0m));
            Assert.AreEqual<Output>(new Output(10m, 0.25m), wave.CalcOutput(0.25m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.5m));
            Assert.AreEqual<Output>(new Output(-10m, 0.75m), wave.CalcOutput(0.75m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(1m));
            Assert.AreEqual<Output>(new Output(10m, 0.25m), wave.CalcOutput(1.25m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(1.5m));
            Assert.AreEqual<Output>(new Output(-10m, 0.75m), wave.CalcOutput(1.75m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(2m));
        }
        [TestMethod]
        public void TestFrequencyModulation1HzDiff1HzOn2Hz()
        {
            SoundBoxWave waveFM = new SoundBoxWave();
            SoundBoxFrequency frequencyFM = new SoundBoxFrequency(1.0m);
            SoundBoxAmplitude amplitudeFM = new SoundBoxAmplitude(1.0m);
            waveFM.FrequencyInput(frequencyFM.SignalOutput());
            waveFM.AmplitudeInput(amplitudeFM.SignalOutput());
            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(2.0m);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0m);
            wave.FrequencyInput(waveFM.SignalOutput());
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0m));
            //Assert.AreEqual<Output>(new Output(1m, 0.25m), wave.CalcOutput(0.25m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.25m));
            //Assert.AreEqual<Output>(new Output(-1m, 0.75m), wave.CalcOutput(0.75m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(0.5m));
            //Assert.AreEqual<Output>(new Output(1m, 0.25m), wave.CalcOutput(1.25m));
            Assert.AreEqual<Output>(new Output(0m, 0.5m), wave.CalcOutput(0.75m));
            //Assert.AreEqual<Output>(new Output(-1m, 0.75m), wave.CalcOutput(1.75m));
            Assert.AreEqual<Output>(new Output(0m, 0m), wave.CalcOutput(2m));
        }
    }
}
