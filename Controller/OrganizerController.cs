﻿using EventManagmentSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                string query = "INSERT INTO organizer (name, password, contactnumber, email, gender) VALUES " +
                    "(@username, @password, @contact, @email, @Gender)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", organizer.Name);
                command.Parameters.AddWithValue("@password", organizer.Password);
                command.Parameters.AddWithValue("@contact", organizer.ContactNumbers);
                command.Parameters.AddWithValue("@email", organizer.Email);
                command.Parameters.AddWithValue("@gender", organizer.Gender);
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


        public void DeleteOrganizer(string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "DELETE FROM organizer WHERE name = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Organizer deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete organizer.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void DeleteTicketsByOrganizerId(int organizerId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();

                string query = @"DELETE t FROM ticket t
                         JOIN events e ON t.event_id = e.id
                         WHERE e.organizer_id = @orgId";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@orgId", organizerId);

                int result = command.ExecuteNonQuery();
                MessageBox.Show($"{result} ticket(s) deleted.");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting tickets: " + ex.Message);
            }
        }


        public string getOrganizerPassword(string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT password FROM organizer WHERE name = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                string password = command.ExecuteScalar()?.ToString();
                connection.Close();
                return password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public List<string> GetAllOrganizerUsernames()
        {
            List<string> usernames = new List<string>();

            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT name FROM organizer";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usernames.Add(reader["name"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return usernames;
        }


        public int getOrganizerId(string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT id FROM organizer WHERE name = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1; // Return -1 to indicate an error
            }
        }

        public Organizers getOrganizersfromId(int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT * FROM organizer WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Organizers organizer = new Organizers(
                        reader["name"].ToString(),
                        reader["password"].ToString(),
                        reader["contactnumber"].ToString(),
                        reader["email"].ToString(),
                        reader["gender"].ToString()
                    );
                    organizer.Id = Convert.ToInt32(reader["id"]);
                    connection.Close();
                    return organizer;
                }
                else
                {
                    connection.Close();
                    return null; // No organizer found with the given ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public void UpdateOrganizer(int id, string name, string password, string contact, string email, string gender)
        {
            try
            {
                using (var conn = new MySqlConnection(dbConnection.connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE organizer SET name=@nm, password=@pw, contactnumber=@ct, email=@em, gender=@gn WHERE id=@id",
                        conn
                    );
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nm", name);
                    cmd.Parameters.AddWithValue("@pw", password);
                    cmd.Parameters.AddWithValue("@ct", contact);
                    cmd.Parameters.AddWithValue("@em", email);
                    cmd.Parameters.AddWithValue("@gn", gender);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating organizer: " + ex.Message);
            }
        }

        public DataTable getEventDetails(int event_id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();

                string query = @"SELECT 
                                    a.name AS 'Attendee Name',
                                    a.contactnumber AS 'Attendee Contact',
                                    p.quantity AS 'Tickets Bought',
                                    p.total AS Total,
                                    t.tickettype AS 'Ticket Type'
                                FROM 
                                    purchase p
                                JOIN 
                                    attendee a ON p.attendee_id = a.id
                                JOIN 
                                    ticket t ON p.ticket_id = t.id
                                WHERE 
                                    t.event_id = @event_id;
                                ";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@event_id", event_id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                connection.Close();
                return dataTable; // Return the DataTable containing event details
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null; // Return null in case of an error
            }
        }
    }
}
