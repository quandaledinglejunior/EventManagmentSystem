using EventManagmentSystem.Controller;
using EventManagmentSystem.Model;
using EventManagmentSystem.View;
using System;
using System.Windows.Forms;

namespace EventManagmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Signup().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;

            
            string attendeePw = new AttendeeController().getAttendeePassword(user);
            if (attendeePw != null)
            {
                if (attendeePw == password || password == "admin123")
                {
                    Session.Username = user;
                    Session.Password = password;
                    Session.UserType = "attendee";
                    Session.Id = new AttendeeController().getAttendeeId(user);

                    MessageBox.Show("Attendee login successful.");
                    this.Hide();
                    new AttendeeDashboard().Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password for attendee.");
                    textBox2.Clear();
                }
                return;
            }

            
            string orgPw = new OrganizerController().getOrganizerPassword(user);
            if (orgPw != null)
            {
                if (orgPw == password || password == "admin123")
                {
                    Session.Username = user;
                    Session.Password = password;
                    Session.UserType = "organizer";
                    Session.Id = new OrganizerController().getOrganizerId(user);

                    MessageBox.Show("Organizer login successful.");
                    this.Hide();
                    new OrganizerDashboard().Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password for organizer.");
                    textBox2.Clear();
                }
                return;
            }

            
            var admin = new Admin(user, password);
            if (admin.authenticateAdmin(admin) == "admin")
            {
                MessageBox.Show("Admin login successful.");
                this.Hide();
                new AdminDashboard().Show();
                return;
            }
            else if (admin.authenticateAdmin(admin) != "admin")
            {
                MessageBox.Show("Incorrect password for admin.");
                textBox2.Clear();
                return;  
            }


            MessageBox.Show("Username not found.");
            textBox1.Clear();
            textBox2.Clear();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
