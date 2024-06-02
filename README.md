![image](https://github.com/Leralera050505/Var15/assets/107068589/71e3f249-dd98-4acd-a964-df055188ea0f)
TEST

Решение - проект модульного теста - пишем

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PriceWithDiscountTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void price100discount005num95()
        {
            //arrange -- обьявляем 
            decimal price = 100;
            decimal discount = (Decimal)0.05;
            decimal num = 95;

            //Act -- производим действие 

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);
          //  price - (price * discount) КЛАСС В ПРИЛОЖЕНИИ

            //Assert -- проверяем

            Assert.AreEqual(price, num);
        }
