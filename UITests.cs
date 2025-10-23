using System;
using System.Collections.Generic;
using System.IO;
using Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        public void TruncateStr_ShouldCutAndAppendDots()
        {
            Assert.AreEqual("Short", UI.TruncateStr("Short", 10));
            Assert.AreEqual("0123456789", UI.TruncateStr("0123456789", 10));
            Assert.AreEqual("0123456...", UI.TruncateStr("0123456789X", 10));
            Assert.AreEqual("..", UI.TruncateStr("Long", 2));
        }

        [TestMethod]
        public void PrintComputersTable_ShouldWriteRows()
        {
            var data = new List<Computer>
            {
                new PersonalComputer("Dell","Opti",1000,16),
                new Laptop("HP","Pavilion",1200,8),
            };

            var sw = new StringWriter();
            var oldOut = Console.Out;
            try
            {
                Console.SetOut(sw);
                UI.PrintComputersTable(data);
                var text = sw.ToString();

                StringAssert.Contains(text, "Персональный ПК");
                StringAssert.Contains(text, "Ноутбук");
                StringAssert.Contains(text, "Dell");
                StringAssert.Contains(text, "HP");
            }
            finally
            {
                Console.SetOut(oldOut);
            }
        }
    }
}
