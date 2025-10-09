namespace BlazorAppStandAlone.Components;

public partial class Students
{
    private Student student = new();
    List<Student> students = new List<Student>();
    private Toast? toast = new();

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await FillStudents();

       
    } 
    

    private async Task HandleValidSubmit()
    {
        string studentSerialized = JsonSerializer.Serialize(student);

        Student? validStudent = JsonSerializer.Deserialize<Student>(studentSerialized);

        bool isEditing = students.Any(s => s.Name == validStudent?.Name);

        if (isEditing)
        {
            var result = await apiClient.PutAsync<Student>("", validStudent!);
            if (result.Success)
            {
                await toast?.ShowToast("Student updated successfully!")!;
            }
            else
            {
                await toast?.ShowToast($"Error updating student: {result.Error}")!;
            }
            return;
        }

        if (validStudent is not null)
        {
            var result = await apiClient.PostAsync<Student>("", validStudent);
            if (result.Success)
            {
                await toast?.ShowToast("Student submitted successfully!")!;
            }
            else
            {
                await toast?.ShowToast($"Error submitting student: {result.Error}")!;
            }
            return;
        }

        await toast?.ShowToast("Error Submitting Student")!;
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
        if (result.Success && result.Data is not null)
        {
            students = result.Data;
        }
        else if (!result.Success)
        {
            await toast?.ShowToast($"Error loading students: {result.Error}")!;
        }
        StateHasChanged();
    }

}