using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace payu_bolt
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string surl = ((HttpContext.Current.Request.ServerVariables["HTTPS"] != "" && HttpContext.Current.Request.ServerVariables["HTTP_HOST"] != "off") || HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == "443") ? "https://" : "http://";
	        surl += HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.ServerVariables["REQUEST_URI"] + "/Response.aspx";
            Session.Add("surl",surl);

            Random r = new Random();
            string txnid = "Txn" + r.Next(100, 9999);
            Session.Add("txnid", txnid);
        }
      
    }
}
