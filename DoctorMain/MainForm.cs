using DoctorLibrary.DAL.Classes;
using DoctorLibrary.DAL.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorMain
{
    public partial class MainForm : Form
    {
        public string deHashPassword { get; set; }
        public bool isVis { get; set; } = false;
        public Context context { get; set; }
        public Doctor doctor { set; get; }

        public bool isAuth { get; set; } = false;
        public MainForm()
        {
            LoginForm dlg = new LoginForm();
            
            switch (dlg.ShowDialog()) 
            {
                case DialogResult.OK: 
                    {
                        isAuth = true;
                        doctor = dlg.doctor;
                        context = new Context();
                        deHashPassword = dlg.Password;
                        break;
                    }
            }
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (isAuth)
            {
                lblName.Text = "Ім'я: " + doctor.FirstName;
                lblSurname.Text = "Прізвище: " + doctor.LastName;
                lblDepartmentName.Text = "Назва відділення: " + context.departments.Where(x => x.Id == doctor.DepartmentId).First().Name;
                lblLogin.Text = "Логін: " + doctor.Login;
                lblPassword.Text = "Пароль: ";
                Avatar.Image = Image.FromFile(@$"{CreateDoctor.path}\{doctor.Image}");
            }
            else 
            {
                Application.Exit();
            }
        }

        private void llblPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isVis == false) 
            {
                isVis = true;
                lblPassword.Text = "Пароль: " + deHashPassword;
            }
            else 
            {
                lblPassword.Text = "Пароль: ";
                isVis = false; 
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
