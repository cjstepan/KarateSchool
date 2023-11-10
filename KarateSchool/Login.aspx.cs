using System;
using System.Collections.Generic;
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
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Github\\KarateSchool\\KarateSchool\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            string userName = Login1.UserName;
            string pass = Login1.Password;




            if (true)//add sql statments that grab the user and password from the NetUser table in the KarateSchool.mdf
            {

                FormsAuthentication.RedirectFromLoginPage(userName, true);


            }
            else
                Response.Redirect("Login.aspx", true);


        }

    }
}
