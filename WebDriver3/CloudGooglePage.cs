using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace WebDriver3;
public class CloudGooglePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;
    private readonly Actions actions;
    public CloudGooglePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        actions = new Actions(driver);
    }
    private IWebElement AddToEstimate => driver.FindElement(By.XPath("//div[@class='Gxwdcd']//span[text()='Add to estimate']"));
    private IWebElement ComputeEngine => wait.Until(driver => driver.FindElement(By.XPath("//h2[text()='Compute Engine']")));
    private IWebElement OperatingSystem => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[7]//span[@class='VfPpkd-t08AT-Bz112c']"));
    private IWebElement OperatingSystemUbuntu => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[7]//span[text()='Paid: Ubuntu Pro']"));
    private IWebElement NumberOfInstances => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='BfUoNb']/div[3]//button")));
    private IWebElement ProvisioningModel => driver.FindElement(By.XPath("//label[text()='Spot (Preemptible VM)']"));
    private IWebElement MachineType =>
       driver.FindElement(By.XPath("//div[@class='U4lDT']/div[11]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]//span[@class='VfPpkd-t08AT-Bz112c']"));
    private IWebElement MachineTypeN1 =>
       wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[11]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]//span[text()='n1-standard-1']")));
    private IWebElement AddGpus => driver.FindElement(By.XPath("//button[@aria-label='Add GPUs']"));
    private IWebElement GPUModel => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[22]//span[@class='VfPpkd-t08AT-Bz112c']"))); 
    private IWebElement GPUModelV100 => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[22]//span[text()='NVIDIA V100']")));
    private IWebElement NumberOfGPU => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[23]//span[@class='VfPpkd-t08AT-Bz112c']")));
    private IWebElement NumberOfGPU8 => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[23]//span[@class='VfPpkd-rymPhb-fpDzbe-fmcmS' and text()='8']")));
    private IWebElement LocalSSD => wait.Until( driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[26]//span[@class='VfPpkd-t08AT-Bz112c']")));
    private IWebElement LocalSSD2 => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[26]//span[@class='VfPpkd-rymPhb-fpDzbe-fmcmS' and text()='2x375 GB']")));
    private IWebElement Region => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[28]//span[@class='VfPpkd-t08AT-Bz112c']")));
    private IWebElement RegionTaiwan => wait.Until(driver => driver.FindElement(By.XPath("//div[@class='U4lDT']/div[28]//span[text()='Taiwan (asia-east1)']")));
    private IWebElement Share => wait.Until(driver => driver.FindElement(By.XPath("//span[@class='FOBRw-vQzf8d' and text()='Share']")));
    private IWebElement EstimateSummary => wait.Until(driver => driver.FindElement(By.XPath("//a[text()='Open estimate summary']")));
    private IWebElement Result => driver.FindElement(By.XPath("//c-wiz"));
    public void ClickAddToEstimate() => AddToEstimate.Click();
    public void ClickComputeEngine() => ComputeEngine.Click();
    public void ClickNumberOfInstances()
    {
        for (int i = 0; i < 3; i++)
        {
            driver.ExecuteJavaScript("arguments[0].click()", NumberOfInstances);
        }
    }
    public void ClickOperatingSystem() => driver.ExecuteJavaScript("arguments[0].click()", OperatingSystem);
    public void ClickOperatingSystemUbuntu() => driver.ExecuteJavaScript("arguments[0].click()", OperatingSystemUbuntu);
    public void ClickProvisioningModel() => driver.ExecuteJavaScript("arguments[0].click()", ProvisioningModel);
    public void ClickMachineType() => driver.ExecuteJavaScript("arguments[0].click()", MachineType);
    public void ClickMachineTypeN1() => driver.ExecuteJavaScript("arguments[0].click()", MachineTypeN1);
    public void ClickAddGPU() => driver.ExecuteJavaScript("arguments[0].click()", AddGpus);
    public void ClickGPUModel() => driver.ExecuteJavaScript("arguments[0].click()", GPUModel);
    public void ClickGPUModelV100() => driver.ExecuteJavaScript("arguments[0].click()", GPUModelV100);
    public void ClickNumberOfGPU() => driver.ExecuteJavaScript("arguments[0].click()", NumberOfGPU);
    public void ClickNumberOfGPU8() => driver.ExecuteJavaScript("arguments[0].click()", NumberOfGPU8);
    public void ClickLocalSSD() => driver.ExecuteJavaScript("arguments[0].click()", LocalSSD);
    public void ClickLocalSSD2() => driver.ExecuteJavaScript("arguments[0].click()", LocalSSD2);
    public void ClickRegion() => driver.ExecuteJavaScript("arguments[0].click()", Region);
    public void ClickRegionTaiwan() => driver.ExecuteJavaScript("arguments[0].click()", RegionTaiwan);
    public void ClickShare() => driver.ExecuteJavaScript("arguments[0].click()", Share);
    public void ClickEstimateSummary() => driver.ExecuteJavaScript("arguments[0].click()", EstimateSummary);
    public string ReturnResult() => Result.Text;
    public void Pause() => actions.Pause(TimeSpan.FromMilliseconds(1000)).Perform();
}
