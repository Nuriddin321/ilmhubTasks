

Console.WriteLine($"Raqam kiriting");
key:
var input = Console.ReadLine();
int.TryParse(input, out var number);

if(number == 0)
{ 
    Console.WriteLine($"qayta kiriting");
    goto key;
}
else
{
    var context = new AppDbContext();

    var raqam = context.Jadvals.FirstOrDefault(raqam => raqam.Input == number);

    if(raqam is null)
    {
        string table = "";

        for(int i = 1; i < 11; i++)
        {
           table += $"{number} * {i} = {number*i} \n";
        }

        var jadval = new Jadval();

        jadval.Input = number;
        jadval.Output = table;
        context.Jadvals.Add(jadval);
        context.SaveChanges();

        Console.WriteLine(table);
    }
    else
    {
        var table = context.Jadvals.FirstOrDefault(j=> j.Input == number);
        Console.WriteLine(table.Output);
    }
}