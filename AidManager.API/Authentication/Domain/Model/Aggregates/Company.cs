using AidManager.API.Authentication.Domain.Model.Commands;

namespace AidManager.API.Authentication.Domain.Model.Aggregates;

public class Company
{
    public int Id { get; private set; }
     public string BrandName { get; private set; }
     public string IdentificationCode { get; private set; }
     public string Country { get; private set; }
     public string Phone {get; private set; }
     public int UserId { get; private set; }
     
     public Company(string brandName, string identificationCode, string country, string phone, int userId)
     {
         BrandName = brandName;
         IdentificationCode = identificationCode;
         Country = country;
         Phone = phone;
            UserId = userId;
     }

     public Company(CreateCompanyCommand command)
     {
        BrandName = command.BrandName;
        IdentificationCode = command.IdentificationCode;
        Country = command.Country;
        Phone = command.Phone;
        UserId = command.UserId;
    }
     
}