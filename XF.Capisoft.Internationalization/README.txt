XF.Capisoft.Internationalization
---------------------------------------------------------------------
Small library to handle Internationaliation in Xamarin.Forms projects
---------------------------------------------------------------------
XF.Capisoft.Internationalization
XF.Capisoft.Internationalization.Android
XF.Capisoft.Internationalization.iOS
---------------------------------------------------------------------
---------------------------------------------------------------------
Usage:
---------------------------------------------------------------------
---------------------------------------------------------------------
In App.Cs file:
---------------
public static string ResourceId = "<YOUT_PACKAGE>.<YOUR_RESOURCES_FILENAME>";

Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
XF.Capisoft.Internationalization.TranslateExtension.InitTranslation(ResourceId, assembly);

// force a specific culture, useful for quick testing
XF.Capisoft.Internationalization.TranslateExtension.OverridenCi = new CultureInfo("ja");
---------------------------------------------------------------------
---------------------------------------------------------------------
Platform Specific (AppDelegate.cs || MainActivity.cs):
------------------------------------------------------
Localize.Init();
---------------------------------------------------------------------
---------------------------------------------------------------------