namespace BlazorAppStandAlone.Components;

public partial class Toast
{
    private bool Show { get; set; }
    private string Message { get; set; } = "";

    public async Task ShowToast(string message)
    {
        Message = message;
        Show = true;
        StateHasChanged();

        await Task.Delay(3000);
        Show = false;
        StateHasChanged();
    }
}