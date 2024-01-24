using StudentCrud.Models.Model;

namespace StudentCrud.UI.Components.Pages.student
{
    public partial class Student
    {
        IEnumerable<StudentModel> EmpObj;

        protected override async Task OnInitializedAsync()
        {
            EmpObj = await _studentService.GetStudents();
        }

        // Method to handle the deletion of a student
        private async Task DeleteStudent(int studentId)
        {
            // Implement your logic to delete the student using _studentService
            await _studentService.Delete(studentId);
            // Refresh the list after deletion
            EmpObj = await _studentService.GetStudents();
        }
    }
}
