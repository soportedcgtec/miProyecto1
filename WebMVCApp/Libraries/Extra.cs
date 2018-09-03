using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


public class Extra
{
    public static string baseUrl()
    {
        var request = HttpContext.Current.Request;
        var appUrl = HttpRuntime.AppDomainAppVirtualPath;

        if (appUrl != "/")
            appUrl = "/" + appUrl;

        var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

        return baseUrl;
    }

    public static T GetSetting<T>(string key, T defaultValue = default(T)) where T : IConvertible
    {
        string val = ConfigurationManager.AppSettings[key] ?? "";
        T result = defaultValue;
        if (!string.IsNullOrEmpty(val))
        {
            T typeDefault = default(T);
            if (typeof(T) == typeof(String))
            {
                typeDefault = (T)(object)String.Empty;
            }
            result = (T)Convert.ChangeType(val, typeDefault.GetTypeCode());
        }
        return result;
    }

    /*
    private string GetSetting(string key)
    {
        string sValue = "";
        try
        {
            var appSettings = ConfigurationManager.AppSettings;
            string sResult = appSettings[key];
            if (!(sResult == null)) {
                sValue = sResult;
            }
            Console.WriteLine(sResult);
        }
        catch (ConfigurationErrorsException e)
        {
            Console.WriteLine("Error reading app settings");
        }
        return sValue;
    }*/

}
