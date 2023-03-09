using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.Mail;
class Program
{
    static void Main(string[] args)
    {
        // Create a new WebDriver instance
        ChromeDriver driver = new ChromeDriver(@"C:\path\to\chromedriver\");

        // Navigate to the webpage you want to test
        driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

        // Find the three fields you want to test by their IDs or other locators
        IWebElement field1 = driver.FindElement(By.Id("fname"));
        IWebElement field2 = driver.FindElement(By.Id("lname"));
        IWebElement field3 = driver.FindElement(By.Id("email"));

        // Test the first field by entering text into it and verifying that the value is correct
        field1.SendKeys("Hussain");
        if (IsValidText(field1.GetAttribute("value")))
            Console.WriteLine("Field 1 test passed.");
        else
            Console.WriteLine("Field 1 test failed.");
        
        // Test the second field by clicking on it and verifying that it is focused
        field2.SendKeys("Lohawala");
        if (IsValidText(field2.GetAttribute("value")))
            Console.WriteLine("Field 2 test passed.");
        else
            Console.WriteLine("Field 2 test failed.");
        

        // Test the third field by clearing its value and verifying that it is empty
        field3.SendKeys("lohahussain0gmail.com");
        if (IsValidEmail(field3.GetAttribute("value")))
            Console.WriteLine("Field 3 test passed.");
        else
            Console.WriteLine("Field 3 test failed.");
        

        Thread.Sleep(2000);
        // Close the WebDriver instance
        driver.Quit();
    }
    
    private static bool IsValidText(string text)
    {
       for (int i = 0; i < text.Length; i++) 
         {if(Char.IsDigit(text[i]))
           return false;
         }
       return true;
    }
    private static bool IsValidEmail(string email)
    {
        var valid = true;

        try
        {
            var emailAddress = new MailAddress(email);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }
}
