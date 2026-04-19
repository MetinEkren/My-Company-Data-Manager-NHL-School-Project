namespace DataBaseProject.Code;
using MySqlConnector;

public class Klanten
{
    public static void KlantenMenu()
    {
        // Maak het scherm leeg zodat het hoofdmenu niet meer zichtbaar is
        Console.Clear();
        
        // Maak een array aan met alle menuopties
        var KlantenMenulines = new[]
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
        BoxDraw.DrawBox(KlantenMenulines, titel: "Klanten");
        
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
        // int pageSize = 10;
        // int pagina = 1;
        // int totaal = BoxDraw.GetAantalRijen(Program.conn, "Klanten");

       
        Console.Clear();
      
        // string sql = @"SELECT *
        //                 FROM Klanten 
        //                LIMIT @limiet OFFSET @offset";
        // Maak de SQL query aan
        string sql = "SELECT * FROM Klanten";
        
        using (MySqlCommand cmd = new MySqlCommand(sql, Program.conn))
        {
            //cmd.Parameters.AddWithValue("@depname", "Sales");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string naam = reader.GetString("KlantNaam");
                Console.WriteLine("{0}", naam);
            }
            
            Console.WriteLine("Druk op een toets om terug te gaan...");
            Console.ReadKey();
            
            reader.Close();
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