using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenWPFApp.Services
{
    internal class LanguageManager
    {
        public static void ChangeLanguage(string cultureCode)
        {
            CultureInfo newCulture = new CultureInfo(cultureCode);

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
        }
    }
}
