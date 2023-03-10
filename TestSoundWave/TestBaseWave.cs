using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoundWave
{
    [TestClass]
    public class TestBaseWave
    {
        [TestMethod]
        public void TestGetPhase()
        {
            SineWave sineWave = new SineWave();
            int frequencyMilliHz = 1000;
            Int64 ticksForOneWave = (frequencyMilliHz / 1000) * 10000000;
            Assert.AreEqual<string>((Math.PI).ToString("F6"), sineWave.GetPhase(TimeSpan.FromTicks(ticksForOneWave / 2), frequencyMilliHz).ToString("F6"));
            Assert.AreEqual<string>((Math.PI * 2).ToString("F6"), sineWave.GetPhase(TimeSpan.FromTicks(ticksForOneWave), frequencyMilliHz).ToString("F6"));
        }
    }
}
