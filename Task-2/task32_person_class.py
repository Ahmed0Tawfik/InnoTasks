from datetime import datetime

print("Task 32: Person Class")
class Person:
    def __init__(self, name, country, birth_date):
        self.name = name
        self.country = country
        self.birth_date = birth_date
    
    def age(self):
        birth = datetime.strptime(self.birth_date, "%Y-%m-%d")
        today = datetime.now()
        return today.year - birth.year - ((today.month, today.day) < (birth.month, birth.day))

name = "Alice Johnson"
country = "USA"
birth_date = "1990-05-15"
person = Person(name, country, birth_date)
print(f"Name: {person.name}")
print(f"Country: {person.country}")
print(f"Age: {person.age()} years") 