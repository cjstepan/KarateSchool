<%@ Page Title="" Language="C#" MasterPageFile="~/KarateSchool.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KarateSchool.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <br />
</p>
<p>
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" DisplayRememberMe="False">
        <FailureTextStyle HorizontalAlign="Center" VerticalAlign="Top" />
        <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
    </asp:Login>
    <!-- currentl getting an error when trying to run the pages with the login tool added in the html or the design page.-->
</p>
<p>
</p>
</asp:Content>
