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
    class OrganizerController
    {
        DbConnection dbConnection = new DbConnection();

        public void addOrganizer(Organizers organizer)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "INSERT INTO organizers (username, password, contactnumber, email) VALUES " +
                    "(@username, @password, @contact, @email)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", organizer.Name);
                command.Parameters.AddWithValue("@password", organizer.Password);
                command.Parameters.AddWithValue("@contact", organizer.ContactNumbers);
                command.Parameters.AddWithValue("@email", organizer.Email);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Organizer added successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add organizer.");
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
