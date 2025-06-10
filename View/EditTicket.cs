﻿using EventManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagmentSystem.View
{
    public partial class EditTicket: Form
    {
        public EditTicket()
        {
            InitializeComponent();
        }

        int ticketId;

        private void EditTicket_Load(object sender, EventArgs e)
        {
            List<Events> events = new Controller.EventController().getEventsbyOrganizer(Session.Id);

            if (events.Count > 0)
            {
                comboBox1.DataSource = events;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No events found for the organizer.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eventId = (int)comboBox1.SelectedValue;
            string ticketType = comboBox2.Text;

            Ticket selectedTicket = new Controller.TicketController().getTickeybyEventandType(eventId, ticketType);

            if (selectedTicket != null)
            {
                textBox1.Text = selectedTicket.Price.ToString();
                textBox2.Text = selectedTicket.Quantity.ToString();
                comboBox3.Text = selectedTicket.Available.ToString();
                ticketId = selectedTicket.Id;
            }
            else
            {
                MessageBox.Show("Ticket not found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int eventId = (int)comboBox1.SelectedValue;
            string ticketType = comboBox2.Text;
            double price = textBox1.Text == "" ? 0 : double.Parse(textBox1.Text);
            int quantity = textBox2.Text == "" ? 0 : int.Parse(textBox2.Text);

            if (!double.TryParse(textBox1.Text, out price) || !int.TryParse(textBox2.Text, out quantity))
            {
                MessageBox.Show("Please enter valid price and quantity.");
                return;
            }

            bool available = Convert.ToBoolean(comboBox3.Text);

            Ticket updatedTicket = new Ticket(new Controller.EventController().getEventById(eventId), ticketType, price, quantity)
            {
                Available = available,
                Id = ticketId
            };

        }
    }
}
