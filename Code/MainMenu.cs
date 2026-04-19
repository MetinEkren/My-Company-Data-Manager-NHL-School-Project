namespace DataBaseProject.Code;

public class MainMenu
{
    public static void HoofdMenu()
    {
        // Maak het scherm leeg zodat het hoofdmenu niet meer zichtbaar is
        Console.Clear();
        
        // Maak een array aan met alle menuopties
        var HoofdMenulines = new[]
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
        
        // Teken de box met het hoofdmenu en de titel
        BoxDraw.DrawBox(HoofdMenulines, titel: "Welkom bij Bedrijf Data Manager");
        
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
                case "1": /* Klanten */ Console.Clear(); Klanten.KlantenMenu(); break;
                
                case "2": /* Producten */ Console.Clear(); Producten.ProductenMenu(); break;
                
                case "3": /* Bestellingen */ Console.Clear(); Bestellingen.BestellingenMenu(); break;
                
                case "4": /* Medewerkers */ Console.Clear(); Medewerkers.MedewerkersMenu(); break;
                
                case "5": /* Leveranciers */ Console.Clear(); Leveranciers.LeveranciersMenu(); break;
                
                case "6": /* Categorieen */ Console.Clear(); Categorieen.CategorieenMenu(); break;
                
                case "7": /* Bestelregels */ Console.Clear(); BestelRegels.BestelRegelsMenu(); break;
                
                case "8": /* Verzenddiensten */ Console.Clear(); VerzendDiensten.VerzendDienstenMenu(); break;
                
                case "9": /* Statistieken */ Console.Clear(); Statistieken.StatistiekenMenu(); break;
                
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep het hoofdmenu opnieuw aan
                    HoofdMenu();
                    break;
            }
        }
    }
}