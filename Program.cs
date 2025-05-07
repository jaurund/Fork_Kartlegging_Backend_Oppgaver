using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace PersonInfoDataApp;

class DataPrinter

{
    static string navn;
    static int alder;
    static string alderKategori;
    static int høyde;
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        LagreOgSkrivPersonInfo();
    }


    static void TypeWriter(string text, int baseDelay = 30)
    {
        Random rand = new Random();
        bool slowMode = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text.Substring(i).StartsWith("<slow>"))
            {
                slowMode = true;
                i += "<slow>".Length - 1;
                continue;
            }
            if (text.Substring(i).StartsWith("</slow>"))
            {
                slowMode = false;
                i += "</slow>".Length - 1;
                continue;
            }

            Console.Write(text[i]);

            int delay = baseDelay;
            if (slowMode)
            {
                delay *= 4; // 4x seinare skriving
            }
            else if (text[i] == '.' || text[i] == ',' || text[i] == '!' || text[i] == '?')
            {
                delay *= 6;
            }
            else if (char.IsWhiteSpace(text[i]))
            {
                delay *= 2;
            }
            else
            {
                delay = rand.Next(delay, delay + 40);
            }

            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }

    // INPUT NAVN
    static void HentNavn()
        {
            Console.Write("Ditt navn: ");
            navn = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(navn))
            // brukte IsNullOrEmpty, men det skaper problemer fordi Console.ReadLine hiver inn et mellomrom, tror jeg?
            {
                Console.WriteLine("Glemte du å skrive inn en verdi? \nSkriv navnet ditt: ");
                navn = Console.ReadLine();
            }
        }

        // INPUT ALDER
            static void HentAlder()
            {
                Console.Write("Din alder: ");
                string alderInput = Console.ReadLine();
                while (!int.TryParse(alderInput, out alder))
                {
                    Console.WriteLine("Du må skrive alderen din med bare tall, uten bokstaver, spesialtegn eller tomme felt. \nPrøv igjen: ");
                    alderInput = Console.ReadLine();
                    
                }
                KategoriserAlder(alder);
            // Oppgave 2: kategorisere alder med if / else
            }

            static string KategoriserAlder(int alder)
            {
                if (alder <= 12) { alderKategori = "barn"; }
            else if (alder <= 19) { alderKategori = "ungdom"; }
            else if (alder <= 34) { alderKategori = "ung voksen"; }
            else if (alder <= 55) { alderKategori = "voksen"; }
            else if (alder <= 69) { alderKategori = "gammel voksen"; }
            else if (alder <= 89) { alderKategori = "bare gammel"; }
            else if (alder <= 109) { alderKategori = "veldig gammel"; }
            else if (alder >= 110) { alderKategori = "du er enten et mirakel, eller bare veldig, veldig død"; }
            return alderKategori;
            }
            static void HentHøyde()
            {
                while (true)
                {
                
                Console.Write("Din høyde i cm (kun hele tall): ");
                string høydeInput = Console.ReadLine()?.Replace(".", ",");

                if (int.TryParse(høydeInput, out høyde))
                    break;
                
                Console.WriteLine("Ugyldig høyde. Du må skrive et helt tall uten desimaler.");

            }
        }


    // Få input fra konsoll
    static void LagreOgSkrivPersonInfo()
    {
        Console.Clear();

        HentNavn();
        HentAlder();
        HentHøyde();

        double høydeIMeter = høyde / 100.0;


            // BEKREFT INFORMASJON
            void SkrivBekreftetInfo()
            {
                Console.WriteLine("\n~~~ Din informasjon: ~~~");
                Console.WriteLine($"Navn: {navn}");
                Console.WriteLine($"Alder: {alder} ({alderKategori})");
                Console.WriteLine($"Høyde: {høydeIMeter} m");               
            }
                Console.WriteLine("\nEr dette korrekt informasjon?");
                Console.WriteLine("y/n");

            SkrivBekreftetInfo();

            string svar = Console.ReadLine()?.ToLower();
            if (svar == "y" || svar == "yes")
            {
                TypeWriter("Supert!");
                KjørFizzBuzzDel();
                return;
            }

            else if (svar == "n" || svar == "no")
            {
                bool harEndret = false;

                while (true)
                {
                    string endretMelding = harEndret ? "\nVil du endre noe mer?" : "\nHvilket felt vil du endre?";
                    Console.WriteLine(endretMelding);
                    Console.WriteLine("1. Navn\n2. Alder\n3. Høyde");

                    // dynamisk x-melding
                    string xChoiceMessage = harEndret ? "x Fortsett med oppdaterte endringer" : "x Fortsett uten endring";
                    Console.WriteLine(xChoiceMessage);

                    string feltvalg = Console.ReadLine();

                    if (feltvalg == "x")                    
                    {
                        if (harEndret)
                        {
                            SkrivBekreftetInfo();
                            TypeWriter("Takk for oppdateringen");
                        }
                        else
                        {
                            TypeWriter("Det er i orden!");
                        }
                        KjørFizzBuzzDel();
                        return;
                    }

                    switch (feltvalg)
                    {
                        case "1":
                            HentNavn();
                            harEndret = true;
                            break;
                        case "2":
                            HentAlder();
                            harEndret = true;
                            break;
                        case "3":
                            HentHøyde();
                            harEndret = true;
                            break;
                        default:
                            Console.WriteLine("Ugyldig valg, prøv igjen");
                            break;
                    }
                    høydeIMeter = høyde / 100.0;

                    SkrivBekreftetInfo();                   
                }              
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

                Random rand = new Random();
                ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

                for (int i = 1; i <= 10; i++)
                // Kjører igjennom tilfeldige farger på tall
                {
                    ConsoleColor color;
                    do
                    {
                        color = colors[rand.Next(colors.Length)];
                    } while (color == Console.BackgroundColor);

                    Console.ForegroundColor = color;
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }

                Console.ResetColor();
                Thread.Sleep(800);
            }

            // ekstraoppgave: lage FizzBuzz
            static void DisplayHeader()
            {
                Console.WriteLine();

                int width = Console.WindowWidth;


                string[] lines = { "~~~~ FIZZBUZZ ~~~~" };

                Console.ForegroundColor = ConsoleColor.DarkCyan;

                foreach (string line in lines)
                {
                    int padding = (width - line.Length) / 2;
                    Console.WriteLine(new string(' ', Math.Max(padding, 0)) + line);
                }


                Console.ResetColor();
                Thread.Sleep(500);
            }


            static void RunFizzBuzz()
            {
                DisplayHeader();
                for (int i = 1; i <= 100; i++)
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
                    Thread.Sleep(100);

                }

                Console.WriteLine("\nTusen takk for at du kjørte programmet mitt! På gjensyn!");
                Console.WriteLine("\n--- TAKK FOR ALT ---");

            }

            static void KjørFizzBuzzDel()
                {
                    TypeWriter("Da går vi videre til å skrive ut en tallrekke fra 1-10, før vi skal kjøre .... <slow>(trommevirvel)</slow> FizzBuzz!");
                    PrintNumbers();
                    RunFizzBuzz();
                }
        }