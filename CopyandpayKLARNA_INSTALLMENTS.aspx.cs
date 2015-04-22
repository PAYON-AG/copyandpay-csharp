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
        {"currency", "SEK"},
        {"billing.country", "SE"},
        {"customer.givenName", "Joe"},
        {"customer.surname", "Doe"},
        {"cart.items[0].merchantItemId", "1"},
        {"cart.items[0].discount", "0.00"},
        {"cart.items[0].quantity", "5"},
        {"cart.items[0].name", "Product 1"},
        {"cart.items[0].price", "1.00"},
        {"cart.items[0].tax", "6.00"},
        {"customParameters[KLARNA_CART_ITEM1_FLAGS]", "32"},
        {"cart.items[1].merchantItemId", "2"},
        {"cart.items[1].discount", "0.00"},
        {"cart.items[1].quantity", "1"},
        {"cart.items[1].name", "Product 2"},
        {"cart.items[1].price", "1.00"},
        {"cart.items[1].tax", "6.00"},
        {"customParameters[KLARNA_CART_ITEM2_FLAGS]", "32"},
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