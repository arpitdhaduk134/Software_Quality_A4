using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class InsuranceQuoteTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up WebDriver
            driver.Quit();
        }

        [Test]
        public void InsuranceQuote_ValidData_Age24_Exp3_Accidents0()
        {
            // Test Case 1: Insurance Quote with Valid Data - Age 24, Driving Experience 3, Accidents 0
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "24", "3", "0");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_Age25_Exp3_Accidents4()
        {
            // Test Case 2: Insurance Quote - Age 25, Driving Experience 3, Accidents 4
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "25", "3", "4");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        [Test]
        public void InsuranceQuote_Age35_Exp9_Accidents2()
        {
            // Test Case 3: Insurance Quote - Age 35, Driving Experience 9, Accidents 2
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "35", "9", "2");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_InvalidPhoneNumber()
        {
            // Test Case 4: Insurance Quote with Invalid Phone Number
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123456789", "john.doe@mail.com", "27", "3", "0");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Invalid phone number format");
        }

        [Test]
        public void InsuranceQuote_InvalidEmail()
        {
            // Test Case 5: Insurance Quote with Invalid Email
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "johndoe@mailcom", "28", "3", "0");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Invalid email address");
        }

        [Test]
        public void InsuranceQuote_InvalidPostalCode()
        {
            // Test Case 6: Insurance Quote with Invalid Postal Code
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "12345", "123-123-1234", "john.doe@mail.com", "35", "15", "1");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Invalid postal code format");
        }

        [Test]
        public void InsuranceQuote_OmitAge()
        {
            // Test Case 7: Insurance Quote with Age Omitted
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "", "5", "0");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Age is required");
        }

        [Test]
        public void InsuranceQuote_OmitAccidents()
        {
            // Test Case 8: Insurance Quote with Accidents Omitted
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "37", "8", "");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Accidents is required");
        }

        [Test]
        public void InsuranceQuote_OmitExperience()
        {
            // Test Case 9: Insurance Quote with Driving Experience Omitted
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("John", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "john.doe@mail.com", "45", "", "0");
            ClickSubmitButton();
            VerifyProperErrorMessageDisplayed("Driving experience is required");
        }

        [Test]
        public void InsuranceQuote_Age60_Exp20_Accidents0()
        {
            // Test Case 10: Insurance Quote with Age 60, Driving Experience 20, Accidents 0
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("Jane", "Doe", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "jane.doe@mail.com", "60", "20", "0");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_Age50_Exp40_Accidents2()
        {
            // Test Case 11: Insurance Quote with Age 50, Driving Experience 40, Accidents 2
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("Alice", "Smith", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "alice.smith@mail.com", "50", "40", "2");
            ClickSubmitButton();
            VerifyInsuranceProvided();
        }

        [Test]
        public void InsuranceQuote_Age70_Exp1_Accidents1()
        {
            // Test Case 12: Insurance Quote with Age 70, Driving Experience 1, Accidents 1
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("Bob", "Johnson", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "bob.johnson@mail.com", "70", "1", "1");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        [Test]
        public void InsuranceQuote_Age16_Exp0_Accidents0()
        {
            // Test Case 13: Insurance Quote with Age 16, Driving Experience 0, Accidents 0
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("Emma", "Brown", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "emma.brown@mail.com", "16", "0", "0");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        [Test]
        public void InsuranceQuote_Age30_Exp2_Accidents0_RateReduction()
        {
            // Test Case 14: Insurance Quote with Age 30, Driving Experience 2, Accidents 0 - Rate Reduction
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("Michael", "Wilson", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "michael.wilson@mail.com", "30", "2", "0");
            ClickSubmitButton();
            VerifyInsuranceWithRateReduction();
        }

        [Test]
        public void InsuranceQuote_Age25_Exp5_Accidents3()
        {
            // Test Case 15: Insurance Quote with Age 25, Driving Experience 5, Accidents 3
            driver.Navigate().GoToUrl("http://localhost/prog8170a04");
            FillOutForm("Sarah", "Jones", "123 Main St", "Anytown", "Ontario", "N2L 3G1", "123-123-1234", "sarah.jones@mail.com", "25", "5", "3");
            ClickSubmitButton();
            VerifyInsuranceRefused();
        }

        // Helper methods

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
            Assert.IsTrue(resultText.Contains("Insurance Provided: Yes"));
        }

        private void VerifyInsuranceRefused()
        {
            string resultText = driver.FindElement(By.Id("result")).Text;
            Assert.IsTrue(resultText.Contains("Insurance Provided: No"));
        }

        private void VerifyProperErrorMessageDisplayed(string expectedErrorMessage)
        {
            string errorMessage = driver.FindElement(By.Id("errorMessage")).Text;
            Assert.IsTrue(errorMessage.Contains(expectedErrorMessage));
        }

        private void VerifyInsuranceWithRateReduction()
        {
            string resultText = driver.FindElement(By.Id("result")).Text;
            Assert.IsTrue(resultText.Contains("Insurance Provided: Yes"));
            Assert.IsTrue(resultText.Contains("Rate Reduction: Yes"));
        }
    }
}
