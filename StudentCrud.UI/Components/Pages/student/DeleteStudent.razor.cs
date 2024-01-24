using Microsoft.AspNetCore.Components;
using StudentCrud.Models.Model;

namespace StudentCrud.UI.Components.Pages.student
{
    public partial class DeleteStudent
    {
        StudentModel StudentObj;

        [Parameter]
        public int StudentId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            StudentObj = await _studentService.GetById(StudentId);

            // Automatically call the Delete method
            await Delete();
        }

        private async Task Delete()
        {
            await _studentService.Delete(StudentId);
            _navigationManager.NavigateTo("/studentrecord");
        }
    }
}
