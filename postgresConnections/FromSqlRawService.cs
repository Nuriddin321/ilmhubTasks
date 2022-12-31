using Microsoft.EntityFrameworkCore;

public class FromSqlRawService
{
    public void Start()
    {
        var _context = new AppDbContext();

        var query = "Select users.id, users.name, contact.\"Name\" as userContact from users join contact on users.id = contact.id";

        var usercontact = _context.UsersContacts?.FromSqlRaw(query).ToList();

        Console.WriteLine($"\tId\tName\tContact");
        foreach (var i in usercontact)
        {
            Console.WriteLine($"\t{i.Id}\t{i.Name}\t{i.Contact}");
        }
    }
}
