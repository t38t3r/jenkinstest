using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using TestContext = NUnit.Framework.TestContext;
using Assert = NUnit.Framework.Assert;
using NUnit.Framework.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestFixture]
        public class TuvPed
        {
            private ChromeDriver _drv;

            [SetUp]
            public void InitializeDriverAndLogin()
            {
                _drv = new ChromeDriver();
                //Go to rutisttest
                _drv.Navigate().GoToUrl("https://rutisttest.bestera.com.tr/");
                //Enter login credentials
                _drv.FindElementById("email").SendKeys("burcu.sulupinar@tuv.at");
                _drv.FindElementByName("Password").SendKeys("Abcd1234!");
                //Press login button
                _drv.FindElementByXPath("//button[@class='btn btn-primary']").Click();
            }

            //[Parallelizable]
            [Test]
            public void CreateActivity()
            {
                // Menü'den aktivitelerim tuþlanýyor
                _drv.FindElementByXPath("//body[@id='body']/aside[@id='left-panel']/nav/ul/li[1]/a[1]/span[1]").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //Aktivite Yönetimi tuþlanýr
                _drv.FindElementByXPath("//span[contains(text(),'Aktivite Yönetimi')]").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //Müþteri arama kýsmýna "ASD" yazýlýr
                _drv.FindElementById("members_value").SendKeys("asd");
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Sonuçlardan "HASDEM MAKÝNA VE KESÝCÝ TARIM iML.SAN.TÝC.LTD.ÞTÝ." tuþlanýr
                _drv.FindElement(By.XPath("//div[contains(text(), 'HASDEM MAKÝNA VE KESÝCÝ TARIM iML.SAN.TÝC.LTD.ÞTÝ.')]")).Click();
                //Aktivite listesi tuþlanýr.
                _drv.FindElementByXPath("//select[@id='activityTypeSelectList']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Baþvuru Formu tuþlanýr
                _drv.FindElementByXPath("//option[contains(text(),'vuru Formu')]").Click();
                //Aktivite yarat radio butonu tuþlanýr
                _drv.FindElementByXPath("//input[@name='8']").Click();
                //Planlama tarihi tuþlanýr
                _drv.FindElementByXPath("//input[@id='planDateTime']").Click();
                //Ýçinde bulunulan gün seçilir
                int day = DateTime.Now.Day;
                //Takvimden içinde bulunulan gün seçilir.
                _drv.FindElementByXPath("//td[contains(text(),'" + day + "')]").Click();
                //Sp listesi tuþlanýr
                _drv.FindElementByXPath("//select[@id='selectInterval']").Click();
                //Sp olarak Burcu Sulupýnar tuþlanýr
                _drv.FindElementByXPath("//option[contains(text(),'Burcu Sulup')]").Click();
                //Aktivite yarat butonu tuþlanýr.
                _drv.FindElementByXPath("//button[contains(@class,'btn btn-primary float-right')]").Click();
                //Kontrol >> Yeni yaratýlan aktivite deneti listesinde olmalý ve týklanabilmeli
                _drv.FindElementByXPath("//button[@id='btnGroupVerticalDrop1']").Click();


            }

            //[Parallelizable]
            [Test]
            public void PlanningFilter()
            {
                //Planlama menü adýmý tuþlanýr
                _drv.FindElementByXPath("//span[contains(text(),'Planlama')]").Click();
                //Filtre tuþlanýr
                _drv.FindElementByXPath("//i[@class='fa fa-cogs txt-color-blueDark']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Sp seç alaný tuþlanýr
                _drv.FindElementByXPath("//div[@id='s2id_salesPersonDD']").Click();
                //Sonuçtan Yunus Kulak tuþlanýr.
                _drv.FindElementByXPath("//option[contains(text(),'Yunus Kulak')]").Click();
                //Aktivite tipi tuþlanýr
                _drv.FindElementByXPath("//div[@id='s2id_typesDD']//a[@class='select2-choice']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Listeden aktivite tipi seçilir
                _drv.FindElementByXPath("/html[1]/body[1]/div[13]/ul[1]/li[4]/div[1]").Click();
                //Ara tuþlanýr
                _drv.FindElementByXPath("//button[@class='btn btn-sm btn-primary filterButtonClass ng-scope']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Control >> Haritadan listeye sekmesine geçmeli ve listede sonuçlar gelmeli, listedeki sonuca tuþlanabilmeli
                _drv.FindElementByXPath("//div[@class='col-md-6 col-sm-6 no-padding col-lg-6']//tr[1]//td[1]").Click();

            }
            //[Parallelizable]
            [Test]
            public void ManagementCalender()
            {
                //Yönetim menü adýmý tuþlanýr
                _drv.FindElementByXPath("//i[@class='fa fa-briefcase fa-lg fa-fw']").Click();
                //Kullanýcý seç text box seçilir
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _drv.FindElementByXPath("//div[@class='col col-3']").Click();
                //Aramaya "Yunus Kulak" yazýlýr
                _drv.FindElementByClassName("select2-input").SendKeys("Yunus Kulak");
                //Ýlk sonuç tuþlanýr.
                _drv.FindElementById("select2-results-1").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //Kontrol >> Son Senkronizasyon bilgisi gelmeli, tuþlanabilmeli, alert window gelmeli..
                _drv.FindElementByXPath("//i[@class='ng-binding']").Click();
                _drv.SwitchTo().Alert().Accept();


            }
            //[Parallelizable]
            [Test]
            public void WrongPassword()
            {
                _drv.FindElementByXPath("//i[@class='fa fa-sign-out']").Click();
                _drv.FindElementByCssSelector("#bot2-Msg1").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //Enter Wrong login credentials
                _drv.FindElementById("email").SendKeys("burcu.sulupinar@tuv.at");
                _drv.FindElementByName("Password").SendKeys("Abcd1sdfg234!");
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //Press login button
                _drv.FindElementByXPath("//button[@class='btn btn-primary']").Click();
                //Kontrol >> Hata mesajýna týklayabilme
                _drv.FindElementByXPath("//li[contains(text(),'ya da')]").Click();
                //Assert.IsNotNull(_drv.FindElementByXPath("//li[contains(text(),'ya da')]"), "Hata mesajý gelmedi");


            }

            [TearDown]
            public void CloseAndTakeScreenShot()
            {

                string testname = TestContext.CurrentContext.Test.Name;
                //Take screenShot on test fails.
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    _drv.GetScreenshot()
                   .SaveAsFile("D:\\TestResults" + testname + " Failed.png");
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    _drv.GetScreenshot()
                  .SaveAsFile("D:\\TestResults" + testname + " Passed.png");
                }


                //Close the driver
                _drv.Quit();

            }




        }
        public class WithoutSetupAndTearDown
        {
            private ChromeDriver _drv;

            [Test]

            public void WrongPassword()
            {

                _drv = new ChromeDriver();
                //Go to rutisttest
                _drv.Navigate().GoToUrl("https://rutisttest.bestera.com.tr/");
                //Enter login credentials
                _drv.FindElementById("email").SendKeys("burcu.sulupinar@tuv.at");
                _drv.FindElementByName("Password").SendKeys("Abcasdd1234!");
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //Press login button
                _drv.FindElementByXPath("//button[@class='btn btn-primary']").Click();
                //Kontrol >> Hata mesajýna týklayabilme
                _drv.FindElementByXPath("//li[contains(text(),'ya da')]").Click();
                Assert.IsNotNull(_drv.FindElementByXPath("//li[contains(text(),'ya da')]"), "Hata mesajý gelmedi");

            }

            [Test]
            public void performActionsByWorksheet()
            {
                string excelFilePath = TestContext.Parameters["excelFilePath"];
                string worksheetName = TestContext.Parameters["worksheetName"];
                TestContext.WriteLine(excelFilePath);
                TestContext.WriteLine(worksheetName);
            }

        }

    }
}
