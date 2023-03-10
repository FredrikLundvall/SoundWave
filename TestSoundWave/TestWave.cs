using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoundWave
{
    [TestClass]
    public class TestWave
    {
        [TestMethod]
        public void GetSampleValueFromSine()
        {
            SineWave sineWave = new SineWave();
            int frequencyMilliHz = 1000;
            Double milliSecondsForOneWave = (frequencyMilliHz / 1000) * 1000;
            SamplePhase samplePhase;

            Assert.AreEqual<string>((new SampleValue(0)).ToString(), sineWave.GetSampleValue(new SamplePhase(TimeSpan.FromMilliseconds(0), frequencyMilliHz)).ToString());
            Assert.AreEqual<string>((new SampleValue(0)).ToString(), sineWave.GetSampleValue(new SamplePhase(TimeSpan.FromMilliseconds(milliSecondsForOneWave), frequencyMilliHz)).ToString());
            Assert.AreEqual<string>((new SampleValue(0)).ToString(), sineWave.GetSampleValue(new SamplePhase(TimeSpan.FromMilliseconds(milliSecondsForOneWave / 2), frequencyMilliHz)).ToString());
            samplePhase = new SamplePhase(TimeSpan.FromMilliseconds(milliSecondsForOneWave / 4), frequencyMilliHz);
            Assert.AreEqual<string>((new SampleValue(1)).ToString(), sineWave.GetSampleValue(samplePhase).ToString());
            Assert.AreEqual<string>((new SampleValue(-1)).ToString(), sineWave.GetSampleValue(new SamplePhase(TimeSpan.FromMilliseconds((milliSecondsForOneWave * 3) / 4), frequencyMilliHz)).ToString());
        }

    }
}
