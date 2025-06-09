using EventManagmentSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagmentSystem.Controller
{
    class AttendeeController
    {
        DbConnection dbConnection = new DbConnection();
        public void addAttendee(Attendee attendee)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();

                string query = "INSERT INTO attendee (name, password, contactnumber, gender) value " +
                    "(@name, @pasword, @contactnumber, @gender)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", attendee.Name);
                command.Parameters.AddWithValue("@pasword", attendee.Password);
                command.Parameters.AddWithValue("@contactnumber", attendee.ContactNumbers);
                command.Parameters.AddWithValue("@gender", attendee.Gender);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Attendee added successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add attendee.");
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            

        }
    }
}
