using JSTest.ScriptLibraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace WebCalc
{
    [TestClass]
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

        [ClassInitialize]
        static public void CommonJavaScriptTests(TestContext tc)
        {
            script.AppendFile(GetApplicationPath("CalcJS.html"));
            script.AppendFile(GetApplicationPath("calculate.js"));
            script.AppendBlock(new JsAssertLibrary());
        }

        [DataTestMethod]
        [DataRow(1, 2, "+", 3)]
        [DataRow(2, 3, "-", -1)]
        [DataRow(4, 5, "*", 20)]
        [DataRow(8, 4, "/", 2)]
        public void TestMethod1(int a, int b, string op, int res)
        {
            script.RunTest($"assert.equal({res}, calculate({a}, {b}, '{op}'));");
        }
    }
}
