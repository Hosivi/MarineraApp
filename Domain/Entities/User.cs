
using Ardalis.GuardClauses;
using FluentValidation;
using FluentValidation.Results;
using SharedKernel;

namespace Domain.Entities;

public class 
    User : EntityBase
{
    public string FirstName => FirstName1 + " " + FirstName2;

    public string? FirstName1 { get; set; }
    public string? FirstName2 { get; set; }

    public string LastName => LastName1 + " " + LastName2;

    public string? LastName1 { get; set; }
    public string? LastName2 { get; set; }
    public string IdentityDoc { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            return age;
        }
    }
    public int? Test { get; set; }
    public string Email { get; set; } = "";
    public string AdressLine1 { get; set; }
    public string AdressLine2 { get; set; }
    public string District { get; set; }
    public string Country { get; set; }
    public string Nacionality { get; set; }

    public bool IsOfLegalAge => Age >= 18 ? true : false;

    public Role? Role { get; set; }
    public Guid? RoleId { get; set; }
    public List<Parent?> Parents { get; set; } = new List<Parent?>();

    public int ParentsCount
    {
        get
        {
            var count = Parents.Count();
            return count;
        }
    }

    public bool AreParentsComplete => Parents.Count() == 2 ? true : false;
    public bool IsValidUser => Validate().IsValid;
    public void ValidateUserWithGuardClausses()
    {
        ///TODO: implementar la validación de usuario con GuardClauses
        // FirstName1=Guard.Against.NullOrWhiteSpace(FirstName1,nameof(FirstName1));
        // FirstName2=Guard.Against.NullOrWhiteSpace(FirstName2,nameof(FirstName2));
        // LastName1=Guard.Against.NullOrWhiteSpace(LastName1,nameof(LastName1));
        IdentityDoc = Guard.Against.Null(IdentityDoc, nameof(IdentityDoc));
        DateOfBirth = Guard.Against.AgainstExpression<DateTime>(x => DateOfBirth.Year >= 4, DateOfBirth, "La edad del usuario debe ser mayor o igual a 4 años");
    }
    public void AddParent(User user, Action? action = null)
    {
        if (Parents.Count() < 2)
        {
            Parents.Add(user as Parent);
        }
    }

    public ValidationResult Validate()
    {
        var validation = new UserValidator();
        return validation.Validate(this);
    }
}

public class Parent : User
{
    public List<User> Children { get; set; }
}

public class UserValidator : AbstractValidator<User>
{
    Func<string, string> notNullOrEmpty = (string PropertyName) => $"El campo {PropertyName} no puede ser nulo o vacío";

    public UserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(notNullOrEmpty(nameof(User.FirstName)));
        RuleFor(x => x.LastName).NotEmpty().WithMessage(notNullOrEmpty(nameof(User.LastName)));
        RuleFor(x => x.IdentityDoc).NotEmpty().WithMessage(notNullOrEmpty(nameof(User.IdentityDoc)));
        // RuleFor(x => x.DateOfBirth).GreaterThan(DateTime.Now.AddYears(-4)).WithMessage("La edad del usuario debe ser mayor o igual a 4 años");
        RuleFor(x => x.Age).GreaterThanOrEqualTo(3).WithMessage("La edad del usuario debe ser mayor o igual a 18 años");
    }

    public ValidationResult GetValidationResult(User user)
    {
        return Validate(user);
    }

}
