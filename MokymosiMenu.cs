using System;

namespace MokymosiMenu
{
    class MokymosiMenu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sveiki atvykę!");
            CallMenu();          
        }
        static void CallMenu()
        {
            
            while (true)
            {
                Console.WriteLine("\nPasirinkite temą, kurią norėtumėte mokytis:");
                Console.WriteLine("1) Matematika");
                Console.WriteLine("2) Geografija");
                Console.WriteLine("3) Datos");
                Console.WriteLine("Įrašykite norimos temos numerį: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    while (true)
                    {
                        Random rnd = new Random();

                        int num1 = rnd.Next(1, 11);
                        int num2 = rnd.Next(1, 11);

                        int multipl = num1 * num2;

                        int num3 = rnd.Next(1, 101);
                        int num4 = rnd.Next(1, 101);

                        int sum = num3 + num4;

                        int percent = rnd.Next(1, 11) * 10;
                        float percentage = Convert.ToSingle(num3) * percent / 100;

                        string[] allOper = { "/", "*", "+", "-", "%" };
                        var randOper = rnd.Next(allOper.Length);

                        if (allOper[randOper] == "/")
                        {
                            DivisionFunction(multipl, num1, num2);
                        }
                        else if (allOper[randOper] == "*")
                        {
                            MultiplicationFunction(multipl, num1, num2);
                        }
                        else if (allOper[randOper] == "+")
                        {
                            SumFunction(sum, num3, num4);
                        }
                        else if (allOper[randOper] == "-")
                        {
                            SubtractionFunction(sum, num3, num4);
                        }
                        else
                        {
                            PercentageFunction(percentage, num3, percent);
                        }
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Koks natūralus išteklis Afganistane yra gausus ir itin reikalingas baterijų technologijai?");
                    string answer = Console.ReadLine().ToLower();
                    GeoCheck(answer);
                }
                else if (input == "3")
                {
                    while (true)
                    {
                        Random rnd = new Random();
                        int yearFrom = rnd.Next(1900, 2021);
                        int monthFrom = rnd.Next(1, 13);
                        int dayFrom = rnd.Next(1, 29);
                        int yearTo = rnd.Next(1900, 2022);
                        while (yearTo <= yearFrom)
                        {
                            yearTo = rnd.Next(1900, 2021);
                        }
                        int monthTo = rnd.Next(1, 13);
                        int dayTo = rnd.Next(1, 29);
                        DateTime dateFrom = new DateTime(yearFrom, monthFrom, dayFrom);
                        DateTime dateTo = new DateTime(yearTo, monthTo, dayTo);
                        int age = (dateTo.Year - dateFrom.Year - 1)
                            + (((dateTo.Month > dateFrom.Month) || ((dateTo.Month == dateFrom.Month) && (dateTo.Day >= dateFrom.Day))) ? 1 : 0);
                        
                        Console.WriteLine($"Kiek metų žmogui, gimusiam {dateFrom.GetDateTimeFormats()[0]}, buvo {dateTo.GetDateTimeFormats()[0]}? Prašome įrašyti skaičių:");
                        string answer = Console.ReadLine();

                        AgeCount(answer, dateFrom, dateTo, age);
                    }
                }
                else if (input == "Q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    PrintWithColor("Įveskite tinkamą skaičių arba Q, jei norite išeiti iš programos!", ConsoleColor.Yellow);
                }
            }
        }

        static void GeoCheck(string answer)
                {
                    if (answer == "q")
                    {
                        return;
                    }
                    if (answer == "litis")
                    {
                        PrintWithColor("Teisingai!", ConsoleColor.Green);
                        Console.WriteLine("Norėdami tęsti spauskite <Enter>, norėdami grįžti į menu, spauskite <q>.");
                        var choice = Console.ReadKey();
                        while (choice.Key != ConsoleKey.Enter && choice.Key != ConsoleKey.Q)
                        {
                            Console.WriteLine("\nNorėdami tęsti spauskite <Enter>, norėdami grįžti į menu spauskite <q>.");
                            choice = Console.ReadKey();
                        }
                        if (choice.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine("\nNauji klausimai iš geografijos... TO BE CONTINUED..."); //Array, list iš klausimų ir atsakymų, kuriuos bus galima random iškviesti.
                            return; //Dabar back to menu.
                        }
                        else if (choice.Key == ConsoleKey.Q)
                        {
                            CallMenu();
                        }
                    }
                    if (answer != "litis" || answer != "q")
                    {
                        PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                        Console.WriteLine("Koks natūralus išteklis Afganistane yra gausus ir itin reikalingas baterijų technologijai?");
                        answer = Console.ReadLine().ToLower();
                        GeoCheck(answer);
                    }
                }
        static bool IsAnswerInt(string arg)
        {
            bool isAnswerInt = int.TryParse(arg, out int result);
            return isAnswerInt;
        }

        static void AgeCount(string answer, DateTime dateFrom, DateTime dateTo, int age)
        {
                if (IsAnswerInt(answer) == true)
                {
                    int answerInt = int.Parse(answer);
                    if (answerInt != age)
                    {
                        PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                        Console.WriteLine($"Kiek metų žmogui, gimusiam {dateFrom.GetDateTimeFormats()[0]}, buvo {dateTo.GetDateTimeFormats()[0]}? Prašome įrašyti skaičių:");
                        answer = Console.ReadLine();
                        AgeCount(answer, dateFrom, dateTo, age);
                    }
                    else
                    {
                        PrintWithColor("Teisingai!", ConsoleColor.Green);
                        return;
                    }
                    
                }

                if (IsAnswerInt(answer) != true && (answer == "q" || answer == "Q"))
                {
                CallMenu();
                }
                else if (IsAnswerInt(answer) != true && (answer != "q" || answer != "Q"))
                {
                    PrintWithColor("Prašome įrašyti skaičių arba spausti <q>, jei norite grįžti į menu.", ConsoleColor.Yellow);
                    answer = Console.ReadLine();
                    AgeCount(answer, dateFrom, dateTo, age);
                };
         
        }

        static void DivisionFunction(int multipl, int num1, int num2)
        {
            Console.Write(multipl + " / " + num1 + " = ");

            var input = Console.ReadLine();

            bool isAnswerInt = int.TryParse(input, out int result);

            if (isAnswerInt)
            {
                int answer = int.Parse(input);
                if (answer != num2)
                {
                    PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                    DivisionFunction(multipl, num1, num2);
                }
                else PrintWithColor("Teisingai!", ConsoleColor.Green);
            }
            else if (input == "q")
            {
                CallMenu();
            }
            else
            {
                PrintWithColor("Prašome įrašyti skaičių arba spausti <q>, jei norite grįžti į menu.", ConsoleColor.Yellow);
                DivisionFunction(multipl, num1, num2);
            };
        }
        static void MultiplicationFunction(int multipl, int num1, int num2)
        {
            Console.Write(num1 + " * " + num2 + " = ");

            var input = Console.ReadLine();

            bool isAnswerInt = int.TryParse(input, out int result);

            if (isAnswerInt)
            {
                int answer = int.Parse(input);
                if (answer != multipl)
                {
                    PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                    MultiplicationFunction(multipl, num1, num2);
                }
                else PrintWithColor("Teisingai!", ConsoleColor.Green);
            }
            else if (input == "q")
            {
                CallMenu();
            }
            else
            {
                PrintWithColor("Prašome įrašyti skaičių arba spausti <q>, jei norite grįžti į menu.", ConsoleColor.Yellow);
                MultiplicationFunction(multipl, num1, num2);
            };
        }
        static void SumFunction(int sum, int num3, int num4)
        {
            Console.Write(num3 + " + " + num4 + " = ");

            var input = Console.ReadLine();

            bool isAnswerInt = int.TryParse(input, out int result);

            if (isAnswerInt)
            {
                int answer = int.Parse(input);
                if (answer != sum)
                {
                    PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                    SumFunction(sum, num3, num4);
                }
                else PrintWithColor("Teisingai!", ConsoleColor.Green);
            }
            else if (input == "q")
            {
                CallMenu();
            }
            else
            {
                PrintWithColor("Prašome įrašyti skaičių arba spausti <q>, jei norite grįžti į menu.", ConsoleColor.Yellow);
                SumFunction(sum, num3, num4);
            };
        }
        static void SubtractionFunction(int sum, int num3, int num4)
        {
            Console.Write(sum + " - " + num3 + " = ");

            var input = Console.ReadLine();

            bool isAnswerInt = int.TryParse(input, out int result);

            if (isAnswerInt)
            {
                int answer = int.Parse(input);
                if (answer != num4)
                {
                    PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                    SubtractionFunction(sum, num3, num4);
                }
                else PrintWithColor("Teisingai!", ConsoleColor.Green);
            }
            else if (input == "q")
            {
                CallMenu();
            }
            else
            {
                PrintWithColor("Prašome įrašyti skaičių arba spausti <q>, jei norite grįžti į menu.", ConsoleColor.Yellow);
                SubtractionFunction(sum, num3, num4);
            };
        }
        static void PercentageFunction(float percentage, int num3, int percent)
        {
            Console.Write(percent + "% skaičiaus " + num3 + " yra ");

            var input = Console.ReadLine();

            bool isAnswerFloat = Single.TryParse(input, out float number);

            if (isAnswerFloat)
            {
                float answer = Single.Parse(input);
                if (answer != percentage)
                {
                    PrintWithColor("Neteisingai. Mėginkite dar kartą arba spauskite <q>, jei norite grįžti į menu.", ConsoleColor.Red);
                    PercentageFunction(percentage, num3, percent);
                }
                else PrintWithColor("Teisingai!", ConsoleColor.Green);
            }
            else if (input == "q")
            {
                CallMenu();
            }
            else
            {
                PrintWithColor("Prašome įrašyti skaičių arba spausti <q>, jei norite grįžti į menu.", ConsoleColor.Yellow);
                PercentageFunction(percentage, num3, percent);
            };
        }

        static void PrintWithColor(string text, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(text);
            Console.ResetColor();
        }


    }
}
