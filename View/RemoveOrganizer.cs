﻿using EventManagmentSystem.Controller;
using System;
using System.Windows.Forms;

namespace EventManagmentSystem.View
{
    public partial class RemoveOrganizer : Form
    {
        public RemoveOrganizer()
        {
            InitializeComponent();
        }

        private void RemoveOrganizer_Load(object sender, EventArgs e)
        {
            OrganizerController controller = new OrganizerController();
            comboBoxRO.DataSource = controller.GetAllOrganizerUsernames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedOrganizer = comboBoxRO.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedOrganizer))
            {
                MessageBox.Show("Please select an organizer.");
                return;
            }

            bool removeOrganizer = checkBox1RO.Checked;
            bool removeEvents = checkBox2RO.Checked;

            if (!removeOrganizer && !removeEvents)
            {
                MessageBox.Show("Please select at least one option to delete.");
                return;
            }

            OrganizerController organizerController = new OrganizerController();
            EventController eventController = new EventController();

            if (removeEvents)
            {
                eventController.DeleteEventsByOrganizer(selectedOrganizer);
            }

            if (removeOrganizer)
            {
                eventController.DeleteEventsByOrganizer(selectedOrganizer);
                organizerController.DeleteOrganizer(selectedOrganizer);
            }

            // Refresh dropdown after deletion
            comboBoxRO.DataSource = null;
            comboBoxRO.DataSource = organizerController.GetAllOrganizerUsernames();

            checkBox1RO.Checked = false;
            checkBox2RO.Checked = false;

        }

        private void comboBoxRO_SelectedIndexChanged(object sender, EventArgs e) { }
        private void checkBox1RO_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2RO_CheckedChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
