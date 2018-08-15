using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace internationalization
{
    public partial class App : Application
    {
        
        public static string ResourceId = "internationalization.AppResources";
        
        public App()
        {
            InitializeComponent();


            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            XF.Capisoft.Internationalization.TranslateExtension.InitTranslation(ResourceId, assembly);

            // force a specific culture, useful for quick testing
            XF.Capisoft.Internationalization.TranslateExtension.OverridenCi = new CultureInfo("ja");

            //TranslateExtension.ResourceId = "internationalization.AppResources";

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
