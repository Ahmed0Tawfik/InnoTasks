using ApiClientService;

namespace StudentsApp
{
    public partial class StudentsForm : Form
    {
        List<Student>? students = new();
        Student? displayedStudent = new();

        IApiClient apiClient = new ApiClient(Uri.BaseUri); // made up a apiclient service to use it everywhere

        public StudentsForm()
        {
            InitializeComponent();
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            bool isAgeValid = int.TryParse(StudentAge.Text, out int studentAge);

            Student student = new Student();

            student.Id = 1; // should make it guid
            student.Name = StudentName.Text;
            student.Age = isAgeValid ? studentAge : 18;
            student.Mobile = StudentMobile.Text;

            students?.Add(student);

            Student? studentFromDatabase = await apiClient.PostAsync<Student>(Endpoints.student, student);

            if (studentFromDatabase is not null)
            {
                MessageBox.Show($"Student{studentFromDatabase.Name} was saved successfully with ID:{studentFromDatabase.Id}", "Success");
            }

            Result.Text = $"Student {student.Name} was added successfully, Total students count = {students?.Count}";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            StudentName.Text = string.Empty;
            StudentAge.Text = string.Empty;
            StudentMobile.Text = string.Empty;
        }

        private async void ReadAllStudents_Click(object sender, EventArgs e)
        {
            List<Student>? students = await apiClient.GetAllAsync<Student>(Endpoints.student);

            StudentsGrid.DataSource = students;
        }

        private async void GetStudentById_Click(object sender, EventArgs e)
        {
            displayedStudent = await apiClient.GetById<Student>($"{Endpoints.student}{StudentId.Value}");

            StudentName.Text = displayedStudent?.Name;
            StudentAge.Text = displayedStudent?.Age.ToString();
            StudentMobile.Text = displayedStudent?.Mobile?.ToString();



        }

        private async void UpdateStudent_Click(object sender, EventArgs e)
        {
            // i dont know if put is configured on backend or what does it return it says forbidden // same with delete function
            int age = 0;
            displayedStudent.Name = StudentAge.Text;
            displayedStudent.Age = int.TryParse(StudentAge.Text, out age) ? age : 18;
            displayedStudent.Mobile = StudentMobile.Text;

            Student? updatedStudent = await apiClient.PutAsync<Student>(Endpoints.student, displayedStudent);

            

        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
