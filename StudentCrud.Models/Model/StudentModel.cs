using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Models.Model
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

        public string? Phone { get; set; }
    }
}
