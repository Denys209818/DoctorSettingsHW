using DoctorLibrary.DAL.Classes;
using DoctorLibrary.DAL.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoctorMain
{
    public partial class LoginForm : Form
    {
        public string Password { get; set; }
        public Doctor doctor { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            string login = txtLogin.Text;
            Password = txtPasswod.Text;

            doctor = context.doctors.Where(doc => doc.Login == login).FirstOrDefault();
            if (doctor != null)
            {
                if (PasswordManager.Verify(Password, doctor.Password))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else 
                {
                    MessageBox.Show("Некоректний пароль!");
                }
            }
            else
            {
                MessageBox.Show($"Не існує аккаунта!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateDoctor dlg = new CreateDoctor();
            switch (dlg.ShowDialog()) 
            {
                case DialogResult.OK: 
                    {
                        txtLogin.Text = dlg.Login;
                        txtPasswod.Text = dlg.Password;
                        break;
                    }
            }
        }
    }
}
