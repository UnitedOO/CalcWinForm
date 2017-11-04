﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;

namespace TestCalc
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("text_a", true)]
        [DataRow("text_b", true)]
        [DataRow("text_op", true)]
        [DataRow("text_res", true)]
        public void Calc_Enable(string id, bool exp)
        {
            Application application = Application.Launch(new ProcessStartInfo(@"CalcWinForm.exe")
            {
                WorkingDirectory = @"..\..\..\CalcWinForm\bin\Debug\",
            });
            Window window = application.GetWindows()[0];

            bool res = window.Get<TextBox>(SearchCriteria.ByAutomationId(id)).Enabled;
            Assert.AreEqual(exp, res);
            application.Kill();
        }
    }
}
