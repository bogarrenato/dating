namespace API.Entities;



// Table
public class AppUser
{
    // Columns
    public int Id { get; set; }
    // Cannot create appuser without username
    public required string UserName { get; set; }
}
