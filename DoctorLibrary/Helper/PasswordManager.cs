using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorLibrary.DAL.Helper
{
    /// <summary>
    ///     Клас для роботи з паролями
    /// </summary>
    public class PasswordManager
    {
        /// <summary>
        ///     Метод який зашифровує пароль
        /// </summary>
        /// <param name="password">Приймає строку пароля</param>
        /// <returns></returns>
        public static string HashPassword(string password) 
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        /// <summary>
        ///     Метод який перевіряє на коректність пароль
        /// </summary>
        /// <param name="password">строка пароля</param>
        /// <param name="hashPassword">зашифрована строка пароля</param>
        /// <returns></returns>
        public static bool Verify(string password, string hashPassword) 
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
