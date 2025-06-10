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
    class EventController
    {
        DbConnection dbConnection = new DbConnection();
        public void CreateEvent(Events events)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "INSERT INTO events (name, date, description, location, organizer_id) " +
                               "VALUES (@eventname, @eventdate, @eventdescription, @eventlocation, @organizerid)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventname", events.EventName);
                command.Parameters.AddWithValue("@eventdate", events.EventDate);
                command.Parameters.AddWithValue("@eventdescription", events.EventDescription);
                command.Parameters.AddWithValue("@eventlocation", events.EventLocation);
                command.Parameters.AddWithValue("@organizerid", events.Organizer.Id);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Event created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create event.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
