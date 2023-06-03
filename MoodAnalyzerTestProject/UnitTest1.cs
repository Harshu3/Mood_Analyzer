using MoodAnalyzerProblems;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("I am in Happy Mood", "happy")]
        [DataRow("I am in Mood", "sad")]
        [DataRow("I am in Sad Mood", "sad")]
        public void Message_Should_Return_Mood(string msg, string expected)
        {
            MoodAnalyzer mood = new MoodAnalyzer(msg);

            string actual = mood.AnalyzeMood();

            Assert.AreEqual(expected, actual);
        }
    }
}