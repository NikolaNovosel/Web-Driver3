using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriver3;

public class GoogleCloudCalculatorPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public GoogleCloudCalculatorPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
    }
    public IWebElement AddToEstimateButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class, 'UywwFc-vQzf8d') and text()='Add to estimate']")));
    public IWebElement ComputeEngineOption => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h2[contains(@class, 'honxjf') and text()='Compute Engine']")));
    public IWebElement NumberOfInstances => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label, 'Increment')]")));
    public IWebElement ProvisioningModel => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Spot (Preemptible VM)']")));
    public IWebElement MachineTypeOption => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@aria-label='Machine type']")));
    public IWebElement MachineTypeSet => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[text()='Custom machine type']")));
    public IWebElement AddGpus => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@aria-label='Add GPUs']")));
    public IWebElement ShareButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class, 'FOBRw-vQzf8d') and text()='Share']")));
    public IWebElement EstimateSummaryTab => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Open estimate summary')]")));
    public IWebElement CheckNumberOfInstancesDiv => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.wZCOB > :nth-child(5)")));
    public IWebElement CheckNumberOfInstancesSpan => CheckNumberOfInstancesDiv.FindElement(By.XPath(".//span/span[2]"));
    public IWebElement CheckProvisioningModelDiv => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.wZCOB > :nth-child(7)")));
    public IWebElement CheckProvisioningModelSpan => CheckProvisioningModelDiv.FindElement(By.XPath(".//span/span[2]"));
    public IWebElement CheckAddGpusDiv => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.wZCOB > :nth-child(11)")));
    public IWebElement CheckAddGpusSpan => CheckAddGpusDiv.FindElement(By.XPath(".//span/span[2]"));

    public void ClickAddEstimate() => AddToEstimateButton.Click();
    public void SelectComputeEngine() => ComputeEngineOption.Click();

    public void FillForm()
    {
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", NumberOfInstances);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", NumberOfInstances);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", NumberOfInstances);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ProvisioningModel);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", AddGpus);
    }

    public void ClickShare() => ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ShareButton);

    public void OpenEstimateSummary() => ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", EstimateSummaryTab);


    public string ReturnNumberOfInstances()
    {
        return CheckNumberOfInstancesSpan.Text;
    }
    public string ReturnProvisioningModel()
    {
        return CheckProvisioningModelSpan.Text;
    }
    public string ReturnAddGpus()
    {
        return CheckAddGpusSpan.Text;
    }
}
