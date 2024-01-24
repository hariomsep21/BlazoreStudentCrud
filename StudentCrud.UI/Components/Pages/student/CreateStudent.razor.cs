using StudentCrud.Models.Model;

namespace StudentCrud.UI.Components.Pages.student
{
    public partial class CreateStudent
    {
        StudentModel obj = new StudentModel();

        private async Task CreateNewStudent()
        {
            Console.WriteLine("CreateNewStudent method called."); // Add this line for debugging
            await _createService.Create(obj);
            NavigationManager.NavigateTo("studentrecord");
        }

        private void Cancel()
        {
            NavigationManager.NavigateTo("studentrecord");
        }
    }
}
