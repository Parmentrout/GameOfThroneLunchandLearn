using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace GameOfThrones.Helper
{
    public class CultureHelper
    {
        protected HttpSessionState sessionState;

        public CultureHelper(HttpSessionState session)
        {
            sessionState = session;
        }

        // Properties  
        public static int CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return 0;
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "nl-NL")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {

                if (value == 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                }
                else if (value == 1)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                }

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            }
        }
    }
}