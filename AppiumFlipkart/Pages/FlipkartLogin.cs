//-----------------------------------------------------------------------
// <copyright file="FlipkartLogin.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AppiumFlipkart.Reader;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace AppiumFlipkart.Pages
{
    /// <summary>
    /// Stores all web elements and functionality for login into flipkart
    /// </summary>
    public class FlipkartLogin
    {
        JsonReader json = new JsonReader();
        public AndroidDriver<AndroidElement> driver;
        /// <summary>
        /// Initializes a new instance of the <see cref="FlipkartLogin"/> class.
        /// </summary>
        /// <param name="driver">control application</param>
        public FlipkartLogin(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Android elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
            "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/" +
            "android.widget.RelativeLayout/android.widget.LinearLayout[1]/androidx.recyclerview.widget.RecyclerView/" +
            "android.widget.RelativeLayout[5]/android.widget.RelativeLayout")]
        public IWebElement language;

        [FindsBy(How= How.Id, Using = "com.flipkart.android:id/select_btn")]
        public IWebElement continueButton;

        [FindsBy(How = How.Id, Using = "com.google.android.gms:id/credential_primary_label")]
        public IWebElement email;

        [FindsBy(How = How.Id, Using = "com.google.android.gms:id/cancel")]
        public IWebElement cancel;


        [FindsBy(How = How.Id, Using = "com.flipkart.android:id/tv_right_cta")]
        public IWebElement selectEmail;

        [FindsBy(How = How.Id, Using = "com.flipkart.android:id/phone_input")]
        public IWebElement input;

        [FindsBy(How = How.Id, Using = "com.flipkart.android:id/button")]
        public IWebElement continueButton2;

        /// <summary>
        /// Login into flipkart application
        /// </summary>
        public void LoginFlipkart()
        {
            Thread.Sleep(5000);
            language.Click();
            Thread.Sleep(5000);
            continueButton.Click();
            Thread.Sleep(5000);
            cancel.Click();
            Thread.Sleep(2000);
            selectEmail.Click();
            Thread.Sleep(5000);
            input.SendKeys(json.flipkartEmail);
            continueButton2.Click();
            Thread.Sleep(2000);
            input.SendKeys(json.flipkartPass);
            Thread.Sleep(2000);
            continueButton2.Click();
            Thread.Sleep(5000);
        }
    }
}
