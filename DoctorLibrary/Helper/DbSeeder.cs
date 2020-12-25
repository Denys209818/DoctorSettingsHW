using DoctorLibrary.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorLibrary.DAL.Helper
{
    /// <summary>
    ///     Клас для початкового заповнення даннимим БД
    /// </summary>
    public class DbSeeder
    {
        /// <summary>
        ///     Метод який початково заповнює данними БД
        /// </summary>
        /// <param name="context">Приймає клас для роботи з БД</param>
        public static void SeedAll(Context context) 
        {
            SeedDepartments(context);
            SeedDoctors(context);
        }
        /// <summary>
        ///     Початково ініціалізовує БД лікарями
        /// </summary>
        /// <param name="context">Приймає клас для роботи з БД</param>
        public static void SeedDoctors(Context context) 
        {
            if (context.doctors.Count() == 0) 
            {
                context.doctors.Add(
                    new Doctor
                    {
                        FirstName = "Oleg",
                        LastName = "Petrov",
                        department = context.departments.FirstOrDefault(x => x.Name == "Хірургія"),
                        Login = "login",
                        Password = PasswordManager.HashPassword("password"),
                        Image = "1.jpg"
                    });

                context.doctors.Add(
                    new Doctor
                    {
                        FirstName = "Vasja",
                        LastName = "Ivanov",
                        department = context.departments.FirstOrDefault(x => x.Name == "Інфекційне"),
                        Login = "vasja",
                        Password = PasswordManager.HashPassword("pass"),
                        Image = "1.jpg"
                    }
                    );

                context.SaveChanges();
            }
        }
        /// <summary>
        ///     Початково ініціалізовує БД відділеннями
        /// </summary>
        /// <param name="context">Приймає клас для роботи з БД</param>
        public static void SeedDepartments(Context context) 
        {
            if (context.departments.Count() == 0) 
            {
                context.departments.Add(
                new Department
                {
                    Name = "Хірургія",
                    CabinetNumber = 2
                }
                );

                context.departments.Add(
                new Department
                {
                    Name = "Інфекційне",
                    CabinetNumber = 1
                }
                );

                context.SaveChanges();
            }
        }
    }
}
