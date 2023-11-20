using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Configuration;

namespace KarateSchool
{
    public partial class Instructor : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string connString = ConfigurationManager.ConnectionStrings["KarateSchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" || HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx", true);
                }
            }
            try
            {
                Instructor instructor = (from x in dbcon.Instructors
                                         where x.InstructorID == int.Parse(HttpContext.Current.Session["userID"].ToString())
                                         select x).First();
                Label1.Text = instructor.InstructorFirstName + " " + instructor.InstructorLastName;

                var result = from sections in dbcon.Sections
                             where instructor.InstructorID == sections.Instructor_ID
                             join member in dbcon.Members on sections.Member_ID equals member.Member_UserID
                             select new
                             {
                                 Section_Name = sections.SectionName,
                                 Member_First_Name = member.MemberFirstName,
                                 Member_Last_Name = member.MemberLastName,
                             };
                GridView1.DataSource = result;
                GridView1.DataBind();
            }
            catch
            {
                Console.WriteLine("~/Login.aspx");
            }
        }
    }
}