using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.UserProfile.Domain.Model.Commands;

namespace AidManager.API.Authentication.Domain.Model.Entities;

public class User
{
    public int Id { get; private set; }
    public string FirstName
    {
        get => _firstName; 
        private set {
            ValidateAlphabeticField(value);
            _firstName = value;
        }
    }
    public string LastName 
    {
        get => _lastName; 
        private set {
            ValidateAlphabeticField(value);
            _lastName = value;
        }
    }
    public int Age
    {
        get => _age;
        private set {
            //ValidateNumericField(value);
            _age = value;
        }
    }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Occupation
    {
        get => _occupation;
        private set {
            //ValidateAlphabeticField(value);
            _occupation = value;
        }
    }    
    public string Password { get; private set; }
    public string ProfileImg { get; private set; }
    
    public string CompanyId { get; set; }
    public string Role
    {
        get => _role;
        private set {
            ValidateAlphabeticField(value);
            _role = value;
        }
    }
    public string CompanyName {get; set;}
    public string Bio { get; private set; }
    
    public ICollection<Post> Posts { get; set; }
    
    public User(string FirstName, string LastName, int Age, string Email, string Phone, string Occupation, string Password, string ProfileImg, string Role,
        string CompanyName, string Bio, string CompanyId)
    {
        
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Age = Age;
        this.Email = Email;
        this.Phone = Phone;
        this.Occupation = Occupation;
        this.Password = Password;
        this.ProfileImg = ProfileImg;
        this.Role = Role;
        this.CompanyName = CompanyName;
        this.Bio = Bio;
        this.CompanyId = CompanyId;
    }
    
    public void updateProfile(UpdateUserCommand command)
    {
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        this.Age = command.Age;
        this.Phone = command.Phone;
        this.Occupation = command.Occupation;
        this.ProfileImg = command.ProfileImg;
        this.Bio = command.Bio;
        this.CompanyId = command.CompanyId;
    }
    
    private void ValidateAlphabeticField(string field)
    {
        if (string.IsNullOrEmpty(field)) {
            throw new ArgumentException("Field cannot be empty");
        }
        if (field.Any(char.IsDigit)) {
            throw new ArgumentException("Field cannot contain digits");
        }
    }
    
    private void ValidateNumericField(int field)
    {
        if (field < 0)
        {
            throw new ArgumentException("Field cannot be negative");
        }
        if (field.ToString().Any(char.IsLetter))
        {
            throw new ArgumentException("Field cannot contain letters");
        }
    }
    
    private string _firstName;
    private string _lastName;
    private int _age;
    private string _email;
    private string _occupation;
    private string _role;
    private string _companyName;

}