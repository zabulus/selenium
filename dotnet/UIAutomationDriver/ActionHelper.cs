using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomationClient;

namespace UIAutomationDriver
{
    internal static class ActionHelper
    {
        internal static T UltimatelyDo<T>(Func<T> p)
        {
            for (; ; )
            {
                try
                {
                    var ret = p();
                    return ret;
                }
                catch { }
            }
        }
    }
}
