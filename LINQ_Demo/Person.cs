namespace LINQ_Demo;

public abstract class Person : IEquatable<Person>
{
    private readonly string _lastName;
    public string LastName
    {
        get => _lastName;
        init => _lastName = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(LastName))
            : value;
    }

    private readonly string _firstName;
    public string FirstName
    {
        get => _firstName;
        init => _firstName = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(FirstName))
            : value;
    }

    public string FullName => $"{LastName} {FirstName}";

    private readonly DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        init => _dateOfBirth = value.Date > DateTime.Today.Date 
            ? throw new ArgumentOutOfRangeException(nameof(DateOfBirth)) 
            : value;
    }
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - _dateOfBirth.Year;
            if (_dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public bool Equals(Person? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _lastName == other._lastName && _firstName == other._firstName && _dateOfBirth.Equals(other._dateOfBirth);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_lastName, _firstName, _dateOfBirth);
    }

    public static bool operator ==(Person? left, Person? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Person? left, Person? right)
    {
        return !Equals(left, right);
    }
}