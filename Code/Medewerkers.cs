namespace DataBaseProject.Code;

public class Medewerkers
{
     public static void MedewerkersMenu()
    {
        var MedewerkersMenulines = new[]
        {
            "1) Klanten",
            "2) Producten",
            "3) Bestellingen",
            "4) Medewerkers",
            "5) Levenranciers",
            "6) Categorieen",
            "7) Bestelregels",
            "8) Verzenddiensten",
            "9) * Statistieken & Grafieken *",
            "X) Afsluiten"
            
        };
        
        // Teken de box met het MedewerkersMenu en de titel
        BoxDraw.DrawBox(MedewerkersMenulines, titel: "Medewerkers");
        
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
        }
        else
        {
            // Verwerk de keuze van de gebruiker
            switch (keuze)
            {
                case "1": /* Klanten */        break;
                case "2": /* Producten */      break;
                case "3": /* Bestellingen */   break;
                case "4": /* Medewerkers */    break;
                case "5": /* Leveranciers */   break;
                case "6": /* Categorieen */    break;
                case "7": /* Bestelregels */   break;
                case "8": /* Verzenddiensten */break;
                case "9": /* Statistieken */   break;
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep het MedewerkersMenu opnieuw aan
                    MedewerkersMenu();
                    break;
            }
        }
    }
}