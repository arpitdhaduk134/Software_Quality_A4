using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void InsuranceQuote_Age24_Exp3_Accidents0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "24", "3", "0");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_Age25_Exp3_Accidents4()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "25", "3", "4");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        [Test]
        public void InsuranceQuote_Age35_Exp9_Accidents2()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "35", "9", "2");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_InvalidPhoneNumber()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123", "john.doe@mail.com", "30", "5", "1");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Invalid phone number format");
        }

        [Test]
        public void InsuranceQuote_InvalidEmailAddress()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe", "30", "5", "1");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Invalid email address format");
        }

        [Test]
        public void InsuranceQuote_InvalidPostalCode()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L3G1", "123-123-1234", "john.doe@mail.com", "30", "5", "1");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Invalid postal code format");
        }

        [Test]
        public void InsuranceQuote_AgeOmitted()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "", "5", "1");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Age is required");
        }

        [Test]
        public void InsuranceQuote_AccidentsOmitted()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "30", "5", "");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Number of accidents is required");
        }

        [Test]
        public void InsuranceQuote_ExpOmitted()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "30", "", "1");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Driving experience is required");
        }

        [Test]
        public void InsuranceQuote_Age70_Exp1_Accidents1()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "70", "1", "1");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        [Test]
        public void InsuranceQuote_Age16_Exp0_Accidents0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "16", "0", "0");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        [Test]
        public void InsuranceQuote_Age30_Exp2_Accidents0_RateReduction()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "30", "2", "0");
            ClickSubmitButton();
            VerifyInsuranceRateReduced();
        }

        [Test]
        public void InsuranceQuote_Age40_Exp20_Accidents3()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "40", "20", "3");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_Age50_Exp30_Accidents0_RateReduction()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "50", "30", "0");
            ClickSubmitButton();
            VerifyInsuranceRateReduced();
        }

        [Test]
        public void InsuranceQuote_Age60_Exp40_Accidents5()
        {
            driver.Navigate().GoToUrl("http://localhost/prog8171a04/getQuote.html");
            FillOutForm("A", "D", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "60", "40", "5");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        private void FillOutForm(string firstName, string lastName, string address, string city, string province, string postalCode, string phoneNumber, string email, string age, string experience, string accidents)
        {
            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);
            driver.FindElement(By.Id("province")).SendKeys(province);
            driver.FindElement(By.Id("postalCode")).SendKeys(postalCode);
            driver.FindElement(By.Id("phoneNumber")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("age")).SendKeys(age);
            driver.FindElement(By.Id("experience")).SendKeys(experience);
            driver.FindElement(By.Id("accidents")).SendKeys(accidents);
        }

        private void ClickSubmitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }

        private void VerifyInsuranceProvided()
        {
            string resultText = driver.FindElement(By.Id("result")).Text;
            ClassicAssert.IsTrue(resultText.Contains("Insurance Provided: Yes"));
        }

        private void VerifyInsuranceRefused()
        {
            string resultText = driver.FindElement(By.Id("result")).Text;
            ClassicAssert.IsTrue(resultText.Contains("Insurance Provided: No"));
        }

        private void VerifyInsuranceRateReduced()
        {
            string resultText = driver.FindElement(By.Id("result")).Text;
            ClassicAssert.IsTrue(resultText.Contains("Insurance Rate Reduced"));
        }

        private void VerifyProperErrorMessageDisplayed(string errorMessage)
        {
            string resultText = driver.FindElement(By.Id("result")).Text;
            ClassicAssert.IsTrue(resultText.Contains(errorMessage));
        }
    }
}
