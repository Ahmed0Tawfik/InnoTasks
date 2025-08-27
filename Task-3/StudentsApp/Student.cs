namespace StudentsApp;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Mobile { get; set; }

    public override string ToString()
    {
        return $"Id:{Id}\nName:{Name}\nAge:{Age}\nMobile{Mobile}";
    }
}