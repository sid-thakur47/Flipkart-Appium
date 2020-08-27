using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AppiumFlipkart.ExtentReport
{
    public class Report
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        /// <summary>
        /// To get instance of extent report
        /// </summary>
        /// <returns> extent class object</returns>
        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string reportPath = @"C:\Users\sidth\source\repos\AppiumFlipkart\AppiumFlipkart\ExtentReport\Report.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}
