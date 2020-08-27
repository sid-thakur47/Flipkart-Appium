//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AppiumFlipkart.ExtentReport;
using AppiumFlipkart.Utils;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumFlipkart.Base
{
    /// <summary>
    /// Intialization for test class
    /// </summary>
    public class FlipkartBase
    {
        public AndroidDriver<AndroidElement> driver;
        public static ExtentReports extent = Report.GetInstance();
        public static ExtentTest test;

        /// <summary>
        /// Intialize appium options before running all test
        /// </summary>
        [OneTimeSetUp]
        public void Initialization()
        {
            AppiumOptions options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability("deviceName", "MiA1");
            options.AddAdditionalCapability("platformVersion", "Android");
            options.AddAdditionalCapability("appPackage", "com.flipkart.android");
            options.AddAdditionalCapability("appActivity", "com.flipkart.android.SplashActivity");
            options.AddAdditionalCapability("udid", "356956050704");
            options.AddAdditionalCapability("autoGrantPermissions", "true");
            Uri url = new Uri("http://127.0.0.1:4723/wd/hub");
            driver = new AndroidDriver<AndroidElement>(url, options);
        }

        /// <summary>
        /// Takes screenshot and generate report of each test
        /// </summary>
        [TearDown]
        public void Close()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string path = Utility.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                test.Log(Status.Fail, "Test Failed");
                test.AddScreenCaptureFromPath(path);
                test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                string path = Utility.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                test.Log(Status.Fail, "Test Pass");
                test.AddScreenCaptureFromPath(path);
                test.Log(Status.Pass, "Test Sucessful");
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
            }
            extent.Flush();
        }

        /// <summary>
        /// Close the applicaton and send report through email after completion of all test
        /// </summary>
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            Utility.SendEmail();
        }
    }
}