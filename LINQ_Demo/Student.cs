namespace LINQ_Demo;

public class Student : Person, IEquatable<Student>
{
    private const int MAX_COURSE = 5;
    private const int MIN_COURSE = 1;
    
    private readonly string _faculty;
    public string Faculty
    {
        get => _faculty;
        init => _faculty = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(Faculty))
            : value;
    }
    
    private readonly int _course;
    public int Course
    {
        get => _course;
        init => _course = value is < MIN_COURSE or > MAX_COURSE
            ? throw new ArgumentOutOfRangeException(nameof(Course)) 
            : value;
    }

    public bool Equals(Student? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && _faculty == other._faculty && _course == other._course;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Student)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _faculty, _course);
    }

    public static bool operator ==(Student? left, Student? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Student? left, Student? right)
    {
        return !Equals(left, right);
    }
}