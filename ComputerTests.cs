using System;
using Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ComputerTests
    {
        [DataTestMethod]
        [DataRow(null, "M1", 10.0, 8, "Ошибка: производитель не может быть пустым.")]
        [DataRow("  ", "M1", 10.0, 8, "Ошибка: производитель не может быть пустым.")]
        [DataRow("ACME", null, 10.0, 8, "Ошибка: модель не может быть пустой.")]
        [DataRow("ACME", "  ", 10.0, 8, "Ошибка: модель не может быть пустой.")]
        [DataRow("ACME", "M1", -1.0, 8, "Ошибка: цена не может быть отрицательной.")]
        [DataRow("ACME", "M1", 10.0, -1, "Ошибка: объём оперативной памяти не может быть отрицательным.")]
        public void Computer_Ctor_ShouldThrow_OnInvalidArgs(string man, string mod, double price, int ram, string expectedMsg)
        {
            try
            {
                var _ = new Computer(man, mod, price, ram);
                Assert.Fail("Ожидалось исключение ArgumentException, но оно не было брошено.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }

        [TestMethod]
        public void DerivedClasses_ShouldOverride_GetTypeName()
        {
            var pc = new PersonalComputer("Dell", "Opti", 1000, 16);
            var lap = new Laptop("HP", "Pavilion", 1200, 16);

            Assert.AreEqual("Персональный ПК", pc.GetTypeName());
            Assert.AreEqual("Ноутбук", lap.GetTypeName());
        }
    }
}
