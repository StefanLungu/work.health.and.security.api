using System.Text.Json.Serialization;
using whs.api.entities.enums;

namespace whs.api.entities.management;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Description { get; set; }
    public string EmailAddress { get; set; }
	public UserRole Role { get; set; }
	public Department Department { get; set; }

	[JsonIgnore]
	public string Password { get; set; }

}
