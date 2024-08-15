using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriver3;

namespace WebDriver3Tests;

public class Tests
{
    private IWebDriver _driver;
    private GoogleCloudCalculatorPage _calculatorPage;

    private readonly string urlProductCalculator = "https://cloud.google.com/products/calculator/?hl=en";
    private readonly string urlEstimatePreview = "https://cloud.google.com/products/calculator/estimate-preview/3c268451-c1b0-4993-8e31-89e44bc593e1";

    [SetUp]
    public void SetUp()
    {
        _driver = new EdgeDriver();
        _driver.Manage().Window.Maximize();
        _calculatorPage = new GoogleCloudCalculatorPage(_driver);
    }

    [Test]
    public void TestComputeEngine()
    {
        _driver.Navigate().GoToUrl(urlProductCalculator);
        _calculatorPage.ClickAddEstimate();
        _calculatorPage.SelectComputeEngine();
        _calculatorPage.FillForm();
        _calculatorPage.ClickShare();
        _calculatorPage.OpenEstimateSummary();
    }
    [Test]
    public void TestEstimatePreview()
    {
        _driver.Navigate().GoToUrl(urlEstimatePreview);

        string resultNumberOfInstances = _calculatorPage.ReturnNumberOfInstances();
        string expectedNumberOfnIstances = "1";
        Assert.That(expectedNumberOfnIstances, Is.EqualTo(resultNumberOfInstances));

        string resultProvisioningModel = _calculatorPage.ReturnProvisioningModel();
        string expectedProvisioningModel = "Regular";
        Assert.That(expectedProvisioningModel, Is.EqualTo(resultProvisioningModel));

        string resultAddGpus = _calculatorPage.ReturnAddGpus();
        string expectedAddGpus = "false";
        Assert.That(expectedAddGpus, Is.EqualTo(resultAddGpus));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }
}