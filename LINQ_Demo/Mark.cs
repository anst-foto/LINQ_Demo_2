namespace LINQ_Demo;

public class Mark
{
    private const int MIN_MARK = 1;
    private const int MAX_MARK = 10;
    
    private readonly DateTime _date;
    public DateTime Date
    {
        get => _date;
        init => _date = value.Date > DateTime.Today.Date 
            ? throw new ArgumentOutOfRangeException(nameof(Date)) 
            : value;
    }
    
    private readonly int _value;
    public int Value
    {
        get => _value;
        init => _value = value is <= MIN_MARK or > MAX_MARK
            ? throw new ArgumentOutOfRangeException(nameof(Value)) 
            : value;
    }
    
    private readonly string _subject;
    public string Subject
    {
        get => _subject;
        init => _subject = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(Subject))
            : value;
    }
    
    private readonly Student _student;
    public Student Student
    {
        get => _student;
        init => _student = value ?? throw new ArgumentNullException(nameof(Student));
    }
    
    private readonly Teacher _teacher;
    public Teacher Teacher
    {
        get => _teacher;
        init => _teacher = value ?? throw new ArgumentNullException(nameof(Teacher));
    }
}