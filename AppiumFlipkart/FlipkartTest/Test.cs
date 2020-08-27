//-----------------------------------------------------------------------
// <copyright file="Test.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AppiumFlipkart.Base;
using AppiumFlipkart.Pages;
using NUnit.Framework;

namespace AppiumFlipkart.FlipkartTest
{
    public  class Test : FlipkartBase
    {
        /// <summary>
        /// Login to flipkart account
        /// </summary>
        [Test, Order(1)]
        public void LoginTest()
        {
            FlipkartLogin login = new FlipkartLogin(driver);
            login.LoginFlipkart();
        }

        /// <summary>
        /// search product and place order
        /// </summary>
        [Test, Order(2)]
        public void SearchAndPlaceOrderTest()
        {
            Product product = new Product(driver);
            product.SearchProductAndPlaceOrder();
        }
    }
}
