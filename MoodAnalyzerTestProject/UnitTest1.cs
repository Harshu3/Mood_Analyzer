using MoodAnalyzerDemo;
using MoodAnalyzerProblems;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("", "Message having null")]
        [DataRow("", "Message is empty")]
        public void Given_Null_Should_Return_CustomException(string msg, string expected)
        {
            if(expected.Equals("Message having null"))
                msg = null;

            MoodAnalyzer mood = new MoodAnalyzer(msg);

            try
            {
                string actual = mood.AnalyzeMood();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}