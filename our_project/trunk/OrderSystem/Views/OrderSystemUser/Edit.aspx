<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<script runat="server">

</script>
<html>
<head id="Head1" runat="server">
    <title>Edit</title>
</head>
<body style="width: 749px; padding-left: 20px;">
    <form id="form1" runat="server" 
    style="font-size: 18px; padding-top: 10px; padding-right: 5px; padding-bottom: 5px;">
    <div style="margin-left: 720px">
        <asp:ImageButton 
            ID="ImageButton1" runat="server" />
    </div>
    <div style="font-size: 36px">
        
        Edit User
    </div>
    <p>
        This page is appointed for editing user for particular role</p>
    <p>
        Login Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="19px" MaxLength="100" 
            style="margin-left: 0px" Width="175px"></asp:TextBox>
    </p>
    <p>
        First Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="19px" MaxLength="100" 
            Width="175px"></asp:TextBox>
    </p>
    <p>
        Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Height="19px" MaxLength="100" 
            Width="175px"></asp:TextBox>
    </p>
    <p>
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Height="19px" MaxLength="100" 
            Width="175px"></asp:TextBox>
    </p>
    <p>
        Confirm Password&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Height="19px" MaxLength="100" 
            Width="175px"></asp:TextBox>
    </p>
    <p>
        Email Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" Height="19px" MaxLength="100" 
            Width="175px"></asp:TextBox>
    </p>
    <p>
        Region&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="175px">
            <asp:ListItem Selected="True">North</asp:ListItem>
            <asp:ListItem>South</asp:ListItem>
            <asp:ListItem>West</asp:ListItem>
            <asp:ListItem>East</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Role:</p>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" BorderColor="Black" 
        BorderStyle="Inset" BorderWidth="2px" 
        Font-Size="18pt" Height="144px" 
        RepeatLayout="Flow" Width="741px" 
        style="padding-top: 20px; padding-left: 10px; padding-bottom: 5px;">
        <asp:ListItem>Administrator</asp:ListItem>
        <asp:ListItem>Merchandiser</asp:ListItem>
        <asp:ListItem>Supervisor</asp:ListItem>
        <asp:ListItem>Customer</asp:ListItem>
    </asp:RadioButtonList>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Update" Width="60px" style="margin-right: 10px;"/>
        <asp:Button ID="Button2" runat="server" Text="Cancel" 
            Width="60px" style="margin-right: 10px;" />
        <asp:Button ID="Button3" runat="server" Text="Refresh" Width="60px" style="margin-right: 10px;" />
    </p>
    </form>
</body>
</html>
