namespace DataBaseProject.Code;

public static class MainMenu
{
    public static void HoofdMenu()
    {
        // Maak het scherm leeg zodat de vorige gegevens niet meer zichtbaar is
        Console.Clear();
        
        // Maak een array aan met alle menuopties 
        var hoofdMenuOpties = new[]
        {
            "1) Klanten",
            "2) Producten (Werkt nog niet)",
            "3) Bestellingen (Werkt nog niet)",
            "4) Medewerkers (Werkt nog niet)",
            "5) Leveranciers (Werkt nog niet)",
            "6) Categorieen (Werkt nog niet)",
            "7) Bestelregels (Werkt nog niet)",
            "8) Verzenddiensten (Werkt nog niet)",
            "9) * Statistieken & Grafieken *",
            "X) Afsluiten"
        };
        
        // Teken de box met het hoofdmenu opties en de titel
        BoxDraw.DrawBox(hoofdMenuOpties, titel: "Welkom bij Bedrijf Data Manager");
        
        // Vraag de gebruiker om een keuze te maken
        Console.Write("Keuze: ");
        
        // Lees wat de gebruiker intypt
        string? keuze = Console.ReadLine();
        
        // Controleer of de gebruiker wil afsluiten (hoofdletter of kleine letter x)
        if (keuze != null && keuze.Equals("x", StringComparison.OrdinalIgnoreCase))
        {
            // Sluit de databaseverbinding
            Program.Conn?.Close();
            
            // Maak het scherm leeg
            Console.Clear();
            
            // Toon een afscheidsbericht 
            Console.WriteLine("Tot ziens!");
            
            // Sluit de applicatie volledig af
            Environment.Exit(0);
        }
        else
        {
            // Verwerk de keuze van de gebruiker
            switch (keuze)
            {
                case "1": Console.Clear(); Klanten.KlantenMenu(); break;
                case "2": Console.Clear(); Producten.ProductenMenu(); break;
                case "3": Console.Clear(); Bestellingen.BestellingenMenu(); break;
                case "4": Console.Clear(); Medewerkers.MedewerkersMenu(); break;
                case "5": Console.Clear(); Leveranciers.LeveranciersMenu(); break;
                case "6": Console.Clear(); Categorieen.CategorieenMenu(); break;
                case "7": Console.Clear(); BestelRegels.BestelRegelsMenu(); break;
                case "8": Console.Clear(); VerzendDiensten.VerzendDienstenMenu(); break;
                case "9": Console.Clear(); Statistieken.StatistiekenMenu(); break;
                
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertelt de gebruiker dat de keuze ongeldig is
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