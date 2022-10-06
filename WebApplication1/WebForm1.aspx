<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>burası başlık</title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>
        <div>
            burası web form ön yüzü HTML :web sitelerinin ortak dilidir
        </div>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/bird.png" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="gizli değer" />
        <asp:Label ID="Label1" runat="server" Text="Label ile ekranda yazı yazıyoruz"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem>khöjç</asp:ListItem>
            <asp:ListItem>sdsasd</asp:ListItem>
             <asp:ListItem>ek1</asp:ListItem>
        </asp:CheckBoxList>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="onaylıyotrum" />
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
            <asp:RadioButton ID="secim" runat="server" />
        </p>
        <a href="javascript:__doPostBack('LinkButton1','')">buraya tıklayınız<asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>onaylıyorum</asp:ListItem>
            <asp:ListItem>onaylamıyorum</asp:ListItem>
        </asp:RadioButtonList>
            Adınız:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </a></form>
        </body>
</html>
