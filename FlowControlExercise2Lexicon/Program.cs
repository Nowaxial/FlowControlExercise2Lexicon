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
            //TODO: 6. Lägga till en metod för att beräkna biljettpriser beroende på ålder.
            //TODO: 7. Lägga till en metod för att beräkna biljettpriser beroende på sällskapets storlek och ålder

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
                        break;

                    case "2":
                        break;

                    case "3":

                        break;

                    case "4":
                        break;

                    default:
                        //Om användaren skriver något annat än 1-4 eller 0 så skrivs ett felmeddelande ut
                        Console.WriteLine("Felaktigt val, försök igen.\n");
                        break;
                }
            }
            while (isRunning);
        }
    }
}