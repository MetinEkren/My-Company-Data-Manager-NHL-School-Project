namespace DataBaseProject.Code;
using MySqlConnector;

public static class Statistieken
{
     public static void StatistiekenMenu()
    {
        //maakt het beeld weer leeg
        Console.Clear();
        
        // Maak een array aan met alle menuopties
        var statistiekenMenulines = new[]
        {
            "1) Hoeveel bestelingen heeft een klant gemaakt (Grafiek)",
            "2) Sla grafiek op als PNG",
            "R) Ga terug",
            "X) Afsluiten"
        };
        
        // Teken de box met het StatistiekenMenu en de titel
        BoxDraw.DrawBox(statistiekenMenulines, titel: "Statistieken");
        
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
            Console.WriteLine("Totziens!");
            
            // Sluit de applicatie volledig af
            Environment.Exit(0);
            
        }else if (keuze != null && keuze.Equals("r", StringComparison.OrdinalIgnoreCase)) {
            
            MainMenu.HoofdMenu();
            
        }else {
            
            // Verwerk de keuze van de gebruiker
            switch (keuze)
            {
                case "1": GrafBestelingenMetKlant(); break;
                case "2": PngGrafiek(); break;
                
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep het StatistiekenMenu opnieuw aan
                    StatistiekenMenu();
                    break;
            }
        }
    }

    private static void GrafBestelingenMetKlant()
    {
        Console.Clear();
        
        string sql =
            "SELECT klanten.KlantID, klanten.KlantNaam, COUNT(bestellingen.BestellingID) AS AantalBestellingen " +
            "FROM klanten " +
            "INNER JOIN bestellingen ON klanten.KlantID = bestellingen.KlantID " +
            "GROUP BY klanten.KlantID, klanten.KlantNaam " +
            "ORDER BY AantalBestellingen DESC";
        
        
        using (MySqlCommand cmd = new MySqlCommand(sql, Program.Conn))
        {
            using MySqlDataReader reader = cmd.ExecuteReader();
            
            var data = new List<(int id, string naam, int aantal)>();
            
            while (reader.Read())
            {
                int id      = reader.GetInt32("KlantID");
                string naam = reader.GetString("KlantNaam");
                int aantal  = reader.GetInt32("AantalBestellingen");
                
                data.Add((id, naam, aantal));
            }
            
            reader.Close();
        
            if (data.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Geen klanten gevonden ongeldig ID of geen bestellingen gevonden.");
                Console.WriteLine("Druk op een toets om terug te gaan...");
                Console.ReadKey();
                StatistiekenMenu();
            }
            else
            {
                // Bereken de balklengte per rij
                int max = data.Max(a => a.aantal);
                int maxBalkBreedte = 20;
        
                // Kolomnamen voor DrawTable
                var kolomNamen = new List<string> { "ID", "Naam", "Grafiek", "Aantal" };
        
                // Bouw de rijen op met de balk als kolom
                var rijen = new List<List<string>>();
                
                foreach (var (id, naam, aantal) in data)
                {
                    //berekening van powerpoint geen idee waarom dit nodig is 
                    int balkLengte = (int)((aantal / (double)max) * maxBalkBreedte);
                    string balk    = new string('█', balkLengte);
            
                    //rijen.Add(new List<string> { id.ToString(), naam, balk, aantal.ToString() });
                    rijen.Add([id.ToString(), naam, balk, aantal.ToString()]);
                }
        
                // Gebruik DrawTable zoals gewoonlijk
                BoxDraw.DrawTable(kolomNamen, rijen, titel: "Bestellingen per Klant");
                
                Console.WriteLine("Druk op een toets om terug te gaan...");
                Console.ReadKey();
                StatistiekenMenu();
            }
        }
    }

    private static void PngGrafiek()
    {
        string sql =
            "SELECT klanten.KlantID, klanten.KlantNaam, COUNT(bestellingen.BestellingID) AS AantalBestellingen " +
            "FROM klanten " +
            "INNER JOIN bestellingen ON klanten.KlantID = bestellingen.KlantID " +
            "GROUP BY klanten.KlantID, klanten.KlantNaam " +
            "ORDER BY AantalBestellingen DESC";
        
        // Sla de data op uit de database
        var namen   = new List<string>();
        var aantallen = new List<double>();

        using (MySqlCommand cmd = new MySqlCommand(sql, Program.Conn))
        {
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                namen.Add(reader.GetString("KlantNaam"));
                aantallen.Add(reader.GetInt32("AantalBestellingen"));
            }

            reader.Close();
        }

        // Maakt de ScottPlot grafiek aan
        var plt = new ScottPlot.Plot();

        // Maakt de staafdiagram
        //var bar = plt.Add.Bars(aantallen.ToArray());
        plt.Add.Bars(aantallen.ToArray());

        // Rotated Tick Labels — klantnamen schuin weergeven
        ScottPlot.Tick[] ticks = namen.Select((naam, i) => new ScottPlot.Tick(i, naam)).ToArray();

        plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

        // Roteer de labels 45 graden zodat ze niet overlappen
        plt.Axes.Bottom.TickLabelStyle.Rotation = 45;
        plt.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot.Alignment.MiddleLeft;

        // Titels en labels
        plt.Title("Bestellingen per Klant");
        plt.YLabel("Aantal Bestellingen");
        plt.XLabel("Klanten");

        // Sla op als PNG bestand
        plt.SavePng(@"D:\download(D)\bestellingen_grafiek.png", 1500, 1000);
        
        Console.Clear();
        Console.WriteLine("Grafiek opgeslagen als bestellingen_grafiek.png");
        Console.WriteLine("Druk op een toets om terug te gaan...");
        Console.ReadKey();
        StatistiekenMenu();
    }
}