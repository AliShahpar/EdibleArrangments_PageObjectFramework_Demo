using System;
using NUnit.Framework;
using EA_PageObjectFramework.EA_Admin.PageActions;
using EA_PageObjectFramework.TestCases.RegressionTestSuite;
using SeleniumTest1;


namespace EA_PageObjectFramework.EAMobileTestCases
{
    [TestFixture]
    public class MainExecution
    {
        static void Main(string[] args)
        {
            /*
             * StreamWriter sw = new StreamWriter("F:\\VS-SeleniumProjectDir\\SeleniumTest1\\Test.txt");
            sw.WriteLine("##########  Error log for the HOME Page  #######");
            Console.WriteLine("Starting the execution of automation script ... ");
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            var driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://m.ediblearrangements.com/MyAccount/CreateProfile.aspx");
            Task.Delay(5000).Wait();
            var entries = driver.Manage().Logs.GetLog(LogType.Browser);
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.ToString());
                sw.WriteLine(entry.ToString());
                sw.Flush();
            }
            sw.WriteLine("##########  Error Log End's  ##########");
            sw.Flush();
            */

            // Uncomment the below method to make the ordering script to start excecution
            ScenarioEAMobile();
        }


        // [Test]
        private static void ScenarioEAMobile()
        {
            
              // kill the excel process before script execution 
              try
              {
                  var process = System.Diagnostics.Process.GetProcessesByName("Excel");
                  foreach (var p in process)
                  {
                      if (!string.IsNullOrEmpty(p.ProcessName))
                      {
                          p.Kill();
                      }
                  }
              }
              catch (Exception e)
              {
                  System.Console.WriteLine("Exception related to Excel process in the Task Manager .... " + e);
              }
              
            // first call the EA-Admin object
            /*
            AdminLoginAction adminObject = new AdminLoginAction();
            adminObject.AdminLogin();
            adminObject.Arrangements();
            adminObject.ArrangementAvailabilityStore();
            */
          
            // RegressionClass object1 = new RegressionClass();
            // object1.DesktopPickupMethod();
            
            EAMobile eaMobileObject = new EAMobile();
            eaMobileObject.MainOrderingFunction();

        }

    }
}


