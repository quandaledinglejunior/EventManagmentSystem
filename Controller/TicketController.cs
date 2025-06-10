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
    class TicketController
    {
        DbConnection dbConnection = new DbConnection();

        public void CreateTicket(Ticket ticket)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "INSERT INTO ticket (event_id, tickettype, price, quantity, available) VALUES (@eventid, @tickettype, @price, @quantity, @available)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventid", ticket.Event.Id);
                command.Parameters.AddWithValue("@tickettype", ticket.TicketType);
                command.Parameters.AddWithValue("@price", ticket.Price);
                command.Parameters.AddWithValue("@quantity", ticket.Quantity);
                command.Parameters.AddWithValue("@available", ticket.Available);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Ticket created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create ticket.");
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
