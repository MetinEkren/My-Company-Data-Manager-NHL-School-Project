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
                case "1": ToonKlanten(); break;
                case "2": ZoekKlant(); break;
                case "3": VoegKlantToe(); break;
                case "4": WijzigKlant(); break;
                case "5": VerwijderKlant(); break;
                
                default:
                    
                    // Maak het scherm leeg
                    Console.Clear();
                    
                    // Vertel de gebruiker dat de keuze ongeldig is
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw. Gebruik de cijfers!!!!");

                    // Wacht totdat de gebruiker op een toets drukt
                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
                    
                    // Roep het Klanten menu opnieuw aan
                    KlantenMenu();
                    break;
            }
        }
    }

    private static void ToonKlanten()
    {
        Console.Clear();
        
        // Maak de SQL query aan
        // string sql = "SELECT KlantID, KlantNaam FROM Klanten";
        
        // Haal ALLES op uit de klanten tabel
        string sql = "SELECT * FROM Klanten";
        
        using (MySqlCommand cmd = new MySqlCommand(sql, Program.conn))
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            
            // Kolomnamen voor de header
            // var kolomNamen = new List<string> { "ID", "Klant Naam" };
            
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
                // // Lees de KlantID en KlantNaam uit elke rij
                // int id       = reader.GetInt32("KlantID");
                // string naam  = reader.GetString("KlantNaam");
                //
                // // Elke rij is een lijst van strings
                // rijen.Add(new List<string> { id.ToString(), naam });
                
                var rij = new List<string>();
            
                // Loop door elke kolom en lees de waarde
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Zet elke waarde om naar string
                    // IsDBNull controleert of de waarde leeg (NULL) is
                    rij.Add(reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString());
                }
            
                rijen.Add(rij);
            }
            
            reader.Close();
            
            // Teken de tabel
            BoxDraw.DrawTable(kolomNamen, rijen, titel: "Alle Klanten");
            
            Console.WriteLine("Druk op een toets om terug te gaan...");
            Console.ReadKey();
            
            
            KlantenMenu();
        }
    }
    
    private static void ZoekKlant()
    {
        
    }
    
    private static void VoegKlantToe()
    {
        
    }
    
    private static void WijzigKlant()
    {
        
    }
    
    private static void VerwijderKlant()
    {
        
    }
}