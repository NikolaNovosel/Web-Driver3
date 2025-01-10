using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriver3;

namespace WebDriver3Tests;

public class Tests
{
    private IWebDriver driver;
    private CloudGooglePage cloudGooglePage;
    private readonly string url = "https://cloud.google.com/products/calculator";

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(url);
        cloudGooglePage = new CloudGooglePage(driver);
    }

    //Arange
    [TestCase("Paid: Ubuntu Pro")]
    [TestCase("n1-standard-1")]
    [TestCase("NVIDIA V100")]
    [TestCase("Number of GPUs8")]
    [TestCase("2x375 GB")]
    [TestCase("Taiwan (asia-east1)")]
    public void TestComputeEngine(string machineType)
    {
        //Act
        cloudGooglePage.ClickAddToEstimate();
        cloudGooglePage.ClickComputeEngine();
        cloudGooglePage.ClickNumberOfInstances();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickOperatingSystem();
        cloudGooglePage.ClickOperatingSystemUbuntu();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickProvisioningModel();
        cloudGooglePage.ClickMachineType();
        cloudGooglePage.ClickMachineTypeN1();
        cloudGooglePage.ClickAddGPU();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickGPUModel();
        cloudGooglePage.ClickGPUModelV100();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickNumberOfGPU();
        cloudGooglePage.ClickNumberOfGPU8();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickLocalSSD();
        cloudGooglePage.ClickLocalSSD2();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickRegion();
        cloudGooglePage.ClickRegionTaiwan();
        cloudGooglePage.Pause();
        cloudGooglePage.ClickShare();
        cloudGooglePage.ClickEstimateSummary();
        cloudGooglePage.Pause();

        //Assert
        string Clean(string input) => input.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
        string machineTypeText = cloudGooglePage.ReturnResultMachineType();
        string cleanedActual = Clean(machineTypeText);
        Assert.That(cleanedActual, Does.Contain(machineType));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
}