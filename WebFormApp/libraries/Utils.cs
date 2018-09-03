using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Utils
    {
        static public string baseUrl()
        {
            HttpRequest req = HttpContext.Current.Request;
            string appPath = req.ApplicationPath.Equals("/") ? string.Empty : req.ApplicationPath;
            string baseUrl = string.Format("{0}://{1}{2}", req.Url.Scheme, req.ServerVariables["HTTP_HOST"], appPath);
            return baseUrl + "/";
        }
    }
