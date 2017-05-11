<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="A2ZBooks.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .GridView3 {
            font-family: Arial, Helvetica, sans-serif;
            margin-left: 120px;
            padding-right: 20px;
            padding-left: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="font-family: Arial, Helvetica, sans-serif; margin-top: 20px; margin-left: 150px; margin-bottom: 50px;">Confirmation</h2>
    <p style="font-family: Arial, Helvetica, sans-serif; margin-top: 20px; margin-left: 100px; margin-bottom: 50px;">
        <asp:Label ID="lblConfirm" runat="server" Visible="False"></asp:Label>
    </p>
    <asp:GridView ID="GridView3" runat="server" CellPadding="4" CssClass="GridView3" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <br />
    <p class="auto-style2" style="margin-right: 200px; font-family: Arial, Helvetica, sans-serif;">
        Subtotal:
        <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
    </p>
    <p class="auto-style2" style="margin-right: 200px; font-family: Arial, Helvetica, sans-serif;">
        Shipping:
        <asp:Label ID="lblShipping" runat="server"></asp:Label>
    </p>
    <p class="auto-style2" style="margin-right: 200px; font-family: Arial, Helvetica, sans-serif;">
        Tax:
        <asp:Label ID="lblTax" runat="server"></asp:Label>
    </p>
    <p class="auto-style2" style="margin-right: 200px; font-family: Arial, Helvetica, sans-serif;">
        Total:
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
    </p>
    <p class="auto-style2">
        &nbsp;</p>
    <div class="auto-style1" style="float: left; overflow: hidden; background-color: #FFFFFF; margin-left: 200px">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
    <div class="auto-style1" style="float: right; overflow: hidden; margin-right: 250px;">
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
    </div>
    <br />
    <br />
    <br />
</asp:Content>
