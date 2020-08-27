//-----------------------------------------------------------------------
// <copyright file="Utility.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AppiumFlipkart.CustomException;
using AppiumFlipkart.Reader;
using OpenQA.Selenium;
using System;
using System.Net;
using System.Net.Mail;

namespace AppiumFlipkart.Utils
{
    /// <summary>
    /// To store all required functionality 
    /// </summary>
    public class Utility
    {


        /// <summary>
        /// To take screenshot after every test
        /// </summary>
        /// <param name="driver">to control browser</param>
        /// <param name="testStatus">failed or passed test</param>
        /// <returns></returns>
        public static string TakeScreenshot(IWebDriver driver, string testStatus)
        {
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string finalPath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + testStatus + ".png";
                string localPath = new Uri(finalPath).LocalPath;
                screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
                return localPath;
            }
            catch (Exception)
            {
                throw new Exceptions("Screenshot error", Exceptions.ExceptionType.SCRRENSHOT_NOT_CAPTURED);
            }
        }
            /// <summary>
            /// To send report to specified email address
            /// </summary>
            public static void SendEmail()
            {
            try
            {
                JsonReader reader = new JsonReader();
                MailMessage mail = new MailMessage();
                string ToEmail = "sidthakur258@gmail.com";
                mail.From = new MailAddress("sidthakur6433@gmail.com");
                mail.Subject = "Please check the attached report";
                mail.To.Add(ToEmail);
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\Users\sidth\source\repos\AppiumFlipkart\AppiumFlipkart\ExtentReport\index.html"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(reader.email, reader.password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                throw new Exceptions("Email error", Exceptions.ExceptionType.EMAIL_NOT_SEND);
            }
        }
    }
}
