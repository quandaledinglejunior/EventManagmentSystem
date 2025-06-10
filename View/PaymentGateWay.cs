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
    public partial class PaymentGateWay: Form
    {
        public PaymentGateWay()
        {
            InitializeComponent();
        }

        private void PaymentGateWay_Load(object sender, EventArgs e)
        {
            //datetimepick should be empty
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //set the default value of the card type to visa
            radioButton1.Checked = true;
        }
    }
}
