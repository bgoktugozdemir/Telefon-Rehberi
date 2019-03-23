using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telefon_Rehberi.Helpers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["UserName"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Admin/Giris/Index");
                return false;
            }

        }
    }
}