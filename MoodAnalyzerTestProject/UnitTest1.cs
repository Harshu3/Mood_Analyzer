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
        public void Given_MoodAnalyzerWithMessage_Using_Reflection_Return_ParameterizedConstructor()
        {
            string message = "I am in happy mood";
            MoodAnalyzer expected = new MoodAnalyzer(message);
            object actual = null;
            try
            {
                actual = factory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzer", "MoodAnalyzer", message);
                actual.Equals(expected);
            }
            catch (MoodAnalyzerException exception)
            {
                Console.WriteLine(exception.Message);
                Assert.AreEqual("class not found", exception.Message);
            }
        }
    }
}