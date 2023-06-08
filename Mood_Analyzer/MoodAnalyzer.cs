using MoodAnalyzerDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblems
{
    public class MoodAnalyzer
    {
        public string message;

        public MoodAnalyzer()
        {
            Console.WriteLine("default constructor");
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyzeMood()
        {
            try
            {
                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else if(message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerException("Message is empty", MoodAnalyzerException.ExceptionTypes.EMPTY_MOOD);
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException ex)
            {
                throw new MoodAnalyzerException("Message having null", MoodAnalyzerException.ExceptionTypes.NULL_MOOD);
            }
        }
    }
}
