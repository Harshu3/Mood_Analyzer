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
    
        public string InvokeAnalyzerMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzer);
                MoodAnalyzerFactory factory = new MoodAnalyzerFactory();
                object moodAnalyzerObject = factory.CreateMoodAnalyzerParameterizedObject("MoodAnalyzer", "MoodAnalyzer", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info = methodInfo.Invoke(moodAnalyzerObject, null);
                return info.ToString();
            }
            catch (MoodAnalyzerException ex)
            {
                if (ex.Message.Equals("class not found"))
                {
                    throw new MoodAnalyzerException("class not found", MoodAnalyzerException.ExceptionTypes.CLASS_NOT_FOUND);
                }
                else
                {
                    throw new MoodAnalyzerException("constructor not found", MoodAnalyzerException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            catch (Exception ex)
            {
                throw new MoodAnalyzerException("method not found", MoodAnalyzerException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }
    }
}
