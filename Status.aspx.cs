using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Status : System.Web.UI.Page
{
    private string result;
    public string Result { get { return result; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        getPaymentStatus(Request.Form["id"]);
    }
    private void getPaymentStatus(string checkoutId)
    {
        string url = "https://test.oppwa.com/v1/checkouts/" + checkoutId + "/payment";
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "GET";
        string response = String.Empty;
        using (HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse())
        {
            Stream dataStream = webresponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            response = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
        }

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, dynamic> responseJson = serializer.Deserialize<Dictionary<string, dynamic>>(response);

        if (responseJson["result"]["code"].StartsWith("000"))
        {
            result = "SUCCESS <br/><br/> Here is the result of your transaction: <br/><br/>";
            result += response;
        }
        else
        {
            result = "ERROR <br/><br/> Here is the result of your transaction: <br/><br/>";
            result += response;
        }
    }
}