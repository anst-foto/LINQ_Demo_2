namespace LINQ_Demo;

public class Teacher : Person, IEquatable<Teacher>
{
    private readonly string _faculty;
    public string Faculty
    {
        get => _faculty;
        init => _faculty = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(Faculty))
            : value;
    }
    
    private readonly string _department;
    public string Department
    {
        get => _department;
        init => _department = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(Department))
            : value;
    }

    public bool Equals(Teacher? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && _faculty == other._faculty && _department == other._department;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Teacher)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _faculty, _department);
    }

    public static bool operator ==(Teacher? left, Teacher? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Teacher? left, Teacher? right)
    {
        return !Equals(left, right);
    }
}