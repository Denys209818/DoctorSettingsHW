using DoctorLibrary.DAL.Classes;
using DoctorLibrary.DAL.Helper;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace DoctorMain
{
    /// <summary>
    ///     Головна сторінка для лікарів
    /// </summary>
    public partial class CreateDoctor : Form
    {
        public static string oldPath;
        public static readonly string path = Assembly.GetExecutingAssembly().Location + @"\..\..\..\..\Images\";
        public string Login { get; set; }
        public string Password { get; set; }

        public CreateDoctor()
        {
            InitializeComponent();
        }
        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opdlg = new OpenFileDialog();
            opdlg.AddExtension = true;
            opdlg.DefaultExt = ".jpg";
            opdlg.Title = "Оберіть зображення";
            opdlg.CheckFileExists = true;
            opdlg.CheckPathExists = true;
            opdlg.Filter = "JPG files|*.jpg|PNG files|*.png";
            opdlg.ShowDialog();
            string imgPath = opdlg.FileName;
            if (File.Exists(imgPath))
            {
                FileInfo file = new FileInfo(imgPath);
                lblRef.Text = file.Name;
                oldPath = imgPath;
            }
        }
       
        private void CreateDoctor_Load(object sender, EventArgs e)
        {
            Context context = new Context();
            foreach (var item in context.departments)
            {
                DepartmentsList.Items.Add(item.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] settings =
            {
            txtName.Text,
            txtSurname.Text,
            txtLogin.Text,
            txtPassword.Text,
            lblRef.Text,
            DepartmentsList.Text
            };

            foreach (var item in settings)
            {
                if (string.IsNullOrEmpty(item))
                {
                    MessageBox.Show("Заповніть усі поля!");
                    this.DialogResult = DialogResult.No;
                    return;
                }
            }

            Context context = new Context();
            Doctor doc = new Doctor
            {
                FirstName = settings[0],
                LastName = settings[1],
                Login = settings[2],
                Password = PasswordManager.HashPassword(settings[3]),
                department = context.departments.Where(x => x.Name == settings[5]).FirstOrDefault()
            };

            if (lblRef.Text != "Силка на зображення")
            {
                doc.Image = lblRef.Text;
            }

            File.Copy(oldPath, path + lblRef.Text, true);

            context.doctors.Add(doc);

            context.SaveChanges();
            Login = settings[2];
            Password = settings[3];
            this.DialogResult = DialogResult.OK;
        }
    }
}
