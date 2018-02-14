
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;

namespace ServiceApi.Service
{
     [Serializable]
    public  class ApplicationContext : Dictionary<string, object>
    {
        private const string CallContextKey = "__ApplicationContext";
        internal const string ContextHeaderLocalName = "__ApplicationContext";
        internal const string ContextHeaderNamespace = "www.meilituibian.cn";

        public new object this[string key]
        {
            get { return base[key]; }
            set
            {
                this.EnsureSerializable(value);
                base[key] = value;
            }
        }
        public long UserId
        {
            get { return (long)this["__UserId"]; }
            set { this["__UserId"] = value; }
        }

        public string OpenId
        {
            get { return (string)this["__OpenId"]; }
            set { this["__OpenId"] = value; }
        }

        public string SalesOpenId
        {
            get { return (string)this["__SalesOpenId"]; }
            set { this["__SalesOpenId"] = value; }
        }

        public string UserHeadImg
        {
            get { return (string)this["__UserHeadImg"]; }
            set { this["__UserHeadImg"] = value; }
        }


        public static ApplicationContext Current
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    if (CallContext.GetData(CallContextKey) == null)
                    {
                        CallContext.SetData(CallContextKey, new ApplicationContext());
                    }
                    return CallContext.GetData(CallContextKey) as ApplicationContext;
                }
                else
                {
                    //if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.Session != null)
                    if (HttpContext.Current.Session[CallContextKey] != null)
                    {
                        return (ApplicationContext)HttpContext.Current.Session[CallContextKey];
                    }
                    else
                    {
                        var applicationContext = new ApplicationContext();
                        HttpContext.Current.Session[CallContextKey] = applicationContext;
                        return applicationContext;
                    }
                }
            }
            set
            {
                if (HttpContext.Current == null)
                {
                    CallContext.SetData(CallContextKey, value);
                }
                else
                {
                    HttpContext.Current.Session[CallContextKey] = value;
                }
            }
        }


        private void EnsureSerializable(object value)
        {
            if (value != null && !value.GetType().IsSerializable)
            {
                throw new ArgumentException(string.Format("The argument of the type \"{0}\" is not serializable!", value.GetType().FullName));
            }
        }

        public void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
