﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmergencyClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == Environment.UserName)
            {
                this.Hide();
                MainForm mainForm = new MainForm(loginTextBox.Text, this);
                loginTextBox.Text = string.Empty;
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
