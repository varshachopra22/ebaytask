using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest.Hooks.Add
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered books in the search bar")]
        public void GivenIHaveEnteredBooksInTheSearchBar()
        {
            //Opening a new chrome browser and navigating to URL
            SpecflowPages.Utils.LoginPage.LoginStep();
            SpecflowPages.Driver.NavigateUrl();

            //Searching for books in search box
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.driver.FindElement(By.Id("gh-ac")).SendKeys("Books");
            Driver.driver.FindElement(By.Id("gh-btn")).Click();
        }
        
        [Given(@"selected the first item")]
        public void GivenSelectedTheFirstItem()
        {
            //Selecting the first item displayed
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.driver.FindElement(By.XPath("//ul[@class='srp-results srp-list clearfix'][@class='s-item__image-section']"));
            //Driver.driver.FindElement(By.XPath("//*[@id='item593b09b3c2']/div/div/a[1]/img"));

        }
        
        [When(@"I press add to cart")]
        public void WhenIPressAddToCart()
        {
            //adding item to the cart
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.driver.FindElement(By.Id("atcRedesignId_btn")).Click();
        }
        
        [Then(@"that item should be added to my cart")]
        public void ThenThatItemShouldBeAddedToMyCart()
        {
            //Validating if the item is added to the cart
            string ExpectedValue = "1";
            string ActualValue = Driver.driver.FindElement(By.Id("gh-cart-n")).Text;

            if (ExpectedValue == ActualValue)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, added an item Successfully");
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "ItemAdded");
            }

            else
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

        }
    }
}
