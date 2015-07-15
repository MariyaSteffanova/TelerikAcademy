namespace Exam_Konspiration
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class Extractor
    {
        private const string OpenParenthesis = "(";
        private const string CloseParenthesis = ")";
        private const string MethodInvokingSymbol = ".";
        private static List<string> vars = new List<string> { "StringBuilder", "List", "HashSet", "Dictionary" };
        private static List<string> modifiers = new List<string> { " static ", " private ", " public ", " protected ", " internal ", " virtual ", " sealed " };
        
        private static string regexInvokingMethod;
        private static MatchCollection currentInvokedMethods;
        private static List<string> declaredMethods = new List<string>();
        private static List<List<string>> invokedMethods = new List<List<string>>();
        private static int currentInvokedMethodsCount = -1;

        public static int GetCurrentInvokedMethodsCount()
        {
            return currentInvokedMethodsCount;
        }

        public static List<List<string>> GetInvokedMethods(string currentLine)
        {
            bool isConstructor;
            bool isAlreadyAdded;
            regexInvokingMethod = @"([A-Z,_])\w+([(])|([A-Z,_])\w+(\s+[(])";
            currentInvokedMethods = Regex.Matches(currentLine.ToString(), regexInvokingMethod);

            foreach (var method in currentInvokedMethods)
            {
                string methodName = GetInvokedMethodName(method);

                isConstructor = IsConstructor(methodName);
                isAlreadyAdded = methodName.Contains(declaredMethods[currentInvokedMethodsCount]);

                if (!isAlreadyAdded && !isConstructor)
                {
                    invokedMethods[currentInvokedMethodsCount].Add(methodName);
                }
            }

            return invokedMethods;
        }

        public static List<string> GetDeclaredMethod(string currentLine)
        {
            for (int index = 0; index < modifiers.Count; index++)
            {
                if (currentLine.Contains(modifiers[index]))
                {
                    currentInvokedMethodsCount++;

                    string methodName = GetDeclaredMethodName(modifiers, currentLine, index);

                    declaredMethods.Add(methodName.Trim());
                    invokedMethods.Add(new List<string>());
                }
            }

            return declaredMethods;
        }

        private static bool IsConstructor(string methodName)
        {
            for (int index = 0; index < vars.Count; index++)
            {
                if (methodName == vars[index])
                {
                    return true;
                }
            }

            return false;
        }

        private static string GetInvokedMethodName(object method)
        {
            string methodName = method.ToString();
            methodName = methodName.Replace(MethodInvokingSymbol, string.Empty)
                                   .Replace(OpenParenthesis, string.Empty)
                                   .Replace(" ", string.Empty);
            return methodName;
        }

        private static string GetDeclaredMethodName(List<string> modifiers, string currentLine, int index)
        {
            int endIndexMethodName = currentLine.IndexOf(OpenParenthesis);
            int indexModifier = currentLine.IndexOf(modifiers[index]);
            currentLine = currentLine.Substring(0, indexModifier) + 
                            currentLine.Substring(indexModifier + modifiers[index].Length).Trim();

            endIndexMethodName = currentLine.IndexOf(OpenParenthesis);
            int startMethodName = currentLine.IndexOf(' ', indexModifier);
            string methodName = currentLine.Substring(startMethodName, endIndexMethodName - startMethodName);
            return methodName;
        }
    }
}
