namespace DataBaseProject.Code;

public class BestelRegels
{
    public static void BestelRegelsMenu()
    {
        // Maak een array aan met alle menuopties
        var bestelRegelsMenulines = new[]
        {
            "1) Klanten",
            "R) Ga terug",
            "X) Afsluiten"
            
        };
        
        // Teken de box met het BestelRegelsMenu en de titel
        BoxDraw.DrawBox(bestelRegelsMenulines, titel: "BestelRegels");
        
        // Vraag de gebruiker om een keuze te maken
        Console.Write("Keuze: ");
        
        // Lees wat de gebruiker intypt
        string keuze = Console.ReadLine();
        
        // Controleer of de gebruiker wil afsluiten (hoofdletter of kleine letter x)
        if (keuze.Equals("x", StringComparison.OrdinalIgnoreCase))
        {
            // Sluit de databaseverbinding
            Program.conn.Close();
            
            // Maak het scherm leeg
            Console.Clear();
            
            // Toon een afscheidsbericht 
            Console.WriteLine("Totziens!");
            
            // Sluit de applicatie volledig af
            Environment.Exit(0);
            
        }else if (keuze.Equals("r", StringComparison.OrdinalIgnoreCase)) {
            
            MainMenu.HoofdMenu();
            
        }else {
            
            // Verwerk de keuze van de gebruiker
            switch (keuze)
            {
                case "1": /* Klanten */        break;
               
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep het BestelRegelsMenu opnieuw aan
                    BestelRegelsMenu();
                    break;
            }
        }
    }
}