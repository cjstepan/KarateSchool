<%@ Page Title="" Language="C#" MasterPageFile="~/KarateSchool.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateSchool.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 55px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </p>
    <p>
        Member Table</p>
    <asp:GridView ID="MemberGridView" runat="server">
    </asp:GridView>
        <p>
            Instructor Table</p>
    <asp:GridView ID="InstructorGridView" runat="server">
    </asp:GridView>
    <p>
        <asp:Label ID="Label1" runat="server">Member/Instructor First Name</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="firstNametxt" runat="server" Width="220px">First</asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Member/Instructor Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="lastNametxt" runat="server" Width="220px">Last</asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Member/Instructor Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="memberPhonetxt" runat="server" Width="220px">111-222-3333</asp:TextBox>
        </p>
    <p>
        Email (Member Only)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="memberEmailtxt" runat="server" Width="220px">member@email.com</asp:TextBox>
        </p>
    <p>
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="passwordTxtBox" runat="server" Width="219px">**********</asp:TextBox>
        </p>
    <p>
        <asp:Button ID="addMemberBtn" runat="server" Text="Add New Member" Width="177px" OnClick="addMemberBtn_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="addInstructorBtn" runat="server" Text="Add New Instructor" Width="175px" OnClick="addInstructorBtn_Click" CssClass="auto-style2" />
        </p>
    <p>
        &nbsp;</p>
    <p>
        MemberUserID&nbsp;&nbsp;
<asp:DropDownList ID="memberIDSelectDropDown" runat="server" DataSourceID="memberID" DataTextField="Member_UserID" DataValueField="Member_UserID">
    <asp:ListItem Value="">Select ID</asp:ListItem>
</asp:DropDownList>
        <asp:SqlDataSource ID="memberID" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [Member_UserID] FROM [Member]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InstructorID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="instructorIDSelectDropDown" runat="server" DataSourceID="instructors" DataTextField="InstructorID" DataValueField="InstructorID">
    <asp:ListItem Value="">Select ID</asp:ListItem>
</asp:DropDownList>
        <asp:SqlDataSource ID="instructors" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [InstructorID] FROM [Instructor]"></asp:SqlDataSource>
        </p>
    <asp:Button ID="delMemberBtn" runat="server" Text="Delete Selected Member" Width="250px" OnClick="delMemberBtn_Click" />
    <asp:Button ID="delInstructorBtn" runat="server" Text="Delete Selected Instructor" Width="250px" OnClick="delInstructorBtn_Click" />
    <br />
    <p>
        Select Member section&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="sectionDropDown" runat="server" CssClass="auto-style1" DataSourceID="sectionID" DataTextField="SectionName" DataValueField="SectionName" Height="27px" Width="220px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sectionID" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [SectionID], [SectionName] FROM [Section]"></asp:SqlDataSource>
        </p>
    <p>
        <asp:Button ID="addMemberToSectionBtn" runat="server" Text="Add selected Member to selected Section" Width="500px" />
        </p>
</asp:Content>
