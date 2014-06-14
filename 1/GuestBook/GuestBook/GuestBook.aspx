<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestBook.aspx.cs" Inherits="GuestBook.GuestBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GuestBook</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <center>
      <asp:Label ID="Label1" runat="server" Text="Гостевая книга" Font-Size="XX-Large" ForeColor="#33CCCC"></asp:Label>
    </center>
    <div>
        <asp:Label ID="YourNameLabel" runat="server" Text="Ваше имя:"></asp:Label>
        <br />
        <asp:TextBox ID="YourNameTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="YourNameTextBox"
            ErrorMessage="Необходимо заполнить данное поле"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="YourEmailLabel" runat="server" Text="Ваш E-mail:"></asp:Label>
        <br />
        <asp:TextBox ID="YourEmailTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="YourEmailTextBox"
            ErrorMessage="Необходимо заполнить данное поле"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="YourMessageLabel" runat="server" Text="Ваше сообщение:"></asp:Label>
        <br />
        <asp:TextBox ID="YourMessageTextBox" runat="server" TextMode="MultiLine" 
            Height="135px" Width="335px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="YourMessageTextBox"
            ErrorMessage="Необходимо заполнить данное поле"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="AddMessageButton" runat="server" Text="Добавить сообщение"/>
        <br />
        <asp:UpdatePanel ID="TimeUpdatePanel" runat="server">
          <ContentTemplate>
            <asp:Timer ID="TimerTimer" runat="server" Interval="1000"></asp:Timer>
            <br />
            <asp:TextBox ID="TimeTextBox" runat="server" ReadOnly="true"></asp:TextBox>
          </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="TableGuestBookUpdatePanel" runat="server">
          <ContentTemplate>
            <asp:GridView ID="GuestBookGridVew" runat="server" Caption="Записи гостевой книги"></asp:GridView>
          </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
