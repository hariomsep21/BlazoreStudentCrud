using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using StudentCrud.Models.Model;

namespace StudentCrud.UI.Components.Pages.student
{
    public partial class EditStudent
    {
        StudentModel StudentObj;
        bool isLoading = true;

        [Parameter]
        public int StudentId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                StudentObj = await _studentService.GetById(StudentId);
            }
            catch (Exception ex)
            {
                // Handle any errors gracefully
                // Console.Error(ex);
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task HandleSubmit(EditContext editContext)
        {
            if (editContext.Validate())
            {
                try
                {
                  

                    // Update the service with the new StudentObj
                    await _studentService.Update(StudentObj);
                    _navigationManager.NavigateTo("/studentrecord");
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    Console.Error.WriteLine(ex.Message);
                }
            }
        }


        private void Cancel()
        {
            _navigationManager.NavigateTo("/studentrecord");
        }
    }
}
