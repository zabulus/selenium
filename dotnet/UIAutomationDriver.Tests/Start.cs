using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UIAutomationDriver.Tests
{
    public class Start
    {
        [Fact]
        public void Lifetimes()
        {
            using (var driver = new AppDriver("notepad.exe"))
            {
                var editBox = driver.FindElement(By.ClassName("Edit"));
                editBox.SendKeys("Entered text");
                var text = editBox.GetProperty("Value");
                Assert.Equal("Entered text", text);
            }
        }
        [Fact]
        public void ByName()
        {
            using (var driver = new AppDriver("notepad.exe"))
            {
                var editBox = driver.FindElement(By.Name("Edit"));
                editBox.SendKeys("Entered text");
                var text = editBox.GetProperty("Value");
                Assert.Equal("Entered text", text);
            }
        }
    }
}
