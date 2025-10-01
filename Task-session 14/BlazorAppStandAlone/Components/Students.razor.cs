namespace BlazorAppStandAlone.Components;

public partial class Students
{
    private Student student = new();
    List<Student> students = new List<Student>();
    private Toast toast;
    
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        await FillStudents();


        if (firstRender)
        {
            
            
            student.Name = "Wael Shehab Eldin";
            student.Mobile = "01207888335";
            student.Telephone = "0403335102";
            student.Email = "wael@innotech.com.eg";
            student.Age = 44;
            student.Message = "Just Testing......";

            
        }

        StateHasChanged();
    }

    private async Task HandleValidSubmit()
    {
        string studentSerialized = JsonSerializer.Serialize(student);

        Student? validStudent = JsonSerializer.Deserialize<Student>(studentSerialized);

        bool isEditing = students.Any(s => s.Name == validStudent.Name);

        if (isEditing)
        {
            Student? result = await apiClient.PutAsync<Student>("", validStudent);

            if(result is not null)
                await toast.ShowToast("Student Editied successfully!");
            return;
        }

        if (validStudent is not null)
        {
            Student? result = await apiClient.PostAsync<Student>("",validStudent);
            if(result is not null)
                await toast.ShowToast("Student submitted successfully!");
            return;
        }

        await toast.ShowToast("Error Submitting Student");
        StateHasChanged();
    }
    private void EditStudent(Student toBeEditedStudent)
    {
        student = toBeEditedStudent;

        StateHasChanged();
    }

    private async Task FillStudents()
    {
        var result = await apiClient.GetAllAsync<Student>("");

        students = result ?? students;

    }

    
}