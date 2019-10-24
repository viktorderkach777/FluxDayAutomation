﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using FluxDayAutomation.Drivers;
using FluxDayAutomation.PageObjects;
using System;

namespace FluxDayAutomation.UITests
{
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, SelenoidDrivers.FIREFOX, SelenoidDrivers.FIREFOX_V1)]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, SelenoidDrivers.FIREFOX, SelenoidDrivers.FIREFOX_V2)]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, SelenoidDrivers.CHROME, SelenoidDrivers.CHROME_V1)]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, SelenoidDrivers.CHROME, SelenoidDrivers.CHROME_V2)]
    [TestFixture(EMPLOYEE_EMAIL, EMPLOYEE_PASSWORD, EMPLOYEE_USER_NAME, SelenoidDrivers.FIREFOX, SelenoidDrivers.FIREFOX_V1)]
    [TestFixture(EMPLOYEE_EMAIL, EMPLOYEE_PASSWORD, EMPLOYEE_USER_NAME, SelenoidDrivers.FIREFOX, SelenoidDrivers.FIREFOX_V2)]
    [TestFixture(EMPLOYEE_EMAIL, EMPLOYEE_PASSWORD, EMPLOYEE_USER_NAME, SelenoidDrivers.CHROME, SelenoidDrivers.CHROME_V1)]
    [TestFixture(EMPLOYEE_EMAIL, EMPLOYEE_PASSWORD, EMPLOYEE_USER_NAME, SelenoidDrivers.CHROME, SelenoidDrivers.CHROME_V2)]
    [Category("AddNewOKR")]
    public class AddNewOKRUITest
    {
        private const int IMPLICIT_WAIT_SECONDS = 15;
        private const string APPLICATION_URL = "https://app.fluxday.io/users/sign_in";
        private const string MANAGER_USER_NAME = "Admin User";
        private const string MANAGER_EMAIL = "admin@fluxday.io";
        private const string MANAGER_PASSWORD = "password";
        private const string EMPLOYEE_USER_NAME = "Employee 1";
        private const string EMPLOYEE_EMAIL = "emp1@fluxday.io";
        private const string EMPLOYEE_PASSWORD = "password";
        private const string OKR_NAME = "Test OKR";
        private const string OBJECTIVE_NAME = "Ambition";
        private const string KEY_RESULT_FIRST = "1";
        private const string KEY_RESULT_SECOND = "2";

        private IWebDriver driver = null;        

        private LoginPageObject login = null;
        private SideBarMenuPageObject sideBarMenu = null;
        private OKRListPageObject OKRList = null;
        private SetOKRPageObject setOKR = null;
        private ApproveOKRPageObject deleteOKR = null;

        private string email = null;
        private string password = null;
        private string userName = null;

        public AddNewOKRUITest(string email, string password, string userName, string browser, string version)
        {
            this.email = email;
            this.password = password;
            this.userName = userName;
            this.driver = SelenoidDrivers.CreateDriver(browser, version);
        }

        [SetUp, Description("Local and CI browser configurations, pre-conditions")]
        public void BeforeAllMethods()
        {
            // General driver configuration
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_WAIT_SECONDS);
            driver.Navigate().GoToUrl(APPLICATION_URL);

            // Applied Page Objects
            login = new LoginPageObject(driver);
            sideBarMenu = new SideBarMenuPageObject(driver);
            OKRList = new OKRListPageObject(driver);
            setOKR = new SetOKRPageObject(driver);
            deleteOKR = new ApproveOKRPageObject(driver);

            // Login into system
            login.UserEmailTextBox.Click();
            login.UserEmailTextBox.Clear();
            login.UserEmailTextBox.SendKeys(email.ToString());
            login.UserPasswordTextBox.Click();
            login.UserPasswordTextBox.Clear();
            login.UserPasswordTextBox.SendKeys(password);
            login.LoginButton.Click();

            // Navigate to OKR Page
            sideBarMenu.OKRItem.Click();

            // Click button "New OKR"
            OKRList.NewOKRButton.Click();
        }

        [TearDown, Description("Cleaning, logout and close browser")]
        public void AfterAllMethods()
        {
            // Сleaning (removal of created OKR) if user role = Manager
            if (OKRList.OKRsList[OKRList.OKRsList.Count - 1].TitleLabel.Text == OKR_NAME
                && sideBarMenu.UserNameItem.Text == MANAGER_USER_NAME)
            {
                OKRList.OKRsList[OKRList.OKRsList.Count - 1].OKRCardLink.Click();
                deleteOKR.SettingsButton.Click();
                deleteOKR.SettingsMenu.DeleteMenuItem.Click();
                driver.SwitchTo().Alert().Accept();
            }
            new SideBarMenuPageObject(driver).LogoutItem.Click();
            driver.Quit();
        }

        [Test, Description("This test case verifies the possibility to create OKR by manager and employee")]
        public void AddNewOKRTest()
        {
            // Add new OKR UI Test
            setOKR.OKRNameField.Click();
            setOKR.OKRNameField.Clear();
            setOKR.OKRNameField.SendKeys(OKR_NAME);

            setOKR.ObjectivesList[0].ObjectiveNameField.Click();
            setOKR.ObjectivesList[0].ObjectiveNameField.Clear();
            setOKR.ObjectivesList[0].ObjectiveNameField.SendKeys(OBJECTIVE_NAME);

            setOKR.ObjectivesList[0].KeyResultsList[0].KeyResultField.Click();
            setOKR.ObjectivesList[0].KeyResultsList[0].KeyResultField.Clear();
            setOKR.ObjectivesList[0].KeyResultsList[0].KeyResultField.SendKeys(KEY_RESULT_FIRST);

            setOKR.ObjectivesList[0].KeyResultsList[1].KeyResultField.Click();
            setOKR.ObjectivesList[0].KeyResultsList[1].KeyResultField.Clear();
            setOKR.ObjectivesList[0].KeyResultsList[1].KeyResultField.SendKeys(KEY_RESULT_SECOND);

            setOKR.SaveButton.Click();

            // Result of addition OKR
            Assert.AreEqual(OKR_NAME,OKRList.OKRsList[OKRList.OKRsList.Count-1].TitleLabel.Text);
        }
    }
}
