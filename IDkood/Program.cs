﻿using IDkood;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        List<IdCode> rightcodes = new List<IdCode>();
        List<IdCode> wrongcodes = new List<IdCode>();
        while (true)
        {
            Filetoo.clear_2_dictionary(rightcodes, wrongcodes);
            Filetoo.create_2_dictionary(rightcodes,wrongcodes);
            Console.WriteLine("Write your IDkood");
            string numbersforid= Console.ReadLine();
            IdCode yourid = new IdCode(numbersforid);
            string user_choice = "2";
            if (yourid.IsValid())
            {
                
                while (user_choice=="1"|| user_choice == "2"||user_choice == "3"|| user_choice == "4")
                {
                    rightcodes.Add(yourid);
                    Filetoo.Saveheaisikukood(rightcodes, wrongcodes);
                    Console.WriteLine("Press 1 - to show your age\nPress 2 - to show birthday date\nPress 3 to chek your sunnikoht \nelse - break programm");
                    user_choice = Console.ReadLine();
                    if (user_choice=="1")
                    {
                        IdCode.HOwOLdAreYou(yourid);
                    }
                    if (user_choice == "2")
                    {
                        Console.WriteLine(yourid.GetBirthDate());
                    }
                    if (user_choice == "3")
                    {
                        Console.WriteLine(IdCode.Sunnikoht(yourid.IDCODE));
                    }
                    if (user_choice == "4")
                    {
                        IdCode.FoundSex(yourid.IDCODE);
                    }
                }  
            }
            else
            {
                wrongcodes.Add(yourid);
                Filetoo.Saveheaisikukood(rightcodes, wrongcodes);
                Console.WriteLine("you id wrong"); }
            }
        //Console.WriteLine(new IdCode("27605030298").GetFullYear());  // 1876
        //Console.WriteLine(new IdCode("37605030299").GetFullYear());  // 1976
        //Console.WriteLine(new IdCode("50005200009").GetFullYear());  // 2000
        //Console.WriteLine(new IdCode("27605030298").GetBirthDate());  // 03.05.1876
        //Console.WriteLine(new IdCode("37605030299").GetBirthDate());  // 03.05.1976
        //Console.WriteLine(new IdCode("50005200009").GetBirthDate());  // 20.05.2000

        //Console.WriteLine(new IdCode("a").IsValid());  // False
        //Console.WriteLine(new IdCode("123").IsValid());  // False
        //Console.WriteLine(new IdCode("37605030299").IsValid());  // True
        //// 30th February
        //Console.WriteLine(new IdCode("37602300299").IsValid());  // False
        //Console.WriteLine(new IdCode("52002290299").IsValid());  // False
        //Console.WriteLine(new IdCode("50002290231").IsValid());  // True
        //Console.WriteLine(new IdCode("30002290231").IsValid());  // False

        //// control number 2nd round
        //Console.WriteLine(new IdCode("51809170123").IsValid());  // True
        //Console.WriteLine(new IdCode("39806302730").IsValid());  // True

        //// control number 3rd round
        //Console.WriteLine(new IdCode("60102031670").IsValid());  // True
        //Console.WriteLine(new IdCode("50512120849").IsValid());  // True
        Console.ReadLine();
    }
}