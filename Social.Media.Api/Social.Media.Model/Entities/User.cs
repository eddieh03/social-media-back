using Social.Media.Model.Entities.Base;

namespace Social.Media.Model.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public string ProfileImageUrl { get; set; }
    public int Role { get; set; }
}
