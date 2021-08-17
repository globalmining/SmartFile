using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
namespace FileManagementApp
{
    public class SessionProxyUser
    {
        public const string ISUSERLOGIN = "IsUserLogin";
     
        private SessionProxyUser()
        {

        }

        //public static SessionProxyUser Current
        //{
        //    get
        //    {
        //        SessionProxyUser sessionProxy = (SessionProxyUser)HttpContext.Current.Session["__ApplicationSessionAdmin__"];
        //        if (sessionProxy == null)
        //        {
        //            sessionProxy = new SessionProxyUser();
        //            HttpContext.Current.Session["__ApplicationSessionAdmin__"] = sessionProxy;
        //        }
        //        return sessionProxy;
        //    }
        //    set { SessionProxyUser mysession = (SessionProxyUser)value; }
        //}
    
        //public static bool IsUserLogin
        //{
        //    get
        //    {
        //        return Convert.ToBoolean(HttpContext.Current.Session[ISUSERLOGIN]);
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session[ISUSERLOGIN] = value;
        //    }
        //}
      
    }
}
