namespace FlowControlExercise2Lexicon
{
    internal class Program
    {
        private static void Main(string[] args)
        {
                    //DONE: 0. Skriva en loop som gör att programmet körs tills användaren väljer att avsluta det genom att trycka på 0 i menyn.
                    //DONE: 1. Skriva ut en huvudmeny med olika alternativ för användaren att välja mellan med Console.WriteLine();
                    //DONE: 2. Låta användaren välja ett alternativ genom att skriva en siffra och trycka på Enter med det val dom väljer som skrivs in med Console.Write();
                    //DONE: 3. Läsa in användarens val med Console.ReadLine().ToUpper() och spara det i en variabel.
                    //DONE: 4. Skriva en switch-sats som kollar vilket alternativ användaren har valt med baserat på den sparade variabeln.
                    //DONE: 5. Skriva metoder för varje alternativ i menyn och anropa dem i switch-satsen.

                    //TODO: Extra: Lägga till validering för FindTheThirdWord() så att den bara hanterar 1 mellanslag mellan varje ord.
                    //TODO: Extra: Köra en Refactoring av hela koden så att den är mer lättläst.

            bool isRunning = true; //Loopvariabel som används för att köra programmet i en oändlig loop tills användaren väljer att avsluta det.Loopen avslutas genom att sätta isRunning till false som finns i metoden ExitProgram().

            do
            {
                //Här är huvudmenyn med de alternativ som ska kunna väljas.
                Console.WriteLine("============================================================");
                Console.WriteLine("|                VÄLKOMMEN TILL HUVUDMENYN!                |");
                Console.WriteLine("============================================================");
                Console.WriteLine("Välj ett alternativ genom att skriva en siffa och tryck ");
                Console.WriteLine("sedan på Enter:\n");

                Console.WriteLine("1. Ålderspriser – Kontrollera biljettpris på bio för en person");
                Console.WriteLine("2. Sällskapspris – Beräkna pris för en hel grupp som går på bio");
                Console.WriteLine("3. Upprepa text – Skriv ut en text 10 gånger");
                Console.WriteLine("4. Tredje ordet – Hämta det tredje ordet i en mening");
                Console.WriteLine("0. Avsluta programmet\n");

                Console.Write("Ditt val: ");

                string inputChoice = Console.ReadLine()!.ToUpper();

                //switch-sats som kollar vilket alternativ användaren har valt
                switch (inputChoice)
                {
                    case "0":
                        ExitProgram(); //Anropar metoden ExitProgram() som avslutar programmet
                        break;

                    case "1":
                        UserAgePrice(); //Anropar metoden UserAgePrice()
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;

                    case "2":
                        GroupSize(); //Anropar metoden GroupSize()
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;

                    case "3":
                        RepeatText(); //Anropar metoden RepeatText()
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;

                    case "4":
                        FindTheThirdWord(); //Anropar metoden ThirdWord()
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;

                    default:
                        //Om användaren skriver något annat än 1-4 eller 0 så skrivs ett felmeddelande ut
                        Console.WriteLine("Felaktigt val, försök igen.");
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;
                }
            }
            while (isRunning);

            static void UserAgePrice() //Metod som räknar ut biljettpriser beroende på ålder
            {
                Console.Write("Ange din ålder: ");
                string inputUserAge = Console.ReadLine()!;

                // Kollar så det är ett giltigt heltal
                if (!int.TryParse(inputUserAge, out int userAge) || userAge < 0)
                {
                    Console.WriteLine("Ogiltig ålder. Ange ett positivt heltal.");
                    UserAgePrice();
                    return;
                }

                if (userAge < 5 || userAge > 100) //Kollar om ålder är mellan 5 år och 100 år då de får gratis entré
                {
                    Console.WriteLine("Gratis entré!");
                }
                else if (userAge <= 19) //Kollar om det är en ungdom som är mellan 5 och 19 år (ungdom under 20 år)
                {
                    Console.WriteLine("Ungdomspris: 80kr");
                }
                else if (userAge >= 65) //Kollar om det är en pensionär som är 65 år eller äldre (pensionär över 64)
                {
                    Console.WriteLine("Pensionärspris: 90kr");
                }
                else //Annars är det en vuxen som är mellan 20 och 64 år som betalar standardpris
                {
                    Console.WriteLine("Standardpris: 120kr");
                }
            }

            static void GroupSize() //Metoden som räknar ut biljettpriser beroende på sällskapets storlek och ålder.

            {
                Console.Write("Antal personer i sällskapet: ");
                string inputGroupSize = Console.ReadLine()!;
                int totalPriceGroup = 0;

                //Kontrollerar om inputGroupSize är ett tal, allt annat än siffror är ogiltigt
                if (!int.TryParse(inputGroupSize, out int groupSize))
                {
                    Console.WriteLine("Ogiltigt format. Ange endast siffror");
                    GroupSize();//Anropar metoden igen för att låta användaren ange ett nytt värde
                    return;
                }

                if (groupSize <= 0)
                {
                    Console.WriteLine("Antalet personer måste vara minst 1.");
                    GroupSize(); //Anropar metoden igen för att låta användaren ange ett nytt värde
                    return;
                }

                for (int i = 0; i < groupSize; i++)
                {
                    Console.Write("Ange ålder för person " + (i + 1) + ": ");
                    string inputUserAge = Console.ReadLine()!;

                    // Validering av ålder
                    if (!int.TryParse(inputUserAge, out int userAge) || userAge < 0)
                    {
                        Console.WriteLine("Ogiltigt. Får endast vara ett positivt tal");
                        i--;
                        continue;
                    }

                    // Prisberäkning med specialregler
                    if (userAge <= 4 || userAge >= 101)  // Gratis för de som är 5 år eller yngre eller 100 år eller äldre
                    {
                        Console.WriteLine($"Person {i + 1}: Gratis entré!");
                        continue;  // Lägger inte till något till totalpriset
                    }
                    else if (userAge <= 19) // Under 20 år
                    {
                        totalPriceGroup += 80;
                    }
                    else if (userAge >= 65) // ÖVer 64 år
                    {
                        totalPriceGroup += 90;
                    }
                    else // Standardpris för vuxna mellan 20 och 64 år
                    {
                        totalPriceGroup += 120;
                    }
                }
                Console.WriteLine($"Antal personer : {groupSize}. | Totalt pris för sällskapet: {totalPriceGroup}kr. \n");
            }

            static void RepeatText() //Metodensom skriver ut en text 10 gånger
            {
                Console.Write("Skriv en text: ");
                string textInput = Console.ReadLine()!;

                //Kontrollerar om texten är tom annars så anropas metoden igen för att låta användaren ange en ny text
                if (string.IsNullOrEmpty(textInput))
                {
                    Console.WriteLine("Ingen text angiven. Försök igen.");
                    RepeatText(); 
                    return;
                }

                //Skriver ut rubrik för utskriften
                Console.WriteLine("Utskrift av texten 10 gånger:");
                Console.WriteLine("=============================");

                //Skriver ut texten 10 gånger
                for (int i = 1; i < 11; i++)
                {
                    //Skriver ut texten med numret framför (i)
                    Console.Write($"{i}.{textInput}");

                    //loopar igenom 10 gånger och lägger till ett mellanslag efter varje utskrift och skriver ut en ny rad efter 10 utskrifter
                    if (i < 11)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

            static void FindTheThirdWord()
            {
                Console.Write("Skriv en mening: ");
                string inputSentence = Console.ReadLine()!;

                //Kontrollerar om texten är tom annars så anropas metoden igen för att låta användaren ange en ny text
                if (string.IsNullOrEmpty(inputSentence))
                {
                    Console.WriteLine("Ingen mening angiven. Försök igen.");
                    FindTheThirdWord(); //Anropar metoden igen för att låta användaren ange en ny mening
                    return;
                }
                
                string[] words = inputSentence.Split(' '); //Delar upp meningen i ord med hjälp av mellanslag

                //Kontrollerar om det finns minst tre ord i meningen
                if (words.Length >= 3)
                {
                    Console.WriteLine($"Det tredje ordet är: {words[2]}");
                }
                else
                {
                    Console.WriteLine("Meningen innehåller mindre än tre ord.");
                    Console.WriteLine("Försök igen.");
                    FindTheThirdWord(); //Anropar metoden igen för att låta användaren ange en ny mening
                    return;
                }
            }

            static void ExitProgram()
            {
                Console.WriteLine("Avslutar programmet...");
                Environment.Exit(0); //Avslutar programmet
            }
        }
    }
}