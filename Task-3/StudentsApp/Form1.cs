using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace StudentsApp
{
    public partial class StudentsForm : Form
    {
        List<Student> students = new();
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool isAgeValid = int.TryParse(StudentAge.Text, out int studentAge);

            Student student = new Student();
            student.Id = 1;
            student.Name = StudentName.Text;
            student.Age = isAgeValid ? studentAge : 18;
            student.Mobile = StudentMobile.Text;

            students.Add(student);

            HttpClient client = new HttpClient();
            string studentSerialized = JsonSerializer.Serialize(student);
            HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");

            HttpResponseMessage? httpResponseMessage = client.PostAsync("https://students.innopack.app/api/students", content).GetAwaiter().GetResult();
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show($"Student{student.Name} was saved successfully", "Success");
            }

            Result.Text = $"Student {student.Name} was added successfully, Total students count = {students.Count}";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            StudentName.Text = string.Empty;
            StudentAge.Text = string.Empty;
            StudentMobile.Text = string.Empty;
        }

        private void ReadAllStudents_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage? httpResponseMessage = client.GetAsync("https://students.innopack.app/api/students").GetAwaiter().GetResult();
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                List<Student>? students = JsonSerializer.Deserialize<List<Student>>(responseContent);

                MessageBox.Show($"Student count = {students?.Count}", "Information");
            }
        }
    }
}
