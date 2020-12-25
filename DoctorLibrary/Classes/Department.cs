using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoctorLibrary.DAL.Classes
{
    /// <summary>
    ///     Клас, який використовується для роботи з відділами
    /// </summary>
    [Table("tblDepartments")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, Range(0, 1000)]
        public int CabinetNumber { get; set; }
    }
}
