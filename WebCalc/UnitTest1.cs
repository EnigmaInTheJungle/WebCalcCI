using JSTest.ScriptLibraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.IO;

namespace WebCalc
{
    [TestFixture]
    public class UnitLogicTestJS
    {
        static private readonly JSTest.TestScript script = new JSTest.TestScript();

        static string GetApplicationPath(string applicationName)
        {
            var tmpDirName = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(tmpDirName)));
            string result = Path.Combine(solutionFolder, applicationName);
            return result;
        }

        [SetUp]
        static public void CommonJavaScriptTests()
        {
            //script.AppendFile(GetApplicationPath("CalcJS.html"));
            script.AppendFile(GetApplicationPath("calculate.js"));
            script.AppendBlock(new JsAssertLibrary());
        }

        [Test]
        [TestCase(1, 2, "+", 3)]
        [TestCase(2, 3, "-", -1)]
        [TestCase(4, 5, "*", 20)]
        [TestCase(8, 4, "/", 2)]
        public void TestCalc(int a, int b, string op, int res)
        {
            script.RunTest($"assert.equal({res}, calculate({a}, {b}, '{op}'));");
        }
    }
}
