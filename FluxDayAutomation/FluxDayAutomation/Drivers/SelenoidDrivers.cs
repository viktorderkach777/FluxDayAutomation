using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Drawing;

namespace FluxDayAutomation.Drivers
{
    static public class SelenoidDrivers 
    {
        public const string CHROME = "chrome";
        public const string FIREFOX = "firefox";
        public const string CHROME_V1 = "76.0";
        public const string CHROME_V2 = "77.0";
        public const string FIREFOX_V1 = "68.0";
        public const string FIREFOX_V2 = "69.0";
        private const bool ENABLE_VNC = true;
        private const int BROWSER_WIDTH = 1920;
        private const int BROWSER_HEIGHT = 1080;
        private const string URI = "http://34.70.15.20:4444/wd/hub";

        static public IWebDriver CreateDriver(string browser, string version)
        {
            var capabilities = new DesiredCapabilities(browser, version, new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", ENABLE_VNC);
            var driver = new RemoteWebDriver(new Uri(URI), capabilities);
            driver.Manage().Window.Size = new Size(BROWSER_WIDTH, BROWSER_HEIGHT);
            return driver;
        }
    }
}
