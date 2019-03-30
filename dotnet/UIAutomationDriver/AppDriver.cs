using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClient;

namespace UIAutomationDriver
{
    public class AppDriver : IWebDriver
        , IFindsByClassName
        , IFindsByName
    {
        private readonly Process process;
        private readonly IUIAutomation uIAutomation;
        private readonly IUIAutomationElement _mainWindowElement;

        public AppDriver(string processName)
        {
            process = Process.Start(processName);
            uIAutomation = new CUIAutomationClass();
            _mainWindowElement = ActionHelper.UltimatelyDo(() => uIAutomation.ElementFromHandle(process.MainWindowHandle));
        }

        public AppDriver(int pid)
        {
            process = Process.GetProcessById(pid);
        }

        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Title => throw new NotImplementedException();

        public string PageSource => throw new NotImplementedException();

        public string CurrentWindowHandle => throw new NotImplementedException();

        public ReadOnlyCollection<string> WindowHandles => throw new NotImplementedException();

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            process.Kill();
            process.WaitForExit();
        }

        public IWebElement FindElement(By by)
        {
            if (by == null)
            {
                throw new ArgumentNullException("by", "by cannot be null");
            }

            return by.FindElement(this);
        }

        public IWebElement FindElementByClassName(string className)
        {
            var condition = uIAutomation.CreatePropertyCondition(UIA_PropertyIds.UIA_ClassNamePropertyId, className);
            return new AppDriverElement(_mainWindowElement.FindFirst(TreeScope.TreeScope_Children, condition));
        }

        public IWebElement FindElementByName(string name)
        {
            var condition = uIAutomation.CreatePropertyCondition(UIA_PropertyIds.UIA_NamePropertyId, name);
            return new AppDriverElement(_mainWindowElement.FindFirst(TreeScope.TreeScope_Children, condition));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IOptions Manage()
        {
            throw new NotImplementedException();
        }

        public INavigation Navigate()
        {
            throw new NotImplementedException();
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }

        public ITargetLocator SwitchTo()
        {
            throw new NotImplementedException();
        }
    }
}
