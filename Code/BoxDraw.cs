namespace DataBaseProject.Code;
using MySqlConnector;

public class BoxDraw
{
    public static void DrawBox(string[] lines, string titel = null)
    {
        // Zoek de langste line in de array en sla de lengte op als innerWidth
        int innerWidth = lines.Max(line => line.Length);
        
        // Als er een titel is, controleer of de titel breder is dan de langste regel
        if (titel != null)
        {
            // Gebruik de grootste waarde tussen de innerWidth en de lengte van de titel
            innerWidth = Math.Max(innerWidth, titel.Length);
        }
        
        // Maak een horizontale lijn van '═' tekens, +2 voor de spatie aan elke kant
        string horizontal = new string('═', innerWidth + 2);
        
        // Maak de tussenlijn met '╠' en '╣' aan de uiteinden
        string divider    = "╠" + horizontal + "╣";

        // Controleer of er een titel is meegegeven
        if (titel != null)
        {
            // Teken de bovenste rand met '╔' en '╗' als hoeken
            Console.WriteLine("╔" + horizontal + "╗");

            // Bereken hoeveel spaties er over zijn naast de titel
            int totalPadding = innerWidth - titel.Length;
            
            // Verdeel de spaties gelijk over links en rechts voor centrering
            int padLeft      = totalPadding / 2;
            int padRight     = totalPadding - padLeft;

            // Teken de titelregel gecentreerd met '║' aan beide kanten
            Console.WriteLine("║ " + new string(' ', padLeft) + titel + new string(' ', padRight) + " ║");
            
            // Teken de tussenlijn onder de titel
            Console.WriteLine(divider);
            
        }
        else
        {
            // Geen titel, teken alleen de bovenste rand
            Console.WriteLine("╔" + horizontal + "╗");
        }

        // Loop door elke regel in de array
        foreach (var line in lines)
        {
            // Teken de regel met '║' aan beide kanten, vul korte regels aan met spaties rechts
            Console.WriteLine("║ " + line.PadRight(innerWidth) + " ║");
        }

        // Teken de onderste rand met '╚' en '╝' als hoeken
        Console.WriteLine("╚" + horizontal + "╝");
    }
    
    public static void DrawTable(List<string> kolomNamen, List<List<string>> rijen, string titel = null)
    {
        // Bereken de breedte van elke kolom op basis van de data en kolomnaam
        var kolomBreedtes = new int[kolomNamen.Count];
        
        // Controleer eerst de breedte van de kolomnamen zelf
        for (int i = 0; i < kolomNamen.Count; i++)
        {
            kolomBreedtes[i] = kolomNamen[i].Length;
        }
        
        // Controleer daarna de breedte van elke rij per kolom
        foreach (var rij in rijen)
        {
            for (int i = 0; i < rij.Count; i++)
            {
                // Sla de grootste breedte op per kolom
                if (rij[i].Length > kolomBreedtes[i])
                {
                    kolomBreedtes[i] = rij[i].Length;
                }
            }
        }
        
        // Bereken de totale breedte van de tabel
        // +3 per kolom voor " | " scheiding, -1 voor het einde
        int totaalBreedte = kolomBreedtes.Sum(b => b + 3) - 1;
        
        // Zorg dat de titel ook past
        if (titel != null)
        {
            totaalBreedte = Math.Max(totaalBreedte, titel.Length + 2);
        }
        
        // Bouw de horizontale lijnen
        string bovenkant  = "╔" + new string('═', totaalBreedte) + "╗";
        string onderkant  = "╚" + new string('═', totaalBreedte) + "╝";
        string tussenlijn = "╠" + new string('═', totaalBreedte) + "╣";
        
        // Bouw de lijn tussen header en data
        // Ziet er zo uit: ╠═══╪═══╪═══╣
        string headerLijn = "╠";
        for (int i = 0; i < kolomNamen.Count; i++)
        {
            headerLijn += new string('═', kolomBreedtes[i] + 2);
            headerLijn += (i < kolomNamen.Count - 1) ? "╪" : "╣";
        }
        
        // ── Teken de bovenkant ──────────────────────────────
        Console.WriteLine(bovenkant);
        
        // ── Teken de titel als die er is ───────────────────
        if (titel != null)
        {
            int totalPadding = totaalBreedte - titel.Length;
            int padLeft      = totalPadding / 2;
            int padRight     = totalPadding - padLeft;
            Console.WriteLine("║" + new string(' ', padLeft) + titel + new string(' ', padRight) + "║");
            Console.WriteLine(tussenlijn);
        }
        
        // ── Teken de kolomnamen (header) ───────────────────
        string headerRegel = "║";
        for (int i = 0; i < kolomNamen.Count; i++)
        {
            headerRegel += " " + kolomNamen[i].PadRight(kolomBreedtes[i]) + " ";
            headerRegel += (i < kolomNamen.Count - 1) ? "│" : "║";
        }
        
        Console.WriteLine(headerRegel);
        Console.WriteLine(headerLijn);
        
        // ── Teken elke rij ─────────────────────────────────
        foreach (var rij in rijen)
        {
            string regel = "║";
            for (int i = 0; i < rij.Count; i++)
            {
                regel += " " + rij[i].PadRight(kolomBreedtes[i]) + " ";
                regel += (i < rij.Count - 1) ? "│" : "║";
            }
            Console.WriteLine(regel);
        }
        
        // ── Teken de onderkant ─────────────────────────────
        Console.WriteLine(onderkant);
    }
}