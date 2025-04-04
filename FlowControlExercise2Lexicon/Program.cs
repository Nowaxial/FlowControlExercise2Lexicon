namespace FlowControlExercise2Lexicon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO: 1. Lägga till en switch-sats som körs beroende på vad användaren väljer.
            //TODO: 2. Lägga till en metod för varje alternativ i menyn.
            //TODO: 3. Lägga till en metod för att avsluta programmet.
            //TODO: 4. Lägga till en metod för att skriva ut en text 10 gånger.
            //TODO: 5. Lägga till en metod för att hämta det tredje ordet i en mening.
            //DONE: 6. Lägga till en metod för att beräkna biljettpriser beroende på ålder.
            //TODO: 7. Lägga till en metod för att beräkna biljettpriser beroende på sällskapets storlek och ålder
            //TODO: 8. Extra: Lägga till validering av input i metoderna för att säkerställa att användaren anger giltiga värden.

            bool isRunning = true;

            do
            {
                //Här är huvudmenyn med de alternativ som ska kunna väljas senare
                //Den körs i en oändlig loop tills användaren stänger ner programmet, loopen avslutas genom att sätta isRunning till false.
                //Avslutar med en Console.ReadLine() för att vänta på användarens input och då det är en oändlig loop så kommer den att köra om menyn igen.

                Console.WriteLine("============================================================");
                Console.WriteLine("|                VÄLKOMMEN TILL HUVUDMENYN!                |");
                Console.WriteLine("============================================================");
                Console.WriteLine("Välj ett alternativ genom att skriva en siffa och tryck ");
                Console.WriteLine("sedan på Enter:\n");

                Console.WriteLine("1. Ålderspriser – Kontrollera biljettpris för en person");
                Console.WriteLine("2. Sällskapspris – Beräkna pris för en hel grupp");
                Console.WriteLine("3. Upprepa text – Skriv ut en text 10 gånger");
                Console.WriteLine("4. Tredje ordet – Hämta det tredje ordet i en mening");
                Console.WriteLine("0. Avsluta programmet\n");

                Console.Write("Ditt val: ");

                // Kommenterar ut Console.ReadLine(); då den bara var för att testa och se huvudmenyn hur den blev

                string inputChoice = Console.ReadLine()!.ToUpper();

                switch (inputChoice)
                {
                    case "0":
                        //Avslutar programmet genom att ändra isRunning till false
                        Console.WriteLine("Avslutar programmet...");
                        isRunning = false;

                        break;

                    case "1":

                        UserAgePrice();  //Anropar metoden UserAgePrice()
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();
                        break;

                    case "2":
                        GroupSize(); //Anropar metoden GroupSize()
                        break;

                    case "3":

                        break;

                    case "4":
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

            //Metoden UserAgePrice() som räknar ut biljettpriser beroende på ålder
            static void UserAgePrice()
            {
                Console.Write("Ange din ålder: ");
                int userAge = int.Parse(Console.ReadLine()!);
                if (userAge <= 19)
                {
                    Console.WriteLine("Ungdomspris: 80kr");
                }
                else if (userAge >= 65)
                {
                    Console.WriteLine("Pensionärspris: 90kr");
                }
                else
                {
                    Console.WriteLine("Standardpris: 120kr");
                }
            }
            //Metoden GroupSize() som räknar ut biljettpriser beroende på sällskapets storlek och ålder, lagt till validering av input
            static void GroupSize()
            {
                Console.Write("Antal personer i sällskapet: ");
                string inputGroupSize = Console.ReadLine()!;
                int groupSize;
                int totalPriceGroup = 0;

                //Kontrollerar om input är ett heltal
                if (!int.TryParse(inputGroupSize, out groupSize))
                {
                    Console.WriteLine("Ogiltigt format. Ange endast siffror");
                    GroupSize();//Anropar metoden igen för att låta användaren ange ett nytt värde
                    return;
                }

                if (groupSize < 1)
                {
                    Console.WriteLine("Antalet personer måste vara minst 1.");
                    return;
                }

                for (int i = 0; i < groupSize; i++)
                {
                    int userAge;
                    Console.Write("Ange ålder för person " + (i + 1) + ": ");//L
                    string inputUserAge = Console.ReadLine()!;
                    //Kontrollerar om input är ett heltal
                    if (!int.TryParse(inputUserAge, out userAge))
                    {
                        Console.WriteLine("Ogiltigt format. Ange endast siffror");
                        i--;//Minskar i med 1 för att låta användaren ange åldern igen
                        continue;
                    }
                    if (userAge <= 19)
                    {
                        totalPriceGroup += 80;
                    }
                    else if (userAge >= 65)
                    {
                        totalPriceGroup += 90;
                    }
                    else
                    {
                        totalPriceGroup += 120;
                    }
                }
                Console.WriteLine($"Antal personer : {groupSize}st. | Totalt pris för sällskapet: {totalPriceGroup}kr. \n");
            }
        }
    }
}