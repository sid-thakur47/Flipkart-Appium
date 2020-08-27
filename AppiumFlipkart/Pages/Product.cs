//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace AppiumFlipkart.Pages
{
    /// <summary>
    ///  Stores all web elements and functionality for searching product and placing order in flipkart
    /// </summary>
    public class Product
    {
        public AndroidDriver<AndroidElement> driver;
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="driver">control application</param>
        public Product(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Android elements
        /// </summary>
        [FindsBy(How = How.Id, Using = "com.flipkart.android:id/search_widget_textbox")]
        public IWebElement searchBox;

        [FindsBy(How = How.Id, Using = "com.flipkart.android:id/search_autoCompleteTextView")]
        public IWebElement searchProduct;

        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/" +
            "android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
            "androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.FrameLayout/" +
            "android.widget.LinearLayout/androidx.recyclerview.widget.RecyclerView/android.widget.RelativeLayout[1]")]
        public IWebElement firstResult;

        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout" +
            "/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.FrameLayout" +
            "/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup[1]/android.widget.ScrollView" +
            "/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]")]
        public IWebElement selectProduct;

        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout" +
            "/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.FrameLayout" +
            "/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup" +
            "/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup")]
        public IWebElement goToCart;

        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout" +
            "/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.view.ViewGroup/android.widget.FrameLayout" +
            "/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup" +
            "/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]")]
        public IWebElement placeOrder;

        /// <summary>
        /// Search product and place order
        /// </summary>
        public void SearchProductAndPlaceOrder()
        {
            searchBox.Click();
            Thread.Sleep(2000);
            searchProduct.SendKeys("iphone xr");
            firstResult.Click();
            Thread.Sleep(2000);
            selectProduct.Click();
            Thread.Sleep(2000);
            goToCart.Click();
            Thread.Sleep(5000);
            placeOrder.Click();
        }
    }
}
