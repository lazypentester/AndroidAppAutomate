using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

var options = new AppiumOptions()
{
    PlatformName = "Android",
    AutomationName = "UiAutomator2",
    DeviceName = "emulator-5554"
};

options.AddAdditionalAppiumOption("udid", "emulator-5554");

options.AddAdditionalAppiumOption(
    "appPackage",
    "com.uptodown");

options.AddAdditionalAppiumOption(
    "appActivity",
    "com.uptodown.activities.MainActivity");

options.AddAdditionalAppiumOption("noReset", true);

using var driver = new AndroidDriver(
    new Uri("http://127.0.0.1:4723/"),
    options,
    TimeSpan.FromSeconds(180));

Console.WriteLine("Подключение успешно");
Console.WriteLine($"Текущая Activity: {driver.CurrentActivity}");

var menuButton = driver.FindElement(By.XPath("//android.widget.LinearLayout[@content-desc='Игры']"));

if(menuButton != null)
{
    menuButton.Click();
}

await Task.Delay(5000);

var menuButton2 = driver.FindElement(By.XPath("//android.widget.LinearLayout[@content-desc='Приложения']"));

if (menuButton2 != null)
{
    menuButton2.Click();
}

Console.ReadKey();