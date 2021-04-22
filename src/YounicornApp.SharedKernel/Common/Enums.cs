using System;
using System.Collections.Generic;
using System.Text;

namespace YounicornApp.SharedKernel.Common
{
    public class Enums
    {
        public enum LoggingActionType
        {
            AboutUsRedirect = 1,
            ProviderInfoRedirect = 2,
            SelectProvider = 3,
            SelectPlan = 4,
            ComparePlans = 5,
            SignupRedirect = 6,
            SignupComplete = 7,
            ContactUsRedirect = 8,
            ContactUsSubmit = 9,
            Home = 10,
            MoreInfo=11
        }
    }
}
