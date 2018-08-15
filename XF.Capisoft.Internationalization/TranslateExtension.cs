using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Capisoft.Internationalization
{
    // You exclude the 'Extension' suffix when using in XAML
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public static CultureInfo OverridenCi { get; set; } = null;
        public static CultureInfo ci { get; set; } = null;
        public static string ResourceId = "XF.Capisoft.Internationalization.MyResources";
        public static Assembly Assembly;

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(
            () => new ResourceManager(ResourceId, Assembly));

        public string Text { get; set; }

        public static void InitTranslation(string resource, Assembly assembly){
            ResourceId = resource;
            Assembly = assembly;
        }

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                if (OverridenCi == null)
                {
                    ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                }else{
                    ci = OverridenCi;
                }
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var translation = ResMgr.Value.GetString(Text, ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
            translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}