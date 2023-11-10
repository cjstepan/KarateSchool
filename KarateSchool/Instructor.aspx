<%@ Page Title="" Language="C#" MasterPageFile="~/KarateSchool.Master" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="KarateSchool.Instructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Hello
        <asp:LoginName ID="LoginName1" runat="server" />
        <br />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
    </p>
</asp:Content>
