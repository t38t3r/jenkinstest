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
                // Men�'den aktivitelerim tu�lan�yor
                _drv.FindElementByXPath("//body[@id='body']/aside[@id='left-panel']/nav/ul/li[1]/a[1]/span[1]").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //Aktivite Y�netimi tu�lan�r
                _drv.FindElementByXPath("//span[contains(text(),'Aktivite Y�netimi')]").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //M��teri arama k�sm�na "ASD" yaz�l�r
                _drv.FindElementById("members_value").SendKeys("asd");
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Sonu�lardan "HASDEM MAK�NA VE KES�C� TARIM iML.SAN.T�C.LTD.�T�." tu�lan�r
                _drv.FindElement(By.XPath("//div[contains(text(), 'HASDEM MAK�NA VE KES�C� TARIM iML.SAN.T�C.LTD.�T�.')]")).Click();
                //Aktivite listesi tu�lan�r.
                _drv.FindElementByXPath("//select[@id='activityTypeSelectList']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Ba�vuru Formu tu�lan�r
                _drv.FindElementByXPath("//option[contains(text(),'vuru Formu')]").Click();
                //Aktivite yarat radio butonu tu�lan�r
                _drv.FindElementByXPath("//input[@name='8']").Click();
                //Planlama tarihi tu�lan�r
                _drv.FindElementByXPath("//input[@id='planDateTime']").Click();
                //��inde bulunulan g�n se�ilir
                int day = DateTime.Now.Day;
                //Takvimden i�inde bulunulan g�n se�ilir.
                _drv.FindElementByXPath("//td[contains(text(),'" + day + "')]").Click();
                //Sp listesi tu�lan�r
                _drv.FindElementByXPath("//select[@id='selectInterval']").Click();
                //Sp olarak Burcu Sulup�nar tu�lan�r
                _drv.FindElementByXPath("//option[contains(text(),'Burcu Sulup')]").Click();
                //Aktivite yarat butonu tu�lan�r.
                _drv.FindElementByXPath("//button[contains(@class,'btn btn-primary float-right')]").Click();
                //Kontrol >> Yeni yarat�lan aktivite deneti listesinde olmal� ve t�klanabilmeli
                _drv.FindElementByXPath("//button[@id='btnGroupVerticalDrop1']").Click();


            }

            //[Parallelizable]
            [Test]
            public void PlanningFilter()
            {
                //Planlama men� ad�m� tu�lan�r
                _drv.FindElementByXPath("//span[contains(text(),'Planlama')]").Click();
                //Filtre tu�lan�r
                _drv.FindElementByXPath("//i[@class='fa fa-cogs txt-color-blueDark']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Sp se� alan� tu�lan�r
                _drv.FindElementByXPath("//div[@id='s2id_salesPersonDD']").Click();
                //Sonu�tan Yunus Kulak tu�lan�r.
                _drv.FindElementByXPath("//option[contains(text(),'Yunus Kulak')]").Click();
                //Aktivite tipi tu�lan�r
                _drv.FindElementByXPath("//div[@id='s2id_typesDD']//a[@class='select2-choice']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Listeden aktivite tipi se�ilir
                _drv.FindElementByXPath("/html[1]/body[1]/div[13]/ul[1]/li[4]/div[1]").Click();
                //Ara tu�lan�r
                _drv.FindElementByXPath("//button[@class='btn btn-sm btn-primary filterButtonClass ng-scope']").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Control >> Haritadan listeye sekmesine ge�meli ve listede sonu�lar gelmeli, listedeki sonuca tu�lanabilmeli
                _drv.FindElementByXPath("//div[@class='col-md-6 col-sm-6 no-padding col-lg-6']//tr[1]//td[1]").Click();

            }
            //[Parallelizable]
            [Test]
            public void ManagementCalender()
            {
                //Y�netim men� ad�m� tu�lan�r
                _drv.FindElementByXPath("//i[@class='fa fa-briefcase fa-lg fa-fw']").Click();
                //Kullan�c� se� text box se�ilir
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _drv.FindElementByXPath("//div[@class='col col-3']").Click();
                //Aramaya "Yunus Kulak" yaz�l�r
                _drv.FindElementByClassName("select2-input").SendKeys("Yunus Kulak");
                //�lk sonu� tu�lan�r.
                _drv.FindElementById("select2-results-1").Click();
                _drv.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                //Kontrol >> Son Senkronizasyon bilgisi gelmeli, tu�lanabilmeli, alert window gelmeli..
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
                //Kontrol >> Hata mesaj�na t�klayabilme
                _drv.FindElementByXPath("//li[contains(text(),'ya da')]").Click();
                //Assert.IsNotNull(_drv.FindElementByXPath("//li[contains(text(),'ya da')]"), "Hata mesaj� gelmedi");


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
                //Kontrol >> Hata mesaj�na t�klayabilme
                _drv.FindElementByXPath("//li[contains(text(),'ya da')]").Click();
                Assert.IsNotNull(_drv.FindElementByXPath("//li[contains(text(),'ya da')]"), "Hata mesaj� gelmedi");

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
