using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string connString = ConfigurationManager.ConnectionStrings["KarateSchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);
            if (Session.Count != 0)
            {
                //If the current user is not admin, redirect them to the login page
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" || HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx", true);
                }
            }

            //try catch ensures the page does not break if the LINQ queries do
            try
            {
                var memberQuery = from member in dbcon.Members
                                  select new
                                  {
                                      First_Name = member.MemberFirstName,
                                      Last_Name = member.MemberLastName,
                                      Phone_Number = member.MemberPhoneNumber,
                                      Date_Joined = member.MemberDateJoined,
                                  };
                memberGridView.DataSource = memberQuery;
                memberGridView.DataBind();

                var instructorQuery = from instructor in dbcon.Instructors
                                      select new
                                      {
                                          First_Name = instructor.InstructorFirstName,
                                          LastName = instructor.InstructorLastName,
                                      };
                instructorGridView.DataSource = instructorQuery.ToList();
                instructorGridView.DataBind();
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void addMemberBtn_Click(object sender, EventArgs e)
        {
            //create new member ready for inserting into the Member table
            Member newMember = new Member
            {
                Member_UserID = int.Parse(userIDtxt.Text),
                MemberFirstName = firstNametxt.Text,
                MemberLastName = lastNametxt.Text,
                MemberDateJoined = DateTime.Now,
                MemberPhoneNumber = memberPhonetxt.Text,
                MemberEmail = memberEmailtxt.Text,
            };

            //try adding the 'newMember' to the member table given the MemberID is unique and not already in use.
            try
            {
                using (dbcon = new KarateSchoolDataContext(connString))
                {
                    dbcon.Members.InsertOnSubmit(newMember);
                    dbcon.SubmitChanges();

                    //update member gridview and dropdown select
                    memberGridView.DataBind();
                    memberIDSelectDropDown.DataBind();
                }
            }
            //alert user of non-unique memberID
            catch
            { 
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a unique MemberID.');", true);
            }
        }

        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {
            //create new instructor ready for inserting into the Instructor table
            Instructor newInstructor = new Instructor
            {
                InstructorID = int.Parse(userIDtxt.Text),
                InstructorFirstName = firstNametxt.Text,
                InstructorLastName = lastNametxt.Text,
                InstructorPhoneNumber = memberPhonetxt.Text,
            };

            //try adding the 'newInstructor' to the Instructor table given the InstructorID is unique and not already in use.
            try
            {
                using (dbcon = new KarateSchoolDataContext(connString))
                {
                    dbcon.Instructors.InsertOnSubmit(newInstructor);
                    dbcon.SubmitChanges();

                    //update instructor gridview and dropdown select
                    instructorGridView.DataBind();
                    instructorIDSelectDropDown.DataBind();
                }
            }
            //alert user of non-unique instructorID
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a unique InstructorID.');", true);
            }
        }

        protected void delMemberBtn_Click(object sender, EventArgs e)
        {
            //if memberID is selected in the dropdown delete the coorisponding record in the member table
            if (memberIDSelectDropDown.SelectedValue != null)
            {
                //assign dropdown selection to a int variable
                int selectedMemberID = Convert.ToInt32(memberIDSelectDropDown.SelectedValue);

                using (dbcon = new KarateSchoolDataContext(connString))
                {
                    // Retrieve the selected record from the database
                    var selectedRecord = dbcon.Members.SingleOrDefault(m => m.Member_UserID == selectedMemberID);

                    if (selectedRecord != null)
                    {
                        //update member gridview and dropdown
                        dbcon.Members.DeleteOnSubmit(selectedRecord);
                        dbcon.SubmitChanges();
                        memberGridView.DataBind();
                        memberIDSelectDropDown.DataBind();
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a member to delete.');", true);
            }
        }

        protected void delInstructorBtn_Click(object sender, EventArgs e)
        {
            //if instructorID is selected in the dropdown delete the coorisponding record in the instructor table
            if (instructorIDSelectDropDown.SelectedValue != null)
            {
                //assign dropdown selection to a int variable
                int selectedInstructorID = Convert.ToInt32(instructorIDSelectDropDown.SelectedValue);

                using (dbcon = new KarateSchoolDataContext(connString))
                {
                    // Retrieve the selected record from the database
                    var selectedRecord = dbcon.Instructors.SingleOrDefault(i => i.InstructorID == selectedInstructorID);

                    if (selectedRecord != null)
                    {
                        dbcon.Instructors.DeleteOnSubmit(selectedRecord);
                        dbcon.SubmitChanges();
                        //update instructor gridview and dropdown 
                        instructorGridView.DataBind();
                        instructorIDSelectDropDown.DataBind();
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a instructor to delete.');", true);
            }
        }

    }
}
