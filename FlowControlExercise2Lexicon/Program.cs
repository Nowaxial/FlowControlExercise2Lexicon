namespace FlowControlExercise2Lexicon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DONE: 0. Skriva en loop som gör att programmet körs tills användaren väljer att avsluta det genom att trycka på 0 i menyn.
            //DONE: 1. Skriva ut en huvudmeny med olika alternativ för användaren att välja mellan med Console.WriteLine();
            //DONE: 2. Låta användaren välja ett alternativ genom att skriva en siffra och trycka på Enter med det val dom väljer som skrivs in med Console.Write();
            //DONE: 3. Läsa in användarens val med Console.ReadLine().ToUpper() och spara det i en variabel.
            //DONE: 2. Skriva en switch-sats som kollar vilket alternativ användaren har valt med baserat på den sparade variabeln.
            //TODO: 3. Skriva metoder för varje alternativ i menyn och anropa dem i switch-satsen.



            //TODO: Extra: Lägga till validering av input i metoderna för att säkerställa att användaren anger giltiga värden


            bool isRunning = true;

            do
            {
                //Här är huvudmenyn med de alternativ som ska kunna väljas senare
                //Den körs i en oändlig loop tills användaren stänger ner programmet eller avslutas., Loopen avslutas genom att sätta isRunning till false.
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


                //switch-sats som kollar vilket alternativ användaren har valt
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
                        Console.ReadLine();//Väntar på användarens input
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;

                    case "2":
                        GroupSize(); //Anropar metoden GroupSize()
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();//Väntar på användarens input
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen
                        break;

                    case "3":
                        RepeatText(); //Anropar metoden RepeatText()
                       
                        Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn.");
                        Console.ReadLine();//Väntar på användarens input
                        Console.Clear(); //Rensar konsolen så att huvudmenyn kommer upp igen


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

            /*Här är metoderna som anropas i switch-satsen
             *                   |
             *                   V                  
             */
      

            //Metoden UserAgePrice() som räknar ut biljettpriser beroende på ålder
            static void UserAgePrice()
            {
                Console.Write("Ange din ålder: ");

                //Kontrollerar om input är ett tal
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

            //Metoden GroupSize() som räknar ut biljettpriser beroende på sällskapets storlek och ålder.
            static void GroupSize()
            {
                Console.Write("Antal personer i sällskapet: ");
                string inputGroupSize = Console.ReadLine()!;
                int totalPriceGroup = 0;

                //Kontrollerar om input är ett tal, allt annat än siffror är ogiltigt
                if (!int.TryParse(inputGroupSize, out int groupSize))
                {
                    Console.WriteLine("Ogiltigt format. Ange endast siffror");
                    GroupSize();//Anropar metoden igen för att låta användaren ange ett nytt värde
                    return;
                }

                if (groupSize <= 0)
                {
                    Console.WriteLine("Antalet personer måste vara minst 1.");
                    return;
                }

                for (int i = 0; i < groupSize; i++)
                {
                    Console.Write("Ange ålder för person " + (i + 1) + ": ");//L
                    string inputUserAge = Console.ReadLine()!;

                    //Kontrollerar om input är ett tal, allt annat än siffror är ogiltigt
                    if (!int.TryParse(inputUserAge, out int userAge))
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
                Console.WriteLine($"Antal personer : {groupSize}. | Totalt pris för sällskapet: {totalPriceGroup}kr. \n");
            }

            //Metoden RepeatText() som skriver ut en text 10 gånger 
            static void RepeatText()
            {
                Console.Write("Skriv en text: ");
                string textInput = Console.ReadLine()!;

                //Kontrollerar om texten är tom annars så anropas metoden igen för att låta användaren ange en ny text
                if (string.IsNullOrEmpty(textInput))
                {
                    Console.WriteLine("Ingen text angiven. Försök igen.");
                    RepeatText(); //Anropar metoden igen för att låta användaren ange en ny text
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
        }
    }
}