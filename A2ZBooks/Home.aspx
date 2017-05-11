<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="A2ZBooks.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        margin-left: 250px;
        margin-right: 250px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style1">
    &nbsp;<br />
    <asp:TextBox ID="txtSearch" runat="server" Height="18px" Width="400px"></asp:TextBox>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="title">Title</asp:ListItem>
        <asp:ListItem Value="isbn">ISBN</asp:ListItem>
        <asp:ListItem Value="author">Author</asp:ListItem>
        <asp:ListItem Value="courseNum">Course Number</asp:ListItem>
    </asp:DropDownList>
</p>
<p class="auto-style1">
    <asp:RequiredFieldValidator ID="rfvSearchBox" runat="server" ControlToValidate="txtSearch" Display="Dynamic" ErrorMessage="Please enter the search criteria." ForeColor="Red"></asp:RequiredFieldValidator>
</p>
<p class="auto-style1">
    <asp:Button ID="btnSearch" runat="server" BackColor="#CCCCCC" Font-Names="Arial" Font-Size="Medium" Text="Search" OnClick="btnSearch_Click" />
</p>
<blockquote id="paraIntro" class="auto-style4" style="margin: 50px 250px 50px 250px; font-family: Calibri; font-size: medium; border-style: none; padding: 0px;">
    Welcome to A2ZBooks.com. We are glad to have you here at our website. At A2Z, we are committed to provide our customers with the best shopping experience and conveniently purchase books at an affordable price. Browse through our inventory to see what books we have or search for a book that you are looking for, everything you need is here. Thank you for choosing A2Z Books.</blockquote>
<p>
</p>
</asp:Content>
