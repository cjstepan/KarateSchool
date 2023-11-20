using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Login : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string connString = ConfigurationManager.ConnectionStrings["KarateSchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            dbcon = new KarateSchoolDataContext(connString);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            NetUser myUser = new NetUser();

            //Try catch ensures invalid credentials does not cause the webpage to crash
            try
            {
                string nUserName = Login1.UserName;
                string nPassword = Login1.Password;

                HttpContext.Current.Session["nUserName"] = nUserName;
                HttpContext.Current.Session["uPass"] = nPassword;

                // Search for the current User, validate UserName and Password
                myUser = (from x in dbcon.NetUsers
                                  where x.UserName == HttpContext.Current.Session["nUserName"].ToString()
                                  && x.UserPassword == HttpContext.Current.Session["uPass"].ToString()
                                  select x).First();
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
            
            //Backup logic in case invalid credentials somehow get through
            //This also ensures based on login credentials that the user gets sent to the proper page
            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;

                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
                {
                    FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                    Response.Redirect("~/MemberInfo/Member.aspx");
                }
                
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
                {
                    FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                    Response.Redirect("~/InstructorInfo/Instructor.aspx");
                }
                
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                    Response.Redirect("~/AdministratorInfo/Administrator.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx", true);
            }
        }
    }
}
