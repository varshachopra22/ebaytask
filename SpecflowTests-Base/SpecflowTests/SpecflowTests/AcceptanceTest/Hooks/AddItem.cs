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
            //Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("window.scrollBy(0,1000)");

            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var btn = Driver.driver.FindElement(By.XPath("//li[@id='srp-river-results-listing1']//a[@class='s-item__link']"));
            btn.Click();


            //IWebElement searchresult = Driver.driver.FindElement(By.XPath("//div[@id='srp-river-results']"));
            //IWebElement firstitem = searchresult.FindElements(By.TagName("li"))[0];
            //Action actions = new Action(Driver.);


            //firstitem.FindElement(By.XPath("//h3[@class='s-item__title s-item__title--has-tags']")).Click();


            ///Driver.driver.FindElement(By.XPath("//ul[@class='srp-results srp-list clearfix'][@class='s-item__image-section']"));
            //Driver.driver.FindElement(By.XPath("//*[@id='item593b09b3c2']/div/div/a[1]/img"));


        }
        
        [When(@"I press add to cart")]
        public void WhenIPressAddToCart()
        {

            //adding item to cart
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.driver.FindElement(By.XPath("//*[@id='atcRedesignId_btn']")).Click();

            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IAlert alt = Driver.driver.SwitchTo().Alert();
            alt.Dismiss();
            //Driver.driver.SwitchTo().ParentFrame();
               
        }
        
        [Then(@"that item should be added to my cart")]
        public void ThenThatItemShouldBeAddedToMyCart()
        {
            //Validating if the item is added to the cart

            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string ExpectedValue = "1";
            string ActualValue = Driver.driver.FindElement(By.Id("qtyTextBox")).Text;

            if (ExpectedValue == ActualValue)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, added an item Successfully");
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "ItemAdded");
            }

            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            //Removing the item from cart
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.driver.FindElement(By.XPath("//*[@id='vi-viewInCartBtn']")).Click();

            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.driver.FindElement(By.Id("cart-remove-item")).Click();

            //Validating if the item is removed

            string msg = Driver.driver.FindElement(By.XPath("//*[@id='page-alerts']/div/div/p")).Text;
            if (msg.Contains("removed"))
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, removed an item Successfully");
                CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "ItemRemoved");
            }
            else
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
        }

    }
}
