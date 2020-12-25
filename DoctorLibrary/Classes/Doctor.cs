using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoctorLibrary.DAL.Classes
{
    /// <summary>
    ///     Клас, який викорстовується для роботи з лікарями
    /// </summary>
    [Table("tblDoctors")]
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string FirstName { get; set; }
        [Required, StringLength(255)]
        public string LastName { get; set; }
        [ForeignKey("department.Id")]
        public int DepartmentId { get; set; }
        [Required, StringLength(255)]
        public string Login { get; set; }
        [Required,StringLength(255)]
        public string Password { get; set; }
        public string Image { get; set; }

        public virtual Department department { get; set; }
    }
}
