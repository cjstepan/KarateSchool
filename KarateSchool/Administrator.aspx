<%@ Page Title="" Language="C#" MasterPageFile="~/KarateSchool.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateSchool.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Member Table</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Member_UserID" DataSourceID="members">
        <Columns>
            <asp:BoundField DataField="Member_UserID" HeaderText="Member_UserID" ReadOnly="True" SortExpression="Member_UserID" />
            <asp:BoundField DataField="MemberFirstName" HeaderText="MemberFirstName" SortExpression="MemberFirstName" />
            <asp:BoundField DataField="MemberLastName" HeaderText="MemberLastName" SortExpression="MemberLastName" />
            <asp:BoundField DataField="MemberDateJoined" HeaderText="MemberDateJoined" SortExpression="MemberDateJoined" />
            <asp:BoundField DataField="MemberPhoneNumber" HeaderText="MemberPhoneNumber" SortExpression="MemberPhoneNumber" />
            <asp:BoundField DataField="MemberEmail" HeaderText="MemberEmail" SortExpression="MemberEmail" />
        </Columns>
    </asp:GridView>
        <p>
            Instructor Table<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="InstructorID" DataSourceID="instructor">
                <Columns>
                    <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" ReadOnly="True" SortExpression="InstructorID" />
                    <asp:BoundField DataField="InstructorFirstName" HeaderText="InstructorFirstName" SortExpression="InstructorFirstName" />
                    <asp:BoundField DataField="InstructorLastName" HeaderText="InstructorLastName" SortExpression="InstructorLastName" />
                    <asp:BoundField DataField="InstructorPhoneNumber" HeaderText="InstructorPhoneNumber" SortExpression="InstructorPhoneNumber" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="instructor" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT * FROM [Instructor]"></asp:SqlDataSource>
        </p>
    <p>
            <asp:SqlDataSource ID="members" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT * FROM [Member]"></asp:SqlDataSource>
        </p>
    <p>
        <asp:Label ID="Label1" runat="server">Member/Instructor First Name</asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="firstNametxt" runat="server" Width="220px">First</asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Member/Instructor Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="lastNametxt" runat="server" Width="220px">Last</asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Date Joined"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dateJoinedtxt" runat="server" Width="220px">MM/DD/YYYY  12:00:00 PM</asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Member/Instructor Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="memberPhonetxt" runat="server" Width="220px">111-222-3333</asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Member Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="memberEmailtxt" runat="server" Width="220px">member@email.com</asp:TextBox>
        </p>
    <p>
        <asp:Button ID="addMemberBtn" runat="server" Text="Add New Member" Width="500px" />
        </p>
    <p>
        <asp:Button ID="addInstructorBtn" runat="server" Text="Add New Instructor" Width="500px" />
        </p>
    <p>
        MemberUserID&nbsp;&nbsp;
        <asp:DropDownList ID="memberIDSelectDropDown" runat="server" DataSourceID="memberID" DataTextField="Member_UserID" DataValueField="Member_UserID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="memberID" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [Member_UserID] FROM [Member]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InstructorID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="instructorIDSelectDropDown" runat="server" DataSourceID="instructors" DataTextField="InstructorID" DataValueField="InstructorID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="instructors" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [InstructorID] FROM [Instructor]"></asp:SqlDataSource>
        </p>
    <asp:Button ID="delMemberBtn" runat="server" Text="Delete Selected Member" Width="250px" />
    <asp:Button ID="delInstructorBtn" runat="server" Text="Delete Selected Instructor" Width="250px" />
    <br />
    <p>
        Select Member section&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="sectionDropDown" runat="server" CssClass="auto-style1" DataSourceID="sectionID" DataTextField="SectionName" DataValueField="SectionName" Height="16px" Width="220px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sectionID" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT [SectionID], [SectionName] FROM [Section]"></asp:SqlDataSource>
        </p>
    <p>
        <asp:Button ID="addMemberToSectionBtn" runat="server" Text="Add selected Member to selected Section" Width="500px" />
        </p>
</asp:Content>
