print("Task 28: Employee Dictionary")
employees = {
    '001': {'name': 'John Doe', 'salary': 50000.0},
    '002': {'name': 'Jane Smith', 'salary': 60000.0},
    '003': {'name': 'Bob Johnson', 'salary': 45000.0}
}

print("Employee data:")
for emp_num, data in employees.items():
    print(f"Employee {emp_num}: {data['name']}, Salary: ${data['salary']:.2f}") 