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
        //string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ryanm\\Desktop\\Cloned Repositories\\KarateSchool\\KarateSchool\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";
        string connString = ConfigurationManager.ConnectionStrings["KarateSchoolConnectionString"].ConnectionString;
        protected void refreshGridViews()
        {
            dbcon = new KarateSchoolDataContext(connString);
            try
            {
                var result = from member in dbcon.Members
                             select new
                             {
                                 MemberFirstName = member.MemberFirstName,
                                 MemberLastName = member.MemberLastName,
                                 MemberPhoneNumber = member.MemberPhoneNumber,
                                 MemberDateJoined = member.MemberDateJoined
                             };

                MemberGridView.DataSource = result;
                MemberGridView.DataBind();

                var instructorResult = from instructor in dbcon.Instructors
                                       select new
                                       {
                                           InstructorFirstName = instructor.InstructorFirstName,
                                           InstructorLastName = instructor.InstructorLastName
                                       };
                InstructorGridView.DataSource = instructorResult;
                InstructorGridView.DataBind();
            }

            catch
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected int returnUserID()
        {
            using (var dbcon = new KarateSchoolDataContext(connString))
            {
                // Replace "desiredUserName" with the actual username you're searching for
                string userName = (firstNametxt.Text + lastNametxt.Text).ToLower().Trim();

                // LINQ query to get the UserID based on the UserName
                var userIdQuery = from user in dbcon.NetUsers
                                  where user.UserName == userName
                                  select user.UserID;

                // Execute the query and get the first result (or default if no matching user is found)
                int userId = userIdQuery.FirstOrDefault();

                // Now, 'userId' contains the UserID corresponding to the given UserName
                Console.WriteLine($"UserID for UserName '{userName}': {userId}");

                // Return the userID
                return userId;
            }
        }

       

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
            refreshGridViews();

        }

        protected void addMemberBtn_Click(object sender, EventArgs e)
        {
            using (dbcon = new KarateSchoolDataContext(connString))
            {
                try
                {
                    string userName = (firstNametxt.Text + lastNametxt.Text).ToLower().Trim();
                    string password = passwordTxtBox.Text;

                    // Insert into NetUser table
                    NetUser newMemberUser = new NetUser
                    {
                        UserName = userName,
                        UserPassword = password,
                        UserType = "Member"
                    };
                    
                    dbcon.NetUsers.InsertOnSubmit(newMemberUser);
                    dbcon.SubmitChanges();  // Commit the changes to get the generated identity value

                    // Insert into Member table using the retrieved identity value
                    Member newMember = new Member
                    {
                        Member_UserID = newMemberUser.UserID,
                        MemberFirstName = firstNametxt.Text,
                        MemberLastName = lastNametxt.Text,
                        MemberDateJoined = DateTime.Now,
                        MemberPhoneNumber = memberPhonetxt.Text,
                        MemberEmail = memberEmailtxt.Text,
                    };
                    dbcon.Members.InsertOnSubmit(newMember);
                    dbcon.SubmitChanges();

                    // Update member gridview and dropdown select
                    MemberGridView.DataBind();
                    memberIDSelectDropDown.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding member: {ex.Message}");
                    throw;
                }
            }
            refreshGridViews();
        }



        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {

            using (dbcon = new KarateSchoolDataContext(connString))
            {
                try
                {
                    string userName = (firstNametxt.Text + lastNametxt.Text).ToLower().Trim();
                    string password = passwordTxtBox.Text;

                    NetUser newMemberUser = new NetUser
                    {
                        UserName = userName,
                        UserPassword = password,
                        UserType = "Instructor"
                    };
                    dbcon.NetUsers.InsertOnSubmit(newMemberUser);
                    dbcon.SubmitChanges();

                    //create new instructor ready for inserting into the Instructor table
                    Instructor newInstructor = new Instructor
                    {
                        InstructorID = newMemberUser.UserID,
                        InstructorFirstName = firstNametxt.Text,
                        InstructorLastName = lastNametxt.Text,
                        InstructorPhoneNumber = memberPhonetxt.Text,
                    };

                    dbcon.Instructors.InsertOnSubmit(newInstructor);
                    dbcon.SubmitChanges();

                    //update instructor gridview and dropdown select
                    InstructorGridView.DataBind();
                    instructorIDSelectDropDown.DataBind();

                }
                //alert user of non-unique instructorID
                catch (Exception ex)
                {

                    Console.WriteLine($"Error adding member: {ex.Message}");
                    throw;
                }
            }
            refreshGridViews();
        }

        protected void delMemberBtn_Click(object sender, EventArgs e)
        {
            if (memberIDSelectDropDown.SelectedValue != null)
            {
                int selectedMemberID = Convert.ToInt32(memberIDSelectDropDown.SelectedValue);

                try
                {
                    using (dbcon = new KarateSchoolDataContext(connString))
                    {
                        var selectedMember = dbcon.Members.SingleOrDefault(m => m.Member_UserID == selectedMemberID);

                        if (selectedMember != null)
                        {
                            // Retrieve related records from the Section table
                            var sectionsToDelete = dbcon.Sections.Where(s => s.Member_ID == selectedMemberID);

                            // Retrieve the associated user record from the NetUser table
                            var userToDelete = dbcon.NetUsers.SingleOrDefault(u => u.UserID == selectedMemberID);

                            // Delete related records from the Section table
                            dbcon.Sections.DeleteAllOnSubmit(sectionsToDelete);

                            // Delete the member record
                            dbcon.Members.DeleteOnSubmit(selectedMember);

                            // Delete the user record from the NetUser table
                            if (userToDelete != null)
                            {
                                dbcon.NetUsers.DeleteOnSubmit(userToDelete);
                            }

                            // Submit changes
                            dbcon.SubmitChanges();

                            // Refresh UI components
                            MemberGridView.DataBind();
                            memberIDSelectDropDown.DataBind();
                            refreshGridViews();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it or show an error message to the user)
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a member to delete.');", true);
            }
        }


        protected void delInstructorBtn_Click(object sender, EventArgs e)
        {
            // Check if an instructorID is selected in the dropdown
            if (instructorIDSelectDropDown.SelectedValue != null)
            {
                // Assign dropdown selection to an int variable
                int selectedInstructorID = Convert.ToInt32(instructorIDSelectDropDown.SelectedValue);

                try
                {
                    using (dbcon = new KarateSchoolDataContext(connString))
                    {
                        // Retrieve the selected record from the database
                        var selectedInstructor = dbcon.Instructors.SingleOrDefault(i => i.InstructorID == selectedInstructorID);

                        if (selectedInstructor != null)
                        {
                            // Delete the selected instructor record from the database
                            dbcon.Instructors.DeleteOnSubmit(selectedInstructor);

                            // Also delete the corresponding NetUser record
                            var userToDelete = dbcon.NetUsers.SingleOrDefault(u => u.UserID == selectedInstructorID);
                            if (userToDelete != null)
                            {
                                dbcon.NetUsers.DeleteOnSubmit(userToDelete);
                            }

                            // Submit changes to the database
                            dbcon.SubmitChanges();

                            // Update instructor gridview and dropdown 
                            InstructorGridView.DataBind();
                            instructorIDSelectDropDown.DataBind();
                            refreshGridViews();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Instructor not found.');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., display an error message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                }
            }
            else
            {
                // No instructor selected
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select an instructor to delete.');", true);
            }
        }

        protected void addMemberToSectionBtn_Click(object sender, EventArgs e)
        {
            // Check if both member and section are selected
            if (!string.IsNullOrEmpty(memberIDSelectDropDown.SelectedValue) && !string.IsNullOrEmpty(sectionDropDown.SelectedValue))
            {
                try
                {
                    int selectedMemberID = Convert.ToInt32(memberIDSelectDropDown.SelectedValue);
                    int selectedInstructorID = Convert.ToInt32(instructorIDSelectDropDown.SelectedValue);

                    using (dbcon = new KarateSchoolDataContext(connString))
                    {
                        // Check if the member and section exist
                        var member = dbcon.Members.SingleOrDefault(m => m.Member_UserID == selectedMemberID);
                        var instructor = dbcon.Instructors.SingleOrDefault(i => i.InstructorID == selectedInstructorID);

                        if (member != null && instructor != null)
                        {
                            // Make sure the record doesn't already exist
                            if (!dbcon.Sections.Any(s => s.Instructor_ID == selectedInstructorID && s.Member_ID == selectedMemberID && s.SectionName == sectionDropDown.SelectedValue))
                            {
                                int randFee = new Random().Next(300, 1300);
                                // Create new Section object
                                Section section = new Section
                                {
                                    SectionName = sectionDropDown.SelectedValue,
                                    Instructor_ID = selectedInstructorID,
                                    Member_ID = selectedMemberID,
                                    SectionStartDate = DateTime.Now,
                                    SectionFee = (decimal) randFee
                                };

                                dbcon.Sections.InsertOnSubmit(section);

                                // Submit changes to the database
                                dbcon.SubmitChanges();

                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member added to section successfully.');", true);
                            }
                            else
                            {
                                // Member is already associated with the section
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member is already associated with the selected section.');", true);
                            }
                        }
                        else
                        {
                            // Member or section not found
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Member or section not found.');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., display an error message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                }
            }
            else
            {
                // Member or section not selected
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select both a member and a section.');", true);
            }
        }

    }
}
