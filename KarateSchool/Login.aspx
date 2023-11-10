<%@ Page Title="" Language="C#" MasterPageFile="~/KarateSchool.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KarateSchool.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br />
</p>
<p>
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
    </asp:Login>
    <!-- currentl getting an error when trying to run the pages with the login tool added in the html or the design page.-->
</p>
<p>
</p>
</asp:Content>
