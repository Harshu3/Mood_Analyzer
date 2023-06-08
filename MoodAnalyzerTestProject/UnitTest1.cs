using MoodAnalyzerDemo;
using MoodAnalyzerProblems;
using System;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public MoodAnalyzerFactory factory = new MoodAnalyzerFactory();

        [TestMethod]
        [TestCategory("ReflectionTestCase")]
        [DataRow("MoodAnalyzerDemo.MoodAnalyzer", "MoodAnalyzer")]
        public void Given_ClassInfo_Return_Default_Constructor(string className, string constructor)
        {
            string expectedMsg = "class not found";
            try
            {
                MoodAnalyzer expected = new MoodAnalyzer();
                MoodAnalyzer actual = (MoodAnalyzer)factory.CreateMoodAnalyzerObject(className, constructor);
                actual.Equals(expected);
            }
            catch(MoodAnalyzerException ex)
            {
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }
    }
}