var _context = new AppDbContext();

var userContact = _context.UsersContacts?.ToList();

Console.WriteLine($"\tid, \tname, \tcontact");

foreach(var uc in userContact)
{
    Console.WriteLine($"\t{uc.Id}, \t{uc.Name} \t{uc.Contact}");
}
