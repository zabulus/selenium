using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClient;

namespace UIAutomationDriver
{
    class AppDriverElement : IWebElement
    {
        private readonly IDictionary<string, int> _propertyMapping = new Dictionary<string, int>
        {
            { "Value", UIA_PropertyIds.UIA_ValueValuePropertyId }
        };

        private readonly IUIAutomationElement _automationElement;

        public AppDriverElement(IUIAutomationElement automationElement)
        {
            this._automationElement = automationElement;
        }

        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public System.Drawing.Point Location => throw new NotImplementedException();

        public System.Drawing.Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            return Convert.ToString(_automationElement.GetCurrentPropertyValue(_propertyMapping[propertyName]));
        }

        public void SendKeys(string text)
        {
            var valuePattern = _automationElement.GetCurrentPattern(UIA_PatternIds.UIA_ValuePatternId) as IUIAutomationValuePattern;
            valuePattern.SetValue(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }
}
