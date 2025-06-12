namespace EventManagmentSystem.View
{
    partial class RemoveOrganizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1RO = new System.Windows.Forms.CheckBox();
            this.checkBox2RO = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRO = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.button1.Location = new System.Drawing.Point(479, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1RO
            // 
            this.checkBox1RO.AutoSize = true;
            this.checkBox1RO.Font = new System.Drawing.Font("Lucida Bright", 7.875F);
            this.checkBox1RO.Location = new System.Drawing.Point(61, 253);
            this.checkBox1RO.Name = "checkBox1RO";
            this.checkBox1RO.Size = new System.Drawing.Size(230, 27);
            this.checkBox1RO.TabIndex = 1;
            this.checkBox1RO.Text = "Remove Organizer";
            this.checkBox1RO.UseVisualStyleBackColor = true;
            this.checkBox1RO.CheckedChanged += new System.EventHandler(this.checkBox1RO_CheckedChanged);
            // 
            // checkBox2RO
            // 
            this.checkBox2RO.AutoSize = true;
            this.checkBox2RO.Font = new System.Drawing.Font("Lucida Bright", 7.875F);
            this.checkBox2RO.Location = new System.Drawing.Point(61, 286);
            this.checkBox2RO.Name = "checkBox2RO";
            this.checkBox2RO.Size = new System.Drawing.Size(196, 27);
            this.checkBox2RO.TabIndex = 2;
            this.checkBox2RO.Text = "Remove Events";
            this.checkBox2RO.UseVisualStyleBackColor = true;
            this.checkBox2RO.CheckedChanged += new System.EventHandler(this.checkBox2RO_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.label1.Location = new System.Drawing.Point(61, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Organizer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxRO
            // 
            this.comboBoxRO.Font = new System.Drawing.Font("Lucida Bright", 12F);
            this.comboBoxRO.FormattingEnabled = true;
            this.comboBoxRO.Location = new System.Drawing.Point(67, 143);
            this.comboBoxRO.Name = "comboBoxRO";
            this.comboBoxRO.Size = new System.Drawing.Size(355, 44);
            this.comboBoxRO.TabIndex = 4;
            this.comboBoxRO.SelectedIndexChanged += new System.EventHandler(this.comboBoxRO_SelectedIndexChanged);
            // 
            // RemoveOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 374);
            this.Controls.Add(this.comboBoxRO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2RO);
            this.Controls.Add(this.checkBox1RO);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoveOrganizer";
            this.Text = "RemoveOrganizer";
            this.Load += new System.EventHandler(this.RemoveOrganizer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1RO;
        private System.Windows.Forms.CheckBox checkBox2RO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRO;
    }
}