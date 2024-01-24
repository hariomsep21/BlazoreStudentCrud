using StudentCrud.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Services.Interface
{
    public interface IStudentInterface
    {
        Task<IEnumerable<StudentModel>> GetStudents();
        Task<StudentModel> GetById(int id);
        Task<StudentModel> Create(StudentModel student);
        Task<StudentModel> Update(StudentModel student);
        Task<StudentModel> Delete(int id);


    }
}
