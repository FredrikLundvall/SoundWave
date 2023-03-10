using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoundWave
{
    [TestClass]
    public class TestSampleValue
    {
        [TestMethod]
        public void ConvertToBytes()
        {
            SampleValue sampleValue = new SampleValue(1);
            byte[] bytes = sampleValue.ConvertToBytes(8);
            Assert.AreEqual<int>(1, bytes.GetLength(0));
            Assert.AreEqual<byte>(128, bytes[0]);

            bytes = sampleValue.ConvertToBytes(16);
            Assert.AreEqual<int>(2, bytes.GetLength(0));
            Assert.AreEqual<Int16>(Int16.MaxValue, BitConverter.ToInt16(bytes, 0));

            bytes = sampleValue.ConvertToBytes(32);
            Assert.AreEqual<int>(4, bytes.GetLength(0));
            Assert.AreEqual<Int32>(Int32.MaxValue, BitConverter.ToInt32(bytes, 0));

            //bytes = sampleValue.ConvertToBytes(64);
            //Assert.AreEqual<int>(8, bytes.GetLength(0));
            //Assert.AreEqual<Int64>(Int64.MaxValue, BitConverter.ToInt64(bytes, 0));
        }
    }
}