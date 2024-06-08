namespace AidManager.API.Authentication.Domain.Model.ValueObjects;

public class FirstName
{
    public string firstName { get; private set; }
    public FirstName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Field cannot be empty");
        }
        if (value.Any(char.IsDigit))
        {
            throw new ArgumentException("Field cannot contain digits");
        }
        if (value.Length > 50)
        {
            throw new ArgumentException("Field cannot be longer than 50 characters");
        }
        this.firstName = value;
    }

    public string getFirstName()
    {
        return this.firstName;
    }
}