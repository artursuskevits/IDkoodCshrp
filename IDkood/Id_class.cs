using System;
using System.Reflection.Emit;

public class IdCode
{
    private string _idCode;

    public IdCode(string idCode)
    {
        _idCode = idCode;
    }

    public IdCode()
    {
        _idCode = ""; // Provide a default value if needed
    }

    public string IDCODE
    {
        get => _idCode;
        set => _idCode = value;
    }
    private bool IsValidLength()
    {
        return _idCode.Length == 11;
    }


    private bool ContainsOnlyNumbers()
    {
        // return _idCode.All(Char.IsDigit);

        for (int i = 0; i < _idCode.Length; i++)
        {
            if (!Char.IsDigit(_idCode[i]))
            {
                return false;
            }
        }
        return true;
    }

    private int GetGenderNumber()
    {
        return Convert.ToInt32(_idCode.Substring(0, 1));
    }

    private bool IsValidGenderNumber()
    {
        int genderNumber = GetGenderNumber();
        return genderNumber > 0 && genderNumber < 7;
    }

    private int Get2DigitYear()
    {
        return Convert.ToInt32(_idCode.Substring(1, 2));
    }

    public int GetFullYear()
    {
        int genderNumber = GetGenderNumber();
        // 1, 2 => 18xx
        // 3, 4 => 19xx
        // 5, 6 => 20xx
        return 1800 + (genderNumber - 1) / 2 * 100 + Get2DigitYear();
    }

    private int GetMonth()
    {
        return Convert.ToInt32(_idCode.Substring(3, 2));
    }

    private bool IsValidMonth()
    {
        int month = GetMonth();
        return month > 0 && month < 13;
    }

    private static bool IsLeapYear(int year)
    {
        return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
    }
    private int GetDay()
    {
        return Convert.ToInt32(_idCode.Substring(5, 2));
    }

    private bool IsValidDay()
    {
        int day = GetDay();
        int month = GetMonth();
        int maxDays = 31;
        if (new List<int> { 4, 6, 9, 11 }.Contains(month))
        {
            maxDays = 30;
        }
        if (month == 2)
        {
            if (IsLeapYear(GetFullYear()))
            {
                maxDays = 29;
            }
            else
            {
                maxDays = 28;
            }
        }
        return 0 < day && day <= maxDays;
    }

    private int CalculateControlNumberWithWeights(int[] weights)
    {
        int total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            total += Convert.ToInt32(_idCode.Substring(i, 1)) * weights[i];
        }
        return total;
    }

    private bool IsValidControlNumber()
    {
        int controlNumber = Convert.ToInt32(_idCode[^1..]);
        int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
        int total = CalculateControlNumberWithWeights(weights);
        if (total % 11 < 10)
        {
            return total % 11 == controlNumber;
        }
        // second round
        int[] weights2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
        total = CalculateControlNumberWithWeights(weights2);
        if (total % 11 < 10)
        {
            return total % 11 == controlNumber;
        }
        // third round, control number has to be 0
        return controlNumber == 0;
    }

    public bool IsValid()
    {
        return IsValidLength() && ContainsOnlyNumbers()
            && IsValidGenderNumber() && IsValidMonth()
            && IsValidDay()
            && IsValidControlNumber();
    }

    public DateOnly GetBirthDate()
    {
        int day = GetDay();
        int month = GetMonth();
        int year = GetFullYear();
        return new DateOnly(year, month, day);
    }

    public static void HOwOLdAreYou(IdCode id)
    {
        DateOnly birthdate = id.GetBirthDate();
        DateTime today = DateTime.Today;
        int age = today.Year - birthdate.Year;
        if (birthdate.Month > today.Month || (birthdate.Month == today.Month && birthdate.Day > today.Day))
        {
            age--;
        }

        Console.WriteLine(age);
    }

    public static string Sunnikoht(string ikood)
    {
        char[] ikoodArray = ikood.ToCharArray();
        string tahed_8910 = new string(new char[] { ikoodArray[7], ikoodArray[8], ikoodArray[9] });
        int t = int.Parse(tahed_8910);
        string haigla = "";

        if (1 < t && t < 10)
        {
            haigla = "Kuresaare Haigla";
        }
        else if (11 < t && t < 19)
        {
            haigla = "Tartu Ülikooli Naistekliinik, Tartumaa, Tartu";
        }
        else if (21 < t && t < 220)
        {
            haigla = "Ida-Tallinna Keskhaigla, Pelgulinna sünnitusmaja, Hiiumaa, Keila, Rapla haigla, Loksa haigla";
        }
        else if (221 < t && t < 270)
        {
            haigla = "Ida-Viru Keskhaigla (Kohtla-Järve, endine Jõhvi)";
        }
        else if (271 < t && t < 370)
        {
            haigla = "Maarjamõisa Kliinikum (Tartu), Jõgeva Haigla";
        }
        else if (371 < t && t < 420)
        {
            haigla = "Narva Haigla";
        }
        else if (421 < t && t < 470)
        {
            haigla = "Pärnu Haigla";
        }
        else if (471 < t && t < 490)
        {
            haigla = "Pelgulinna Sünnitusmaja (Tallinn), Haapsalu haigla";
        }
        else if (491 < t && t < 520)
        {
            haigla = "Järvamaa Haigla (Paide)";
        }
        else if (521 < t && t < 570)
        {
            haigla = "Rakvere, Tapa haigla";
        }
        else if (571 < t && t < 600)
        {
            haigla = "Valga Haigla";
        }
        else if (601 < t && t < 650)
        {
            haigla = "Viljandi Haigla";
        }
        else if (651 < t && t < 700)
        {
            haigla = "Lõuna-Eesti Haigla (Võru), Põlva Haigla";
        }
        else
        {
            haigla = "Ei ole sündinud Eestis";
        }
        return haigla;
    }
    public static string CodeCreation()
    {
        while (true) {
            string idik = "p";
            Console.WriteLine("if you are women press - 1\nif you are arem men press 2");
            string answer = Console.ReadLine();
            if (answer=="1")
            {
                Console.WriteLine("write you bithday year");
                string year = Console.ReadLine();
                Console.WriteLine("write you bithday month");
                string month = Console.ReadLine();
                Console.WriteLine("write you bithday day");
                string day = Console.ReadLine();
            }
            else if (answer == "2")
            {
                Console.WriteLine("write you bithday year");
                string year = Console.ReadLine();
                Console.WriteLine("write you bithday month");
                string month = Console.ReadLine();
                Console.WriteLine("write you bithday day");
                string day = Console.ReadLine();

            }
            else
            {
                    
            }
            return idik;
        }
        
    }
}
