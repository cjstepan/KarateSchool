using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Member : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string connString = ConfigurationManager.ConnectionStrings["KarateSchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor" || HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx", true);
                }
            }

            //Retrieve logged in user's class and payment info using LINQ
            try
            {
                Member member = (from x in dbcon.Members
                                 where x.Member_UserID == int.Parse(HttpContext.Current.Session["userID"].ToString())
                                 select x).First();
                Label1.Text = member.MemberFirstName + " " + member.MemberLastName;

                var currentDate = DateTime.Now;//Datetime.Now gets current date 

                var result = from sections in dbcon.Sections
                             where member.Member_UserID == sections.Member_ID
                             join instructor in dbcon.Instructors on sections.Instructor_ID equals instructor.InstructorID
                             select new
                             {
                                 Section_Name = sections.SectionName,
                                 Instructor_First_Name = instructor.InstructorFirstName,
                                 Instructor_Last_Name = instructor.InstructorLastName,
                                 Payment_Date = member.MemberDateJoined,
                                 //Payment amount is calculated as number of months enrolled * section fee
                                 Payment_Amount = ((currentDate.Year - member.MemberDateJoined.Year) * 12 + currentDate.Month - member.MemberDateJoined.Month) * sections.SectionFee,
                             };
                GridView1.DataSource = result;
                GridView1.DataBind();
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}