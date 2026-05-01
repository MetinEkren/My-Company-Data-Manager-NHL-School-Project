namespace DataBaseProject.Code;
using MySqlConnector;

public class Klanten
{
    public static void KlantenMenu()
    {
        // Maak het scherm leeg zodat het hoofdmenu niet meer zichtbaar is
        Console.Clear();
        
        // Maak een array aan met alle menuopties
        var klantenMenulines = new[]
        {
            "1) Toon alle klanten",
            "2) Zoek op naam",
            "3) Voeg klant toe",
            "4) Wijzig klant gegevens op id",
            "5) Klant verwijderen",
            "6) Toon bestellingen van een klant",
            "R) Ga terug",
            "X) Afsluiten"
        };
        
        // Teken de box met het KlantenMenu en de titel
        BoxDraw.DrawBox(klantenMenulines, titel: "Klanten");
        
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
                case "1": Keuzeklanten(); break;
                case "2": ZoekKlant(); break;
                case "3": VoegKlantToe(); break;
                case "4": WijzigKlant(); break;
                case "5": VerwijderKlant(); break;
                case "6": BestelingenMetKlant(); break;
                
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep de Klanten menu opnieuw aan
                    KlantenMenu();
                    break;
            }
        }
    }
    
    private static void Keuzeklanten()
    {
        Console.Clear();
        
        // Maak een array aan met alle menuopties
        var klantenkeuze = new[]
        {
            "1) Toon alle klanten",
            "2) Toon alleen naam en id",
            "R) Ga terug",
            "X) Afsluiten"
        };
        
        // Teken de box met het KlantenMenu en de titel
        BoxDraw.DrawBox(klantenkeuze, titel: "Klanten");
        
        // Vraag de gebruiker om een keuze te maken
        Console.Write("Keuze: ");
        
        // Lees wat de gebruiker intypt
        string keuze = Console.ReadLine();

        Controlekeuze(keuze);
    }
    
    private static void Controlekeuze(string keuze)
    {
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
            
            KlantenMenu();
            
        }else
        {
            string sql = "";
            // Verwerk de keuze van de gebruiker
            switch (keuze)
            {
                // Haal ALLES op uit de klanten tabel
                case "1":
                    sql = "SELECT * FROM Klanten"; SqlklantUitvoeren(keuze, sql);break;
                
                // Maak de SQL query aan toon id en naam
                case "2": 
                    sql = "SELECT KlantID, KlantNaam FROM Klanten"; SqlklantUitvoeren(keuze, sql);  break;
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep de Klanten menu opnieuw aan
                    Keuzeklanten();
                    break;
            }
        }
    }
    private static void SqlklantUitvoeren( string keuze, string sql)
    {
        Console.Clear();
        
        using (MySqlCommand cmd = new MySqlCommand(sql, Program.conn))
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            
            // Haal automatisch alle kolomnamen op uit de database
            var kolomNamen = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                // reader.GetName() geeft de naam van elke kolom
                kolomNamen.Add(reader.GetName(i));
            }
            
            // Alle rijen met data / Lees alle rijen uit de database
            var rijen = new List<List<string>>();
        
            while (reader.Read())
            {
                if (keuze == "1")
                {
                    var rij = new List<string>();
            
                    // Loop door elke kolom en lees de waarde
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Zet elke waarde om naar string
                        // IsDBNull controleert of de waarde leeg (NULL) is
                        rij.Add(reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString());
                    }
            
                    rijen.Add(rij);
                    
                }else if (keuze == "2")
                {
                    // Lees de KlantID en KlantNaam uit elke rij
                    int id       = reader.GetInt32("KlantID");
                    string naam  = reader.GetString("KlantNaam");
                    
                    // Elke rij is een lijst van strings
                    rijen.Add(new List<string> { id.ToString(), naam });
                }
            }
            
            reader.Close();
            
            // Teken de tabel
            BoxDraw.DrawTable(kolomNamen, rijen, titel: "Alle Klanten");
            
            Console.WriteLine("Druk op een toets om terug te gaan...");
            Console.ReadKey();
            
            Keuzeklanten();
        }
    }
    
    private static void ZoekKlant()
    {
        string klantNaam = LeesVerplichtVeld("Zoek op KlantNaam: ");

        Console.Clear();
        
        string sql = "SELECT * FROM Klanten WHERE KlantNaam LIKE @zoekKlant";
        
        using (MySqlCommand cmd = new MySqlCommand(sql, Program.conn))
        {
            // @zoekKlant tegen sql injectie
            cmd.Parameters.AddWithValue("@zoekKlant", "%" + klantNaam + "%");
            using MySqlDataReader reader = cmd.ExecuteReader();
            
            // Haal automatisch alle kolomnamen op uit de database
            var kolomNamen = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                // reader.GetName() geeft de naam van elke kolom
                kolomNamen.Add(reader.GetName(i));
            }
            
            // Alle rijen met data / Lees alle rijen uit de database
            var rijen = new List<List<string>>();
            
            while (reader.Read())
            {
                var rij = new List<string>();
                
                // Loop door elke kolom en lees de waarde
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Controleer of de waarde in de database leeg (NULL) is
                    // Als het leeg is voeg de tekst "NULL" toe aan de rij
                    // Als het niet leeg is zet de waarde om naar tekst met ToString() en voeg het toe
                    rij.Add(reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString());
                }
            
                rijen.Add(rij);
            }
            reader.Close();
            
            if (rijen.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Geen klanten gevonden.");
                Console.WriteLine("Druk op een toets om terug te gaan...");
                Console.ReadKey();
                KlantenMenu();
            }
            else
            {
                BoxDraw.DrawTable(kolomNamen, rijen, titel: "Zoekresultaten");
                Console.WriteLine("Druk op een toets om terug te gaan...");
                Console.ReadKey();
                KlantenMenu();
            }
        }
    }
    
    private static void VoegKlantToe()
    {
        Console.Clear();
        Console.WriteLine("Geef elke vraag een antwoord");
        
        string naam     = LeesVerplichtVeld("Wat is de KlantNaam: ");
        string contact  = LeesVerplichtVeld("Wie is de ContactPersoon: ");
        string adres    = LeesVerplichtVeld("Wat is zijn of haar Adres: ");
        string stad     = LeesVerplichtVeld("Welke Stad: ");
        string postcode = LeesVerplichtVeld("Wat is zijn of haar Postcode: ");
        string land     = LeesVerplichtVeld("Welke Land: ");

        string sql = "INSERT INTO Klanten (KlantNaam, ContactPersoon, Adres, Stad, Postcode, Land) " +
                     "VALUES (@naam, @contact, @adres, @stad, @postcode, @land)";
        
        using (MySqlCommand cmd = new MySqlCommand(sql, Program.conn))
        {
            cmd.Parameters.AddWithValue("@naam", naam);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@adres", adres);
            cmd.Parameters.AddWithValue("@stad", stad);
            cmd.Parameters.AddWithValue("@postcode", postcode);
            cmd.Parameters.AddWithValue("@land", land);
            
            // ExecuteNonQuery werkt voor INSERT, UPDATE, DELETE
            cmd.ExecuteNonQuery();
            Console.WriteLine("Klant toegevoegd! Nieuw ID: " + cmd.LastInsertedId);
            
            Console.WriteLine("Druk op een toets om terug te gaan...");
            Console.ReadKey();
            KlantenMenu();
        }
    }
    
    //een methode om zekker te weten dat we een waarde krijgen
    private static string LeesVerplichtVeld(string vraag)
    {
        string invoer;
    
        do
        {
            Console.Write(vraag);
            invoer = Console.ReadLine();
        
            // Controleer of de invoer leeg, null of alleen spaties is
            if (string.IsNullOrWhiteSpace(invoer))
            {
                Console.Clear();
                Console.WriteLine("Dit veld is verplicht! Probeer opnieuw.");
            }
        
        } while (string.IsNullOrWhiteSpace(invoer));
    
        // Verwijder spaties aan het begin en einde
        return invoer.Trim();
    }
    
    private static void WijzigKlant()
    {
        
    }
    
    private static void VerwijderKlant()
    {
        
    }
    
    private static void BestelingenMetKlant()
    {
        
    }
}