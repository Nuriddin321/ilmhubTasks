using mvc.Data;

namespace mvc.Servives;

public class NumberService
{
    private readonly AppDbContext _context;

    public NumberService(AppDbContext context)
    {
        _context = context;
    }

    public string GetNum2(int number)
    {
        string numWord = "";
        var num1 = _context.Numbers.FirstOrDefault(r => r.Raqam == ((number / 10) * 10));
        var num2 = number % 10;
        if (num2 == 0)
        {
            numWord = $"{num1.Name} ";
            return numWord;
        }
        else
        {
            var num3 = _context.Numbers.FirstOrDefault(n => n.Raqam == num2);
            numWord = $"{num1.Name} {num3.Name}";
            return numWord;
        }
    }
    public string GetNum3(int number)
    {
        string numWord = "";

        var num1 = _context.Numbers.FirstOrDefault(n => n.Raqam == (number / 100));
        var num2 = _context.Numbers.FirstOrDefault(n => n.Raqam == (100));
        var num3 = number % 100;
        if (num3 == 0)
        {
            numWord = $"{num1.Name} {num2.Name}";
            return numWord;
        }
        else if (num3 <= 10)
        {
            var num4 = _context.Numbers.FirstOrDefault(n => n.Raqam == num3);
            numWord = $"{num1.Name} {num2.Name} {num4.Name}";
            return numWord;
        }
        else
        {
            var num5 = GetNum2(num3);

            numWord = $"{num1.Name} {num2.Name} {num5}";

            return numWord;
        }
    }

    public string GetNum4(int number)
    {
        string numWord = "";

        var num1 = _context.Numbers.FirstOrDefault(n => n.Raqam == (number / 1000));
        var num2 = _context.Numbers.FirstOrDefault(n => n.Raqam == (1000));
        var num3 = number % 1000;
        if (num3 == 0)
        {
            numWord = $"{num1.Name} {num2.Name}";
            return numWord;
        }
        else if (num3 <= 10)
        {
            var num4 = _context.Numbers.FirstOrDefault(n => n.Raqam == num3);
            numWord = $"{num1.Name} {num2.Name} {num4.Name}";
            return numWord;
        }
        else if (num3 < 100)
        {
            var num4 = GetNum2(num3);
            numWord = $"{num1.Name} {num2.Name} {num4}";
            return numWord;
        }
        else
        {
            var num4 = GetNum3(num3);

            numWord = $"{num1.Name} {num2.Name} {num4}";

            return numWord;
        }
    }

    public string GetNum5(int number)
    {
        string numWord = "";

        var num1 = GetNum2(number / 1000);
        var num2 = _context.Numbers.FirstOrDefault(n => n.Raqam == (1000));
        var num3 = number % 1000;
        if (num3 == 0)
        {
            numWord = $"{num1} {num2.Name}";
            return numWord;
        }
        else if (num3 <= 10)
        {
            var num4 = _context.Numbers.FirstOrDefault(n => n.Raqam == num3);
            numWord = $"{num1} {num2.Name} {num4.Name}";
            return numWord;
        }
        else if (num3 < 100)
        {
            var num4 = GetNum2(num3);
            numWord = $"{num1} {num2.Name} {num4}";
            return numWord;
        }
        else if (num3 < 1000)
        {
            var num4 = GetNum3(num3);
            numWord = $"{num1} {num2.Name} {num4}";
            return numWord;
        }
        else
        {
            var num4 = GetNum4(num3);

            numWord = $"{num1} {num2.Name} {num4}";

            return numWord;
        }
    }

    //=============================

    public string GetNum6(int number)
    {
        string numWord = "";

        var num1 = GetNum3(number / 1000);
        var num2 = _context.Numbers.FirstOrDefault(n => n.Raqam == (1000));
        var num3 = number % 1000;
        if (num3 == 0)
        {
            numWord = $"{num1} {num2.Name}";
            return numWord;
        }
        else if (num3 <= 10)
        {
            var num4 = _context.Numbers.FirstOrDefault(n => n.Raqam == num3);
            numWord = $"{num1} {num2.Name} {num4.Name}";
            return numWord;
        }
        else if (num3 < 100)
        {
            var num4 = GetNum2(num3);
            numWord = $"{num1} {num2.Name} {num4}";
            return numWord;
        }
        else if (num3 < 1000)
        {
            var num4 = GetNum3(num3);
            numWord = $"{num1} {num2.Name} {num4}";
            return numWord;
        }
        else
        {
            var num4 = GetNum4(num3);

            numWord = $"{num1} {num2.Name} {num4}";

            return numWord;
        }
    }
    //=============================


    public string GetNum7(int number)
    {
        string numWord = "";

        var num1 = _context.Numbers.FirstOrDefault(n => n.Raqam == (number / 1000000));
        var num2 = _context.Numbers.FirstOrDefault(n => n.Raqam == (1000000));

        var num3 = (number % 1000000);
        if (num3 == 0)
        {
            numWord = $"{num1.Name} {num2.Name}";
            return numWord;
        }
        else if (num3 <= 10)
        {
            var num4 = _context.Numbers.FirstOrDefault(n => n.Raqam == num3);
            numWord = $"{num1.Name} {num2.Name} {num4.Name}";
            return numWord;
        }
        else if (num3 < 100)
        {
            var num4 = GetNum2(num3);
            numWord = $"{num1.Name} {num2.Name} {num4}";
            return numWord;
        }
        else if (num3 < 1000)
        {
            var num4 = GetNum3(num3);
            numWord = $"{num1.Name} {num2.Name} {num4}";
            return numWord;
        }
        else if (num3 < 10000)
        {
            var num4 = GetNum4(num3);
            numWord = $"{num1.Name} {num2.Name} {num4}";
            return numWord;
        }
        else if (num3 < 100000)
        {
            var num4 = GetNum5(num3);
            numWord = $"{num1.Name} {num2.Name} {num4}";
            return numWord;
        }
        else
        {
            var num4 = GetNum6(num3);

            numWord = $"{num1.Name} {num2.Name} {num4}";

            return numWord;
        }

    }

}