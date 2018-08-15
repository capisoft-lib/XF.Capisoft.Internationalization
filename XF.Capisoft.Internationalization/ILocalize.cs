using System;
using System.Globalization;

namespace XF.Capisoft.Internationalization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
