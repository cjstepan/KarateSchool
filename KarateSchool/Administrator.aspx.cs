using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        //Ryan conn string
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ostudent.CS\\Desktop\\KarateSchool\\KarateSchool\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void addMemberBtn_Click(object sender, EventArgs e)
        {
            //assign user input from text boxes to variables
            int userID = int.Parse(userIDtxt.Text);
            string firstName = firstNametxt.Text;
            string lastName = lastNametxt.Text;
            DateTime dateJoined = DateTime.Now;
            string phoneNumber = memberPhonetxt.Text;
            string email = memberEmailtxt.Text;

            //create new member ready for inserting into the Member table
            Member newMember = new Member
            {
                Member_UserID = userID,
                MemberFirstName = firstName,
                MemberLastName = lastName,
                MemberDateJoined = dateJoined,
                MemberPhoneNumber = phoneNumber,
                MemberEmail = email
            };
            //try adding the 'newMember' to the member table given the MemberID is unique and not already in use.
            try
            {
                using (dbcon = new KarateSchoolDataContext(conn))
                {
                    dbcon.Members.InsertOnSubmit(newMember);
                    dbcon.SubmitChanges();

                    //update member gridview and dropdown select
                    memberGridView.DataBind();
                    memberIDSelectDropDown.DataBind();
                }
            }
            //alert user of non-unique memberID
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a unique MemberID.');", true); }
        }

        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {
            //assign user input from text boxes to variables
            int userID = int.Parse(userIDtxt.Text);
            string firstName = firstNametxt.Text;
            string lastName = lastNametxt.Text;
            string phoneNumber = memberPhonetxt.Text;

            //create new instructor ready for inserting into the Instructor table
            Instructor newInstructor = new Instructor
            {
                InstructorID = userID,
                InstructorFirstName = firstName,
                InstructorLastName = lastName,
                InstructorPhoneNumber = phoneNumber,
            };
            //try adding the 'newInstructor' to the Instructor table given the InstructorID is unique and not already in use.
            try
            {
                using (dbcon = new KarateSchoolDataContext(conn))
                {
                    dbcon.Instructors.InsertOnSubmit(newInstructor);
                    dbcon.SubmitChanges();

                    //update instructor gridview and dropdown select
                    instructorGridView.DataBind();
                    instructorIDSelectDropDown.DataBind();
                }
            }
            //alert user of non-unique instructorID
            catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a unique InstructorID.');", true); }
        }

        protected void delMemberBtn_Click(object sender, EventArgs e)
        {
            //if memberID is selected in the dropdown delete the coorisponding record in the member table
                if (memberIDSelectDropDown.SelectedValue != null)
            {
                //assign dropdown selection to a int variable
                int selectedMemberID = Convert.ToInt32(memberIDSelectDropDown.SelectedValue);

                    using (dbcon = new KarateSchoolDataContext(conn))
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

                using (dbcon = new KarateSchoolDataContext(conn))
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
