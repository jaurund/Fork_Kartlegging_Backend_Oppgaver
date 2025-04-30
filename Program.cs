using System;
using System.Data;
using System.Globalization;

namespace PersonInfoDataApp;

class DataPrinter

{
    static void Main(string[] args)
    {
        LagreOgSkrivPersonInfo();
    }

        static void LagreOgSkrivPersonInfo()
        {
            // Få input fra konsoll

            // input for navn
            Console.Write("Ditt navn: ");
            string navn = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(navn))
            // IsNullOrEmpty skaper problemer fordi Console.ReadLine hiver inn et mellomrom, tror jeg?
            {
                Console.WriteLine("Glemte du å skrive inn en verdi? \nSkriv navnet ditt: ");
                navn = Console.ReadLine();
            }
            
            // input for alder
            Console.Write("Din alder: ");
            string alderInput = Console.ReadLine();
            int alder;

            while (!int.TryParse(alderInput, out alder))
            {
                Console.WriteLine("Du må skrive alderen din med bare tall, uten bokstaver, spesialtegn eller tomme felt. \nPrøv igjen: ");
                alderInput = Console.ReadLine();
            }

            // Oppgave 2: kategorisere alder med if / else
            string alderKategori;
            if (alder >= 0 && alder <=12)
            {
                alderKategori = "barn";
            }
            else if (alder >= 13 && alder <=19)
            {
                alderKategori = "ungdom";
            }
            else
            {
                alderKategori = "voksen";
            }
            

            // input for høyde
            Console.Write("Din høyde i cm (kun tall): ");
            string høydeInput = Console.ReadLine();
            int høyde;

            while (true)
            // (!int.TryParse(høydeInput, out høyde))
            {

                høydeInput = høydeInput.Replace(".", ",");
                if (!double.TryParse(høydeInput, out double parsedHeight))
                {
                    Console.WriteLine("Du må skrive høyden din i centimeter med tall, uten bokstaver, spesialtegn eller tomme felt. ");
                }


                else if (parsedHeight % 1 != 0)
                
                {
                    Console.WriteLine("Du må skrive et helt tall uten desimaler. ");
                }
                else
                {
                    høyde = (int)parsedHeight;
                    break;
                }

                Console.Write("Prøv igjen: ");
                høydeInput = Console.ReadLine();
                // Console.WriteLine("Du må skrive høyden din i centimeter med tall, uten bokstaver, spesialtegn eller tomme felt. \nPrøv igjen: ");
                // høydeInput = Console.ReadLine();4
            }
            
            double høydeIMeter = høyde / 100.0;
            // erstattet kode: int høyde = Convert.ToInt32(Console.ReadLine());
            // denne er også erstattet i alder-feltet

            // Skriver ut informasjonen
            Console.WriteLine("\n~~~ Din informasjon: ~~~");
            Console.WriteLine($"Navn: {navn}");
            Console.WriteLine($"Alder: {alder} ({alderKategori})");
            Console.WriteLine($"Høyde: {høydeIMeter:F2} m");
            Console.WriteLine("\nEr dette korrekt informasjon?");
            Console.WriteLine("y/n");

            string svar = Console.ReadLine()?.ToLower();

            if (svar == "y" || svar == "yes")
            {
                Console.WriteLine("Supert! Da kan vi gå videre til å skrive ut en tallrekke fra 1-10, før vi skal kjøre .... (trommevirvel) FizzBuzz!");
                PrintNumbers();
                RunFizzBuzz();
            }

            else if (svar == "n" || svar == "no")
            {
                Console.WriteLine("Det var skikkelig dumt, men ingenting vi kan gjøre noe med nå. \nVi må nemlig gå videre til å skrive ut en tallrekke fra 1-10, før vi skal kjøre .... (trommevirvel) FizzBuzz!");
                PrintNumbers();
                RunFizzBuzz();
            }
            else
            {
                Console.WriteLine("Om du ikke en gang greier å inputte riktig informasjon her, får du ikke være med på leken. Programmet avsluttes.");
                return;
            }
            
            
        }

        // Oppgave 3: skrive tall fra 1-10
        static void PrintNumbers()
        {
            Console.WriteLine("\n--- fra 1 til 10 ---");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        // ekstraoppgave: lage FizzBuzz
        static void DisplayHeader()
        {
            Console.WriteLine();

                int width = Console.WindowWidth;


            string[] lines = {
                "~~~~ FIZZBUZZ ~~~~"
            };

            Console.ForegroundColor = ConsoleColor.DarkCyan;

             foreach (string line in lines)
    {
        int padding = (width - line.Length) / 2;
        Console.WriteLine(new string(' ', Math.Max(padding, 0)) + line);
    }

                Console.ResetColor();
            
            
        }
        

        
        // valgt å la dette bli for å vise arbeidsrekkefølgen, men skrevet programmet på nytt under

        /* static void RunFizzBuzz()
        
        {
        for (int i = 1; i<= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)  
            
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else
            {
                Console.WriteLine(i);
            }

        }*/

        static void RunFizzBuzz()
        {
            DisplayHeader();
        for (int i = 1; i<= 100; i++)
        {
            string output = $"{i}";
            bool isFizzOrBuzz = false;

            if (i % 3 == 0 && i % 5 == 0)  
            {
                Console.ForegroundColor = ConsoleColor.Green;
                output += " FizzBuzz";
                isFizzOrBuzz = true;
            }

            else if (i % 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                output += " Fizz";
                isFizzOrBuzz = true;
            }

            else if (i % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                output += " Buzz";
                isFizzOrBuzz = true;
            }
            Console.WriteLine(output);
            if (isFizzOrBuzz)
            {
                Console.ResetColor();
            }
            // her hallusinerte først ChatGPT og mente at Console.WriteLine(output); skulle være inne i en else - statement
        }

        Console.WriteLine("\nTusen takk for at du kjørte programmet mitt! På gjensyn!");
        Console.WriteLine("\n--- TAKK FOR ALT ---");

        } 

// etter jeg var ferdig med å gi farge til tall osv, sier ChatGPT plutselig at dette var en mye mer effektiv måte å skrive det på.
// hadde uansett ikke lært mer om if true / false statements om jeg hadde gjort det slik fra begynnelsen

/*static void RunFizzBuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        string output = $"{i}";

        if (i % 3 == 0 && i % 5 == 0)  
        {
            Console.ForegroundColor = ConsoleColor.Green;
            output += " FizzBuzz";
        }
        else if (i % 3 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            output += " Fizz";
        }
        else if (i % 5 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            output += " Buzz";
        }

        Console.WriteLine(output); // Print output

        // Reset color after printing, regardless of the condition
        Console.ResetColor(); 
    }*/
}
        
    

