﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4162.Ivanov.Lib
{
    public class MockSETIListCommand
    {
         public MockSETIListCommand()
         {
             this._SETIList = new List<SETI>();//null;
         }
         private readonly string _dataFileName = "";
         private List<SETI> _SETIList = null;
         public List<SETI> SETIList
         {
             get { return _SETIList; }
         }
         public void Execute()
         {
             try {

                 //Фигурная скобка для ограничения области видимости переменной employee
                 {
                     SETI seti = new SETI()
                     //данная констуркция позволяет инициализировать объект при его создании
                     {
                         Year = 1960,
                         Name = "Дрейк",
                         Diametr = 26,
                         Chastota = 1420
                     };
                     SETIList.Add(seti);
                 }
                 {
                     SETI seti = new SETI()
                     //данная констуркция позволяет инициализировать объект при его создании
                     {
                         Year = 1970,
                         Name = "Троицкий",
                         Diametr = 14,
                         Chastota = 1875
                     };
                     SETIList.Add(seti);
                 }
                 {
                     SETI seti = new SETI()
                     //данная констуркция позволяет инициализировать объект при его создании
                     {
                         Year = 1978,
                         Name = "Хоровиц",
                         Diametr = 300,
                         Chastota = 1665
                     };
                     SETIList.Add(seti);
                 }
             }
             catch (Exception ex)
             {
                 Kpo4162.Ivanov.Lib.LogUtility.ErrorLog(ex);
             }
         } 
    }
}
