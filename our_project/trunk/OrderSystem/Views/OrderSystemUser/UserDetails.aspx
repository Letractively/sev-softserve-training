<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>User Info</title>
</head>
<body style="width: 749px; padding-left: 20px;">
    <form id="form1" runat="server" 
    style="font-size: 18px; padding-top: 10px; padding-right: 5px; padding-bottom: 5px;">
    <div style="font-size: 24px; border: solid 1px black; width: 725px;">
        
        User Info</div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        User Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="userNameLabel" runat="server" Text=""></asp:Label>
    </p>
    <p>
        Role&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
        <asp:Label ID="userRoleLabel" runat="server" Text=""></asp:Label>
    </p>
    <p>
        Customer Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="customerTypeLabel" runat="server" Text=""></asp:Label>
    </p>
    <p>
        Account Balance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:Label 
            ID="accountBalanceLabel" runat="server" Text=""></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:TextBox BorderStyle="None" Font-Size="16px" Font-Italic="true" ReadOnly="true" ID="nextTypeTextBox" runat="server" Height="79px" Width="723px"></asp:TextBox>
    </p>
    </form>
</body>
</html>
