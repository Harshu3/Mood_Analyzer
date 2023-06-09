using MoodAnalyzerProblems;
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
        public object CreateMoodAnalyzerParameterizedObject(string className, string constructor, string message)
        {
            try
            {
                Type type = typeof(MoodAnalyzer);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    try
                    {
                        if (type.Name.Equals(constructor))
                        {
                            ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                            var obj = constructorInfo.Invoke(new object[] { message });
                            return obj;
                        }
                        else
                        {
                            throw new MoodAnalyzerException("constructor not found", MoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        throw new MoodAnalyzerException("constructor not found", MoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                    }
                }
                else
                {
                    throw new MoodAnalyzerException("class not found", MoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            catch(MoodAnalyzerException ex)
            {
                throw new MoodAnalyzerException(ex.Message, ex.exceptionTypes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
