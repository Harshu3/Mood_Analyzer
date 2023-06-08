using MoodAnalyzerProblems;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("", "happy")]
        public void Given_Null_Should_Return_Mood(string msg, string expected)
        {
            msg = null;
            MoodAnalyzer mood = new MoodAnalyzer(msg);

            string actual = mood.AnalyzeMood();

            Assert.AreEqual(expected, actual);
        }
    }
}