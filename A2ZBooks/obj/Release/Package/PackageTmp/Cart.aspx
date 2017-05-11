<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="A2ZBooks.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style10 {
            text-align: left;
        }
        .GridView1 {
            margin-right: auto;
            margin-left: auto;
            font-family: Arial, Helvetica, sans-serif;
            position: relative;
            width: auto;
            height: auto;
            right: 0px;
            left: 0px;
            clip: rect(auto, auto, auto, auto);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: left; font-family: Arial, Helvetica, sans-serif; margin-top: 20px; margin-left: 150px;" class="auto-style10">Shopping Cart</h2>
        <hr />
        <br />
        <br />
    <div style="margin-right: 30%; margin-left: 30%">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="text-align: center; top: 0px;" CssClass="GridView1" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Remove" Text="Remove" />
            </Columns>
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
    </div>
        <hr />
        <p class="auto-style5" style="margin-right: 100px">
            <asp:Label ID="subtitle_Lbl" runat="server"></asp:Label>
        </p>
        <table class="auto-style1" align="center">
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="backToSearch_Btn" runat="server" Text="Back to Search Result" OnClick="backToSearch_Btn_Click" Width="200px" />
                </td>
                <td class="auto-style4">
                    <asp:Button ID="continueShop_Btn" runat="server" Text="Continue Shopping" OnClick="continueShop_Btn_Click" Width="200px" />
                </td>
                <td class="auto-style4">
                    <asp:Button ID="placeOrder_Btn" runat="server" Text="Place Order" OnClick="placeOrder_Btn_Click" Width="200px" />
                </td>
            </tr>
        </table>
</asp:Content>
