<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopyandpayBRADESCO.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>COPYandPAY C#</title>
    <script src="https://test.oppwa.com/v1/paymentWidgets.js?checkoutId=<%=CheckoutId%>"></script>
</head>
<body>
    <form action="http://localhost:49639/Status.aspx" class="paymentWidgets">BRADESCO</form>
</body>
</html>
