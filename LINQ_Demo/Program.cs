using LINQ_Demo;

var marks = new List<Mark>() 
{
    new()
    {
        Date = new DateTime(2020, 1, 1),
        Value = 5,
        Subject = "Statistics",
        Student = new Student
        {
            LastName = "Smith", 
            FirstName = "John", 
            DateOfBirth = new DateTime(1989, 1, 1), 
            Faculty = "Computer Science", 
            Course = 1
        },
        Teacher = new Teacher
        {
            LastName = "Doe", 
            FirstName = "Jane", 
            DateOfBirth = new DateTime(1980, 1, 1), 
            Faculty = "Computer Science", 
            Department = "Data Science"
        }
    },
    new()
    {
        Date = new DateTime(2020, 1, 1),
        Value = 5,
        Subject = "Statistics",
        Student = new Student
        {
            LastName = "Smith", 
            FirstName = "John", 
            DateOfBirth = new DateTime(1989, 1, 1), 
            Faculty = "Computer Science", 
            Course = 1
        },
        Teacher = new Teacher
        {
            LastName = "Doe", 
            FirstName = "Jane", 
            DateOfBirth = new DateTime(1980, 1, 1), 
            Faculty = "Computer Science", 
            Department = "Data Science"
        }
    },
    new()
    {
        Date = new DateTime(2020, 1, 2),
        Value = 3,
        Subject = "Statistics",
        Student = new Student
        {
            LastName = "Smith",
            FirstName = "John",
            DateOfBirth = new DateTime(1989, 1, 1),
            Faculty = "Computer Science", 
            Course = 1
        },
        Teacher = new Teacher
        {
            LastName = "Doe", 
            FirstName = "Jane", 
            DateOfBirth = new DateTime(1980, 1, 1), 
            Faculty = "Computer Science", 
            Department = "Data Science"
        }
    }
};

var teacher = new Teacher()
{
    LastName = "Doe",
    FirstName = "Jane",
    DateOfBirth = new DateTime(1980, 1, 1),
    Faculty = "Computer Science",
    Department = "Data Science"
};
var mapMarks = marks
    .Where(m => m.Teacher == teacher)
    .GroupBy(m => m.Value)
    .ToDictionary(
        g => g.Key, 
        g => g
            .Select(m => new
            {
                StudentName = m.Student.FullName, 
                Date = m.Date.ToString("d"),
                m.Subject,
            }));

foreach (var (markValue, listOfMark) in mapMarks)
{
    var list = string.Join(", ", listOfMark.Select(m => $"{m.StudentName} ({m.Date}) [{m.Subject}]"));
    Console.WriteLine($"{markValue}: {list}");
}
