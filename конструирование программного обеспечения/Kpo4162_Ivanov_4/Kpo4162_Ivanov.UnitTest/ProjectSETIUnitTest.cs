using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kpo4162_Ivanov.UnitTest
{
    [TestClass]
    public class ProjectSETIUnitTest
    {
        #region Проверка поля "Год"
        [TestMethod]
        public void TestYearLessThen1900()
        {
            var item = new Kpo4162.Ivanov.Lib.SETI()
            {
                Year=1800,//значение меньше допустимого
                Name = "Имя",
                Diametr=200,
                Chastota=2000
            };
            Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
        }
         [TestMethod]
        public void TestYearLessMoreThen2017()
        {
            var item = new Kpo4162.Ivanov.Lib.SETI()
            {
                Year = 3000,
                Name = "Имя",
                Diametr = 200,
                Chastota = 2000
            };
            Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
        }
         [TestMethod]
         public void TestRightYear()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "Имя",
                 Diametr = 200,
                 Chastota = 2000
             };
             Assert.IsTrue(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }
        #endregion
        #region Проверка поля "Name"
        [TestMethod]
         public void EmptyName()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                Year=2000,
                Name = "",
                Diametr=200,
                Chastota=2000
             };

             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }

         [TestMethod]
         public void NullName()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,//значение меньше допустимого
                 Name = null,
                 Diametr = 200,
                 Chastota = 2000
             };

             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }

         [TestMethod]
         public void WhiteSpaceName()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = " ",
                 Diametr = 200,
                 Chastota = 2000
             };

             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }

         [TestMethod]
         public void ExceededMaxLengthName()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "12345678901234567890123456789012345678",
                 Diametr = 200,
                 Chastota = 2000
             };

             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }

         [TestMethod]
         public void CorrectName()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "CorrectName",
                 Diametr = 200,
                 Chastota = 2000
             };

             Assert.IsTrue(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }
        #endregion
        #region Проверка поля Диаметр
         [TestMethod]
         public void LessThanZeroDiametr()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "Имя",
                 Diametr = -20,
                 Chastota = 2000
             };

             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }

         [TestMethod]
         public void ZeroDiametr()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "Имя",
                 Diametr = 0,
                 Chastota = 2000
             };

             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }

         [TestMethod]
         public void CorrectDiametr()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "Имя",
                 Diametr = 500,
                 Chastota = 2000
             };

             Assert.IsTrue(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }
        #endregion
        #region Проверка поля "Частота"
         [TestMethod]
         public void TestChastotaLessOrEqualZero()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "Имя",
                 Diametr = 200,
                 Chastota = 0
             };
             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }
         [TestMethod]
         public void TestChastotaMoreOrEqual1000000()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,
                 Name = "Имя",
                 Diametr = 200,
                 Chastota = 1000000
             };
             Assert.IsFalse(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }
         [TestMethod]
         public void TestRightChastota()
         {
             var item = new Kpo4162.Ivanov.Lib.SETI()
             {
                 Year = 2000,//значение меньше допустимого
                 Name = "Имя",
                 Diametr = 200,
                 Chastota = 2000
             };
             Assert.IsTrue(Kpo4162.Ivanov.Lib.ProjectTestHelper.ValidateFields(item));
         }
        #endregion
    }
}
