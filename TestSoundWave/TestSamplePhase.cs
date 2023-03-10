using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoundWave
{
    [TestClass]
    public class TestSamplePhase
    {
        [TestMethod]
        public void TestPhaseWrapAround()
        {
            SamplePhase samplePhase = new SamplePhase(Int64.MaxValue);
            samplePhase.AddPhase(new SamplePhase(1));
            Assert.AreEqual<Int64>(0, samplePhase.GetPhaseAsTicks());

            samplePhase = new SamplePhase(0);
            samplePhase.AddPhase(new SamplePhase(-1));
            Assert.AreEqual<Int64>(Int64.MaxValue, samplePhase.GetPhaseAsTicks());
        }

        [TestMethod]
        public void TestGetPhaseAsDouble()
        {
            SamplePhase samplePhase = new SamplePhase(0);
            Assert.AreEqual<Double>(0, samplePhase.GetPhaseAsDouble());

            samplePhase = new SamplePhase(Int64.MaxValue/2);
            Assert.AreEqual<Double>(0.5d, samplePhase.GetPhaseAsDouble());

            samplePhase = new SamplePhase(Int64.MaxValue);
            Assert.AreEqual<Double>(1, samplePhase.GetPhaseAsDouble());
        }

        [TestMethod]
        public void TestCalcPhaseChange()
        {
            Assert.AreEqual<Double>(0.5d, SamplePhase.CreatePhaseChange(500 * 10000, 1000).GetPhaseAsDouble());
            Assert.AreEqual<Int64>(4611686018427387904, SamplePhase.CreatePhaseChange(500 * 10000, 1000).GetPhaseAsTicks());
        }

        //[TestMethod]
        //public void TestGetPhaseAsRadians()
        //{
        //    int frequencyMilliHz = 1000;
        //    Int64 ticksForOneWave = (frequencyMilliHz / 1000) * 10000000;
        //    SamplePhase samplePhase;
        //    Assert.AreEqual<string>((Math.PI).ToString("F6"), sineWave.GetPhase(TimeSpan.FromTicks(ticksForOneWave / 2), frequencyMilliHz).ToString("F6"));
        //    Assert.AreEqual<string>((Math.PI * 2).ToString("F6"), sineWave.GetPhase(TimeSpan.FromTicks(ticksForOneWave), frequencyMilliHz).ToString("F6"));
        //}
    }
}



