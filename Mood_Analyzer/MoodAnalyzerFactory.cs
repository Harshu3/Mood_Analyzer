using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerDemo
{
    public class MoodAnalyzerFactory
    {
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            string pattern = "." + constructor + "$";
            bool result = Regex.IsMatch(className, pattern);

            if (result)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyzerType);
                }
                catch (Exception ex)
                {
                    throw new MoodAnalyzerException("class not found", MoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            else
            {
                throw new MoodAnalyzerException("constructor not found", MoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
            }
        }
    }
}
