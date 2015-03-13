using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private string checkoutId;
    public string CheckoutId { get { return checkoutId; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        checkoutId = prepareCheckout();
    }

    public string prepareCheckout()
    {
        var checkoutId = string.Empty;
        var data = new NameValueCollection() {
        {"authentication.userId", "8a8294184b4f2868014b4f86f767015d"},
        {"authentication.password", "F8T7N4PD"},
        {"authentication.entityId", "8a8294184b4f2868014b4f87bf160173"},
        {"paymentType", "DB"},
        {"amount", "50.99"},
        {"currency", "EUR"},
      };
        using (var wc = new WebClient())
        {
            var rslt = wc.UploadValues("https://test.oppwa.com/v1/checkouts", data);
            var s = new JavaScriptSerializer();
            var json = s.Deserialize<Dictionary<string, dynamic>>(Encoding.UTF8.GetString(rslt));
            if (json.ContainsKey("id"))
            {
                checkoutId = json["id"];
            }
        }
        return checkoutId;
    } 
}