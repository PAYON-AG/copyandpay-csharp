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
        {"authentication.userId", "8a8294174b7ecb28014b9699220015cc"},
        {"authentication.password", "sy6KJsT8"},
        {"authentication.entityId", "8a8294174b7ecb28014b9699a3cf15d1"},
        {"paymentType", "PA"},
        {"amount", "10.00"},
        {"currency", "EUR"},
        {"customer.surname", "Jones"},
        {"customer.givenName", "Jane"},
        {"customer.birthDate", "1970-01-01"},
        {"billing.city", "Test"},
        {"billing.country", "DE"},
        {"billing.street1", "123 Test Street"},
        {"billing.postcode", "TE1 2ST"},
        {"customer.email", "test@test.com"},
        {"customer.phone", "1234567890"},
        {"customer.ip", "123.123.123.123"},
        {"customParameters[PAYOLUTION_ITEM_PRICE_1]", "2.00"},
        {"customParameters[PAYOLUTION_ITEM_DESCR_1]", "Test item #1"},
        {"customParameters[PAYOLUTION_ITEM_PRICE_1]", "3.00"},
        {"customParameters[PAYOLUTION_ITEM_DESCR_1]", "Test item #2"},
        {"testMode", "EXTERNAL"},
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