using System;
using System.IO;
using Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class InputHelpersTests
    {
        [TestMethod]
        public void SafeInputDouble_ShouldSkipInvalid_AndReturnFirstValid()
        {
            
            var input = new StringReader("abc\n-5\n12,5\n");
            var output = new StringWriter();

            var oldIn = Console.In;
            var oldOut = Console.Out;
            try
            {
                Console.SetIn(input);
                Console.SetOut(output);

                double val = InputHelpers.SafeInputDouble("Введите цену: ");
                Assert.IsTrue(Math.Abs(val - 12.5) < 1e-6);

                var text = output.ToString();
                StringAssert.Contains(text, "Ошибка: введите числовое значение.");
                StringAssert.Contains(text, "Ошибка: значение не может быть отрицательным.");
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }

        [TestMethod]
        public void SafeInputInt_ShouldSkipInvalid_AndReturnFirstValid()
        {
            var input = new StringReader("\n1.2\n-3\n16\n");
            var output = new StringWriter();
            var oldIn = Console.In;
            var oldOut = Console.Out;

            try
            {
                Console.SetIn(input);
                Console.SetOut(output);

                int val = InputHelpers.SafeInputInt("Введите ОЗУ: ");
                Assert.AreEqual(16, val);

                var text = output.ToString();
                StringAssert.Contains(text, "Ошибка: введите целое число.");
                StringAssert.Contains(text, "Ошибка: значение не может быть отрицательным.");
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }

        [DataTestMethod]
        [DataRow("y\n", true)]
        [DataRow("Y\n", true)]
        [DataRow("n\n", false)]
        [DataRow("N\n", false)]
        [DataRow("maybe\ny\n", true)]
        public void PromptYesNo_ShouldReturnExpected(string feed, bool expected)
        {
            var input = new StringReader(feed);
            var output = new StringWriter();
            var oldIn = Console.In;
            var oldOut = Console.Out;

            try
            {
                Console.SetIn(input);
                Console.SetOut(output);

                bool res = InputHelpers.PromptYesNo("Удалить?");
                Assert.AreEqual(expected, res);
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }

        [TestMethod]
        public void CreateComputer_ShouldCreate_PC_WhenTypeIs1()
        {
            var feed = "1\nDell\nOpti\n999,99\n16\n";
            var input = new StringReader(feed);
            var output = new StringWriter();
            var oldIn = Console.In;
            var oldOut = Console.Out;

            try
            {
                Console.SetIn(input);
                Console.SetOut(output);

                Computer c = InputHelpers.CreateComputer();
                Assert.IsInstanceOfType(c, typeof(PersonalComputer));
                Assert.AreEqual("Dell", c.GetManufacturer());
                Assert.AreEqual("Opti", c.GetModel());
                Assert.IsTrue(Math.Abs(c.GetPrice() - 999.99) < 1e-2);
                Assert.AreEqual(16, c.GetRam());
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }

        [TestMethod]
        public void CreateComputer_ShouldThrow_OnBadType()
        {
            var input = new StringReader("tablet\n");
            var output = new StringWriter();
            var oldIn = Console.In;
            var oldOut = Console.Out;

            try
            {
                Console.SetIn(input);
                Console.SetOut(output);

                try
                {
                    var _ = InputHelpers.CreateComputer();
                    Assert.Fail("Ожидалось ArgumentException.");
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual("Ошибка: введён неверный тип устройства. Допустимые: 1, 2, pc, laptop.", ex.Message);
                }
            }
            finally
            {
                Console.SetIn(oldIn);
                Console.SetOut(oldOut);
            }
        }
    }
}
